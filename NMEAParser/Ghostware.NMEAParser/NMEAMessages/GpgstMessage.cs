using System;
using Ghostware.NMEAParser.Enums;
using Ghostware.NMEAParser.Extensions;
using Ghostware.NMEAParser.NMEAMessages.Base;

namespace Ghostware.NMEAParser.NMEAMessages
{
    public class GpgstMessage : NmeaMessage
    {

        #region Properties

        public double UTCofPositionFix { get; set; }
        public double RMSValueOfThePseudorangeRediduals { get; set; }
        public double ErrorEllipseSemiMajorAxis { get; set; }
        public double ErrorEllipseSemiMinorAxis { get; set; }
        public double ErrorEllipseOrientationDegrees { get; set; }
        public double Latitude1SigmaError { get; set; }
        public double Longitude1SigmaError { get; set; }
        public double Height1SigmaError { get; set; }

        #endregion

        #region Message parsing

        public override void Parse(string[] messageParts)
        {
            if (messageParts == null || messageParts.Length < 9)
            {
                throw new ArgumentException("Invalid GPGST message");
            }
            UTCofPositionFix = messageParts[1].ToDouble();
            RMSValueOfThePseudorangeRediduals = messageParts[2].ToDouble();
            ErrorEllipseSemiMajorAxis = messageParts[3].ToDouble();
            ErrorEllipseSemiMinorAxis = messageParts[4].ToDouble();
            ErrorEllipseOrientationDegrees = messageParts[5].ToDouble();
            Latitude1SigmaError = messageParts[6].ToDouble();
            Longitude1SigmaError = messageParts[7].ToDouble();
            Height1SigmaError = messageParts[8].ToDouble();
        }

        #endregion

        public override string ToString()
        {
            return $"Latitude1SigmaError {Latitude1SigmaError} - Longitude1SigmaError {Longitude1SigmaError} - Height1SigmaError {Height1SigmaError}";
        }
    }
}
