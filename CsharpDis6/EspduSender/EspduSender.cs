using System;
using System.Net;
using System.Net.Sockets;
using OpenDis.Core;
using OpenDis.Dis1998;

namespace EspduSender
{
    internal static class EspduSender
    {
        private static IPAddress mcastAddress;
        private static int mcastPort, broadcastPort;
        private static Socket mcastSocket;
        private static MulticastOption mcastOption;
        private static IPEndPoint endPoint;

        private static void MulticastOptionProperties()
        {
            Console.WriteLine("Current multicast group is: " + mcastOption.Group);
            Console.WriteLine("Current multicast local address is: " + mcastOption.LocalAddress);
        }

        private static void JoinMulticast()
        {
            try
            {
                mcastSocket = new Socket(AddressFamily.InterNetwork,
                                         SocketType.Dgram,
                                         ProtocolType.Udp);

                //Console.Write("Enter the local IP address: ");  //In case multiple NICs

                //IPAddress localIPAddr = IPAddress.Parse(Console.ReadLine());
                var localIPAddr = IPAddress.Any;

                var localEP = new IPEndPoint(localIPAddr, 0);  //Don't need to fully join, so can use on same computer as port already in use by receive.

                mcastSocket.Bind(localEP);

                // Define a MulticastOption object specifying the multicast group 
                // address and the local IPAddress.
                // The multicast group address is the same as the address used by the server.
                mcastOption = new MulticastOption(mcastAddress, localIPAddr);

                mcastSocket.SetSocketOption(SocketOptionLevel.IP,
                                            SocketOptionName.AddMembership,
                                            mcastOption);

                endPoint = new IPEndPoint(mcastAddress, mcastPort);

                // Display MulticastOption properties.
                MulticastOptionProperties();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        private static void StartMulticast()
        {
            try
            {
                mcastSocket = new Socket(AddressFamily.InterNetwork,
                                         SocketType.Dgram,
                                         ProtocolType.Udp);

                //Console.Write("Enter the local IP address: ");

                //IPAddress localIPAddr = IPAddress.Parse(Console.ReadLine());
                var localIPAddr = IPAddress.Parse("172.19.36.86");

                //IPAddress localIP = IPAddress.Any;
                var localEP = (EndPoint)new IPEndPoint(localIPAddr, mcastPort);

                mcastSocket.Bind(localEP);

                // Define a MulticastOption object specifying the multicast group 
                // address and the local IPAddress.
                // The multicast group address is the same as the address used by the server.
                mcastOption = new MulticastOption(mcastAddress, localIPAddr);

                mcastSocket.SetSocketOption(SocketOptionLevel.IP,
                                            SocketOptionName.AddMembership,
                                            mcastOption);

                endPoint = new IPEndPoint(mcastAddress, mcastPort);

                // Display MulticastOption properties.
                MulticastOptionProperties();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        private static void StartBroadcast()  //Used to connect to DISMap or other broadcast receivers
        {
            try
            {
                mcastSocket = new Socket(AddressFamily.InterNetwork,
                                         SocketType.Dgram,
                                         ProtocolType.Udp);

                // Define a BroadcastOption object 
                mcastSocket.SetSocketOption(SocketOptionLevel.Socket,
                                            SocketOptionName.Broadcast,
                                            1);
                var localIPAddr = IPAddress.Parse("172.19.36.255");

                endPoint = new IPEndPoint(IPAddress.Broadcast, broadcastPort);
                //endPoint = new IPEndPoint(localIPAddr, broadcastPort);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        private static void SendMessages(byte[] buf)
        {
            try
            {
                //Send multicast packets to the listener.                
                mcastSocket.SendTo(buf, endPoint);

                Console.WriteLine("Sent multicast packets......./n");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        public static void Main(string[] args)
        {
            mcastAddress = IPAddress.Parse("239.1.2.3");
            mcastPort = 62040;
            broadcastPort = 62040;  //3000 for DisMapper default
            var espdu = new EntityStatePdu();  //Could use factory but easier this way

            //Alcatraz
            const double lat = 37.827;
            double lon = -122.425;

            // Configure socket.
            //JoinMulticast();   //Used to talk to C# receiver.  No need to connect as we are just sending multicast
            //StartMulticast();  //Least preffered
            StartBroadcast();      //Used for DisMapper      

            //Setup EntityState PDU 
            espdu.ExerciseID = 1;
            var eid = espdu.EntityID;
            eid.Site = 0;
            eid.Application = 1;
            eid.Entity = 2;
            // Set the entity type. SISO has a big list of enumerations, so that by
            // specifying various numbers we can say this is an M1A2 American tank,
            // the USS Enterprise, and so on. We'll make this a tank. There is a 
            // separate project elsehwhere in this project that implements DIS 
            // enumerations in C++ and Java, but to keep things simple we just use
            // numbers here.
            var entityType = espdu.EntityType;
            entityType.EntityKind = 1;      // Platform (vs lifeform, munition, sensor, etc.)
            entityType.Country = 255;              // USA
            entityType.Domain = 1;          // Land (vs air, surface, subsurface, space)
            entityType.Category = 1;        // Tank
            entityType.Subcategory = 1;     // M1 Abrams
            entityType.Specific = 3;            // M1A2 Abrams

            for (int i = 0; i < 100; i++)
            {
                lon += (i / 1000.0);

                double[] disCoordinates = CoordinateConversions.getXYZfromLatLonDegrees(lat, lon, 0.0);

                var location = espdu.EntityLocation;
                location.X = disCoordinates[0];
                location.Y = disCoordinates[1];
                location.Z = disCoordinates[2];
                espdu.Timestamp = DisTime.DisRelativeTimestamp;

                //Prepare output
                var dos = new DataOutputStream(Endian.Big);
                espdu.MarshalAutoLengthSet(dos);

                // Transmit broadcast messages
                SendMessages(dos.ConvertToBytes());
                Console.Write("Message sent with TimeStamp [{0}] Time Of[{1}]", espdu.Timestamp, espdu.Timestamp >> 1);

                //Thread.Sleep(1000);
                Console.Write("Hit Enter for Next PDU.  Ctrl-C to Exit");
                Console.ReadLine();
            }

            mcastSocket.Close();
        }
    }
}