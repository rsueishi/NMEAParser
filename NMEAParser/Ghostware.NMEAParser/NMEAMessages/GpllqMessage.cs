using System;
using Ghostware.NMEAParser.Enums;
using Ghostware.NMEAParser.Extensions;
using Ghostware.NMEAParser.NMEAMessages.Base;

namespace Ghostware.NMEAParser.NMEAMessages
{
    public class GpllqMessage : NmeaMessage
    {
        #region Properties

        public string UTCtimeOfPosition { get; set; }
        public string UTCdate { get; set; }
        public double GridEasting { get; set; }
        public string GridEastingUnits { get; set; }
        public double GridNorthing { get; set; }
        public string GridNorthingUnits { get; set; }
        public int GPSQuality { get; set; }
        public int NumberOfSatellites { get; set; }
        public double PositionQuality { get; set; }
        public double Height { get; set; }
        public string HeightUnits { get; set; }

        #endregion

        #region Message parsing

        public override void Parse(string[] messageParts)
        {
            if (messageParts == null || messageParts.Length < 12)
            {
                throw new ArgumentException("Invalid GPGST message");
            }
            UTCtimeOfPosition = messageParts[1];
            UTCdate = messageParts[2];
            GridEasting = messageParts[3].ToDouble();
            GridEastingUnits = messageParts[4];
            GridNorthing = messageParts[5].ToDouble();
            GridNorthingUnits = messageParts[6];
            GPSQuality = messageParts[7].ToInteger();
            NumberOfSatellites = messageParts[8].ToInteger();
            PositionQuality = messageParts[9].ToDouble();
            Height = messageParts[10].ToDouble();
            HeightUnits = messageParts[11];
        }

        #endregion

        public override string ToString()
        {
            return $"GPSQuality {GPSQuality} - NumberOfSatellites {NumberOfSatellites} - PositionQuality {PositionQuality}";
        }
    }
}
