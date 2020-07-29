using System;
using System.Linq;
using System.IO;
using GeoCoordinatePortable;

namespace LoggingKata
{
    class Program
    {
        static readonly ILog logger = new TacoLogger();
        const string csvPath = "TacoBell-US-AL.csv";

        static void Main(string[] args)
        {
            logger.LogInfo("Log initialized");

            var lines = File.ReadAllLines(csvPath);

            logger.LogInfo($"Lines: {lines[0]}");

            var parser = new TacoParser();

            var locations = lines.Select(parser.Parse).ToArray();

            // TODO:  Find the two Taco Bells in Alabama that are the furthest from one another.
            // HINT:  You'll need two nested forloops

            // DON'T FORGET TO LOG YOUR STEPS

            // Now, here's the new code

            // Create two `ITrackable` variables with initial values of `null`. These will be used to store your two taco bells that are the furthest from each other.
            ITrackable locA = null;
            ITrackable locB = null;
            // Create a `double` variable to store the distance
            double distance = 0;
            double maxDistance = 0;


            // Include the Geolocation toolbox, so you can compare locations: `using GeoCoordinatePortable;`
            // Do a loop for your locations to grab each location as the origin (perhaps: `locA`)
            // Create a new corA Coordinate with your locA's lat and long
            foreach (var line in locations)
            {
                GeoCoordinate cordA = new GeoCoordinate()
                {
                    Latitude = line.Location.Latitude,
                    Longitude = line.Location.Longitude
                };

                // Now, do another loop on the locations with the scope of your first loop, so you can grab the "destination" location (perhaps: `locB`)
                // Create a new Coordinate with your locB's lat and long

                foreach (var line2 in locations)
                {

                    GeoCoordinate cordB = new GeoCoordinate()
                    {
                        Latitude = line2.Location.Latitude,
                        Longitude = line2.Location.Longitude
                    };

                    // Now, compare the two using `.GetDistanceTo()`, which returns a double
                    distance = cordA.GetDistanceTo(cordB);

                    // If the distance is greater than the currently saved distance, update the distance and the two `ITrackable` variables you set above
                    if (maxDistance <= distance)
                    {
                        locA = line;
                        locB = line2;

                        maxDistance = distance;
                    }
                }
            }

            // Once you've looped through everything, you've found the two Taco Bells furthest away from each other.

            Console.WriteLine($"The Taco Bells furthest away from each other are {locA.Name} and {locB.Name} at {parser.ConvertMetersToMiles(maxDistance)} miles apart");
            Console.ReadLine();

        }
    }
}