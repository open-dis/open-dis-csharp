using OpenDis.Dis1995;
using System;
using System.Diagnostics.SymbolStore;

namespace OpenDis.Core
{
    /// <summary>
    /// Converts DIS (x,y,z) rectilinear coordinates (earth-centered RH coordinate system)
    /// to latitude and longitude, in radians.
    /// @author loyaj
    /// </summary>
    public sealed class CoordinateConversions
    {
        public static readonly double RADIANS_TO_DEGREES = 180.0 / Math.PI;
        public static readonly double DEGREES_TO_RADIANS = Math.PI / 180.0;

        private CoordinateConversions()
        {
        }
        /// <summary>
        /// Converts DIS xyz world coordinates to latitude and longitude (IN RADIANS). This algorithm may not be 100% accurate
        /// near the poles. Uses WGS84 , though you can change the ellipsoid constants a and b if you want to use something
        /// else. These formulas were obtained from Military Handbook 600008 </summary>
        /// <param name="xyz"> A double array with the x, y, and z coordinates, in that order. </param>
        /// <returns> An array with the lat, long, and elevation corresponding to those coordinates.
        /// Elevation is in meters, lat and long are in radians </returns>
        public static double[] xyzToLatLonRadians(double[] xyz)
        {
            double x = xyz[0];
            double y = xyz[1];
            double z = xyz[2];
            double[] answer = new double[3];
            const double a = 6378137.0; //semi major axis
            const double b = 6356752.3142; //semi minor axis

            double eSquared; //first eccentricity squared
            double rSubN; //radius of the curvature of the prime vertical
            double ePrimeSquared; //second eccentricity squared
            double W = Math.Sqrt((x * x) + (y * y));

            eSquared = ((a * a) - (b * b)) / (a * a);
            ePrimeSquared = ((a * a) - (b * b)) / (b * b);

            // Get the longitude.
            answer[1] = x >= 0 ? Math.Atan(y / x)
             : x < 0 && y >= 0 ? Math.Atan(y / x) + Math.PI
                               : Math.Atan(y / x) - Math.PI;

            // Longitude calculation done. Now calculate latitude.
            // NOTE: The handbook mentions using the calculated phi (latitude) value to recalculate B
            // using tan B = (1-f) tan phi and then performing the entire calculation again to get more accurate values.
            // However, for terrestrial applications, one iteration is accurate to .1 millimeter on the surface of the
            // earth (Rapp, 1984, p.124), so one iteration is enough for our purposes
            double tanBZero = a * z / (b * W);
            double BZero = Math.Atan(tanBZero);
            double tanPhi = (z + (ePrimeSquared * b * Math.Pow(Math.Sin(BZero), 3))) / (W - (a * eSquared * Math.Pow(Math.Cos(BZero), 3)));
            double phi = Math.Atan(tanPhi);
            answer[0] = phi;
            // Latitude done, now get the elevation. Note: The handbook states that near the poles, it is preferable to use
            // h = (Z / sin phi ) - rSubN + (eSquared * rSubN). Our applications are never near the poles, so this formula
            // was left unimplemented.
            rSubN = a * a / Math.Sqrt((a * a * (Math.Cos(phi) * Math.Cos(phi))) + (b * b * (Math.Sin(phi) * Math.Sin(phi))));

            answer[2] = (W / Math.Cos(phi)) - rSubN;

            return answer;
        }

        /// <summary>
        /// Converts DIS xyz world coordinates to latitude and longitude (IN DEGREES). This algorithm may not be 100% accurate
        /// near the poles. Uses WGS84 , though you can change the ellipsoid constants a and b if you want to use something
        /// else. These formulas were obtained from Military Handbook 600008 </summary>
        /// <param name="xyz"> A double array with the x, y, and z coordinates, in that order. </param>
        /// <returns> An array with the lat, lon, and elevation corresponding to those coordinates.
        /// Elevation is in meters, lat and long are in degrees </returns>
        public static double[] xyzToLatLonDegrees(double[] xyz)
        {
            double[] degrees = xyzToLatLonRadians(xyz);

            degrees[0] = degrees[0] * 180.0 / Math.PI;
            degrees[1] = degrees[1] * 180.0 / Math.PI;

            return degrees;
        }

        /// <summary>
        /// Converts lat long and geodetic height (elevation) into DIS XYZ
        /// This algorithm also uses the WGS84 ellipsoid, though you can change the values
        /// of a and b for a different ellipsoid. Adapted from Military Handbook 600008 </summary>
        /// <param name="latitude"> The latitude, IN RADIANS </param>
        /// <param name="longitude"> The longitude, in RADIANS </param>
        /// <param name="height"> The elevation, in meters </param>
        /// <returns> a double array with the calculated X, Y, and Z values, in that order </returns>
        public static double[] getXYZfromLatLonRadians(double latitude, double longitude, double height)
        {
            const double a = 6378137.0; //semi major axis
            const double b = 6356752.3142; //semi minor axis
            double cosLat = Math.Cos(latitude);
            double sinLat = Math.Sin(latitude);

            double rSubN = a * a / Math.Sqrt((a * a * (cosLat * cosLat)) + (b * b * (sinLat * sinLat)));

            double X = (rSubN + height) * cosLat * Math.Cos(longitude);
            double Y = (rSubN + height) * cosLat * Math.Sin(longitude);
            double Z = ((b * b / (a * a) * rSubN) + height) * sinLat;

            return new double[] { X, Y, Z };
        }

        /// <summary>
        /// Converts lat long IN DEGREES and geodetic height (elevation) into DIS XYZ
        /// This algorithm also uses the WGS84 ellipsoid, though you can change the values
        /// of a and b for a different ellipsoid. Adapted from Military Handbook 600008 </summary>
        /// <param name="latitude"> The latitude, IN DEGREES </param>
        /// <param name="longitude"> The longitude, in DEGREES </param>
        /// <param name="height"> The elevation, in meters </param>
        /// <returns> a double array with the calculated X, Y, and Z values, in that order </returns>
        public static double[] getXYZfromLatLonDegrees(double latitude, double longitude, double height) => getXYZfromLatLonRadians(latitude * DEGREES_TO_RADIANS, longitude * DEGREES_TO_RADIANS, height);

        /// <summary>
        /// Rotates 3D vector s about axis n, t amount in RADIANS
        /// <param name="s"> vector to be rotated </param>
        /// <param name="n"> vector to be rotated around</param>
        /// <param name="t"> angle of rotation in DEGREES </param>
        /// <returns> a double[3] array with the rotated vector </returns>
        public static double[] rotateAboutAxis(double[] s, double[] n, double t)
        {
            double st = Math.Sin(t);
            double ct = Math.Cos(t);

            double d0 = (1.0-ct) * (n[0] * n[0] * s[0] + n[0] * n[1] * s[1] +
                                    n[0] * n[2] * s[2]) +
                        ct * s[0] + st * (n[1] * s[2] - n[2] * s[1]);
            double d1 = (1.0 - ct) * (n[0] * n[1] * s[0] + n[1] * n[1] * s[1] +
                                      n[1] * n[2] * s[2]) +
                        ct * s[1] + st * (n[2] * s[0] - n[0] * s[2]);
            double d2 = (1.0 - ct) * (n[0] * n[2] * s[0] + n[1] * n[2] * s[1] +
                                      n[2] * n[2] * s[2]) +
                        ct * s[2] + st * (n[0] * s[1] - n[1] * s[0]);

            return new double[] { d0, d1, d2 };
        }

        static double[] cross(double[] a, double[] b)
        {
            double d0 = a[1] * b[2] - b[1] * a[2];
            double d1 = b[0] * a[2] - a[0] * b[2];
            double d2 = a[0] * b[1] - b[0] * a[1];

            return new double[] { d0, d1, d2 };
        }

        static double dot(double[] a, double[] b)
        {
            double x = (a[0] * b[0] + a[1] * b[1] + a[2] * b[2]);
            return x;
        }

        /// <summary>
        /// Converts Heading, Pitch and Roll to Euler for DIS.
        /// <param name="heading"> heading in DEGREES </param>
        /// <param name="pitch"> pitch in DEGREES </param>
        /// <param name="roll"> roll in DEGREES </param>
        /// <param name="latitude"> latitude in DEGREES </param>
        /// <param name="longitude"> longitude in DEGREES </param> 
        /// <returns> a double[3] array with Psi, Theta, Phi </returns>
        public static double[] headingPitchRollToEuler(double heading, double pitch, double roll, double latitude, double longitude)
        {
            //////////     DEG2RAD    ///////////
            double H    = heading * DEGREES_TO_RADIANS;
            double P    = pitch * DEGREES_TO_RADIANS;
            double R    = roll * DEGREES_TO_RADIANS;
            double lat  = latitude * DEGREES_TO_RADIANS;
            double lon  = longitude * DEGREES_TO_RADIANS;

            //////////    LOCAL NED    //////////
            double[] E0 = { 0.0, 1.0, 0.0 };
            double[] N0 = { 0.0, 0.0, 1.0 };
            double[] me = new double[3];

            // 'E'
            double[] Eprime = rotateAboutAxis(E0, N0, lon);
            me[0] = -Eprime[0];
            me[1] = -Eprime[1];
            me[2] = -Eprime[2];

            // 'N'
            double[] Nprime = rotateAboutAxis(N0, me, lat);

            // 'D'
            double[] Dprime = cross(Nprime, Eprime);

            /////////   ORIENTATION    /////////
            // rotate about D by heading
            double[] N1 = rotateAboutAxis(Nprime, Dprime, H);
            double[] E1 = rotateAboutAxis(Eprime, Dprime, H);
            double[] D1 = (double[])Dprime.Clone();

            // rotate about E1 vector by pitch
            double[] N2 = rotateAboutAxis(N1, E1, P);
            double[] E2 = (double[])E1.Clone();
            double[] D2 = rotateAboutAxis(D1, E1, P);

            // rorate about N2 by roll
            double[] N3 = (double[])N2.Clone();
            double[] E3 = rotateAboutAxis(E2, N2, R);
            double[] D3 = rotateAboutAxis(D2, N2, R);

            // calculate angles from vectors
            double[] x0 = { 1.0, 0.0, 0.0 };
            double[] y0 = { 0.0, 1.0, 0.0 };
            double[] z0 = { 0.0, 0.0, 1.0 };

            double Psi = Math.Atan2(dot(N3, y0), dot(N3, x0));
            double Theta = Math.Atan2((-1 * dot(N3, z0)), Math.Sqrt(Math.Pow(dot(N3, x0), 2) + Math.Pow(dot(N3, y0), 2)));
            double[] y2 = rotateAboutAxis(y0, z0, Psi);
            double[] z2 = rotateAboutAxis(z0, y2, Theta);
            double Phi = Math.Atan2(dot(E3, z2), dot(E3, y2));

            return new double[] { Psi, Theta, Phi };
        }
    }
}
