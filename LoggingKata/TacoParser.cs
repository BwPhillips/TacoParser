using System;

namespace LoggingKata
{
    /// <summary>
    /// Parses a POI file to locate all the Taco Bells
    /// </summary>
    public class TacoParser
    {
        readonly ILog logger = new TacoLogger();

        // Converts Meters to Miles
        public double ConvertMetersToMiles(double meters)
        {
            return Math.Round(meters / 1609.344, 2);
        }

        public ITrackable Parse(string line)
        {
            // Take your line and use line.Split(',') to split it up into an array of strings, separated by the char ','
            var cells = line.Split(',');

            TacoBell tacoBell = new TacoBell();

            // If your array.Length is less than 3, something went wrong
            if (cells.Length < 3)
            {
                return null;// Log that and return null
            }
            // Do not fail if one record parsing fails, return null
            // TODO Implement

            // grab the latitude from your array at index 0
            string lat = cells[0];
            // grab the longitude from your array at index 1
            string lon = cells[1];
            // grab the name from your array at index 2
            string storeName = cells[2];


            // Your going to need to parse your string as a `double`
            // which is similar to parsing a string as an `int`
            tacoBell.Name = storeName;

            double.TryParse(lat, out double doubleLat);
            double.TryParse(lon, out double doubleLon);

            tacoBell.Location = new Point { Longitude = doubleLon, Latitude = doubleLat };

            return tacoBell;

            // You'll need to create a TacoBell class

            // that conforms to ITrackable

            // Then, you'll need an instance of the TacoBell class
            // With the name and point set correctly

            // Then, return the instance of your TacoBell class
            // Since it conforms to ITrackable

        }
    }
}