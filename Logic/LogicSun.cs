using CoordinateSharp;
using GeoTimeZone;
using SunAPI.Models;
using System;
using System.Globalization;
using System.Threading;
using TimeZoneConverter;

namespace SunAPI.Logic
{
    public class LogicSun
    {
        public OutputDto calculateSunrise(InputDto input)
        {
            Coordinate c = createCoordinateObj(input);

            return new OutputDto { Hour = c.CelestialInfo.SunRise.ToString(), Type = "Sunrise", Machine = Program.name };
        }

        public OutputDto calculateSunset(InputDto input)
        {
            Coordinate c = createCoordinateObj(input);

            return new OutputDto { Hour = c.CelestialInfo.SunSet.ToString(), Type = "Sunset", Machine = Program.name };
        }

        public Coordinate createCoordinateObj(InputDto input) 
        {
            DateTime date = DateTime.ParseExact(input.date, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            string tz = TimeZoneLookup.GetTimeZone(input.Latitude, input.Longitude).Result;
            TimeSpan ts = TZConvert.GetTimeZoneInfo(tz).BaseUtcOffset;
            Coordinate c = new Coordinate(input.Latitude, input.Longitude, date);
            c.Offset = ts.Hours;

            Thread.Sleep(2000);

            return c;
        }
    }
}
