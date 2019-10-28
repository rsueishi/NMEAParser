using System;
using Ghostware.NMEAParser.Enums;
using Ghostware.NMEAParser.Extensions;
using Ghostware.NMEAParser.NMEAMessages.Base;

namespace Ghostware.NMEAParser.NMEAMessages
{
    public class GphdtMessage : NmeaMessage
    {

        #region Properties

        public double HeadingInDegrees { get; set; }
        public string IndicatesHeadingRelativeToTrueNorth { get; set; }

        #endregion

        #region Message parsing

        public override void Parse(string[] messageParts)
        {
            if (messageParts == null || messageParts.Length < 3)
            {
                throw new ArgumentException("Invalid GPHDT message");
            }
            HeadingInDegrees = messageParts[1].ToDouble();
            IndicatesHeadingRelativeToTrueNorth = messageParts[2];
        }

        #endregion

        public override string ToString()
        {
            return $"HeadingInDegrees {HeadingInDegrees} - IndicatesHeadingRelativeToTrueNorth {IndicatesHeadingRelativeToTrueNorth}";
        }
    }
}
