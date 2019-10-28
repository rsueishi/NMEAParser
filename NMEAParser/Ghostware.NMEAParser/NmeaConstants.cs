using System;
using System.Collections.Generic;
using Ghostware.NMEAParser.Exceptions;
using Ghostware.NMEAParser.NMEAMessages;

namespace Ghostware.NMEAParser
{
    public static class NmeaConstants
    {
        private static readonly Dictionary<string, Type> TypeDictionary = new Dictionary<string, Type>
        {
            {"GPGGA", typeof(GpggaMessage)},
            {"GNGGA", typeof(GpggaMessage)},
            {"GPGST", typeof(GpgstMessage)},
            {"GNGST", typeof(GpgstMessage)},
            {"GPLLQ", typeof(GpllqMessage)},
            {"GPHDT", typeof(GphdtMessage)},
            {"GNHDT", typeof(GphdtMessage)},
            {"GPRMC", typeof(GprmcMessage)},
            {"GPVTG", typeof(GpvtgMessage)},
            {"GPGSA", typeof(GpgsaMessage)},
            {"GNGSA", typeof(GpgsaMessage)}
        };

        /// <summary>
        /// Returns the correct class type of the message.
        /// </summary>
        /// <param name="typeName">The type name given.</param>
        /// <returns>The class type.</returns>
        /// <exception cref="UnknownTypeException">Given if the type is unkown.</exception>
        public static Type GetClassType(string typeName)
        {
            Type result;
            TypeDictionary.TryGetValue(typeName, out result);

            if (result == null)
            {
                throw new UnknownTypeException();
            }

            return result;
        }
    }
}
