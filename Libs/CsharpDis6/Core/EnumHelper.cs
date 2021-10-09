// Copyright (c) 1995-2009 held by the author(s).  All rights reserved.
// Redistribution and use in source and binary forms, with or without
// modification, are permitted provided that the following conditions
// are met:
// * Redistributions of source code must retain the above copyright
//    notice, this list of conditions and the following disclaimer.
// * Redistributions in binary form must reproduce the above copyright
//   notice, this list of conditions and the following disclaimer
//   in the documentation and/or other materials provided with the
//   distribution.
// * Neither the names of the Naval Postgraduate School (NPS)
//   Modeling Virtual Environments and Simulation (MOVES) Institute
//   (http://www.nps.edu and http://www.MovesInstitute.org)
//   nor the names of its contributors may be used to endorse or
//   promote products derived from this software without specific
//   prior written permission.
// 
// THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS
// AS IS AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT
// LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS
// FOR A PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL THE
// COPYRIGHT OWNER OR CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT,
// INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING,
// BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES;
// LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER
// CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT
// LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN
// ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE
// POSSIBILITY OF SUCH DAMAGE.
//
// Copyright (c) 2008, MOVES Institute, Naval Postgraduate School. All 
// rights reserved. This work is licensed under the BSD open source license,
// available at https://www.movesinstitute.org/licenses/bsd.html
//
// Author Peter Smith (Naval Air Warfare Center - Training Systems Division) 01/23/2009
// Modified by Zvonko Bostjancic (Blubit d.o.o. - zvonko.bostjancic@blubit.si)

using System;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using OpenDis.Core;
using System.Collections.Generic;

namespace OpenDis.Core
{
    public static class EnumHelper
    {
		#region Static methods (7) 

        public static bool EnumerationForValueExists<T>(int number)
        {
            return Enum.IsDefined(typeof(T), number);
        }

        /// <summary>
        /// Gets the description.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>the description</returns>
        /// <exception cref="InvalidOperationException">if the type parameter is not enum.</exception>
        public static string GetDescription<T>(T value)
        {
            string retVal = string.Empty;

            DescriptionAttribute attr = GetEnumValueAttribute<DescriptionAttribute, T>(value);

            if (attr != null)
            {
                retVal = attr.Description;
            }

            return retVal; 
        }

        /// <summary>
        /// Returns an Enumeration Type from a number passed in
        /// </summary>
        /// <typeparam name="T">Enumeration Type</typeparam>
        /// <param name="number">Enumeration value</param>
        /// <returns>Enumeration of that value</returns>
        /// <exception cref="EnumNotFoundException">if the nuber (parameter) 
        /// value is not found in the enum definition</exception>
        public static T GetEnumerationForValue<T>(int number)
        {
            if (Enum.IsDefined(typeof(T), number) == true)
            {
                return (T)Enum.ToObject(typeof(T), number);
            }
            else
            {
                throw new EnumNotFoundException(string.Format("No enumeration found for value {0} of enumeration {1}", number, typeof(T).Name), typeof(T));
            }
        }

        /// <summary>
        /// Gets the attribute of the enumeration value.
        /// </summary>
        /// <typeparam name="T">Attribute type.</typeparam>
        /// <typeparam name="U">Enumeration type</typeparam>
        /// <param name="value">The value.</param>
        /// <returns>The instance of the attribute or null if the attribute is not found</returns>
        public static T GetEnumValueAttribute<T, U>(U value)
        {
            Type t = typeof(U);

            if (t.IsEnum)
            {
                if (value != null)
                {
                    FieldInfo fieldInfo = typeof(U).GetField(Enum.GetName(typeof(U), value));

                    if (fieldInfo != null)
                    {
                        object[] attributes = fieldInfo.GetCustomAttributes(typeof(T), false);

                        if (attributes != null &&
                           attributes.Length > 0)
                        {
                            return (T)attributes[0];
                        }
                    }
                }
            }
            else
            {
                throw new ArgumentException("Type must be an enum.");
            }

            return default(T);
        }

        /// <summary>
        /// Gets the attribute of the enumeration value.
        /// </summary>
        /// <typeparam name="T">Attribute type.</typeparam>
        /// <typeparam name="U">Enumeration type</typeparam>
        /// <param name="value">The value.</param>
        /// <returns>The instance of the attribute or null if the attribute is not found</returns>
        public static IEnumerable<T> GetEnumValueAttributes<T, U>(U value)
        {
            Type t = typeof(U);

            if (t.IsEnum)
            {
                if (value != null)
                {
                    FieldInfo fieldInfo = typeof(U).GetField(Enum.GetName(typeof(U), value));

                    if (fieldInfo != null)
                    {
                        object[] attributes = fieldInfo.GetCustomAttributes(typeof(T), false);
                        
                        if (attributes != null &&
                           attributes.Length > 0)
                        {
                            return attributes.Cast<T>(); ;
                        }
                    }
                }
            }
            else
            {
                throw new ArgumentException("Type must be an enum.");
            }

            return new T[0];
        }

        /// <summary>
        /// Returns the Description associated with the enumeration
        /// </summary>
        /// <typeparam name="T">The enum type</typeparam>
        /// <param name="value">The enumeration object which has the attribute.</param>
        /// <returns>
        /// The description string of the attribute or string.empty
        /// </returns>
        public static string GetInternetDomainCode<T>(T value)
        {
            string retVal = string.Empty;

            InternetDomainCodeAttribute attr = GetEnumValueAttribute<InternetDomainCodeAttribute, T>(value);

            if (attr != null)
            {
                retVal = attr.InternetDomainCode;
            }

            return retVal;
        }

        /// <summary>
        /// Parses the specified name.
        /// </summary>
        /// <typeparam name="T">The enum type</typeparam>
        /// <param name="value">The string value.</param>
        /// <returns>Enum value.</returns>
        public static T Parse<T>(string value)
        {
            return (T)Enum.Parse(typeof(T), value);
        }

        /// <summary>
        /// Parses the specified value.
        /// </summary>
        /// <typeparam name="T">The enum type</typeparam>
        /// <param name="value">The value.</param>
        /// <param name="ignoreCase">if set to <c>true</c> [ignore case].</param>
        /// <returns>Enum value.</returns>
        public static T Parse<T>(string value, bool ignoreCase)
        {
            return (T)Enum.Parse(typeof(T), value, ignoreCase);
        }

		#endregion Static methods 
    }
}
