namespace UberSystem.Dto.Helpers
{
    public static class HaversineFormula
    {
        public static double CalculateDistance(
            double sourceLatitude,
            double sourceLongitude,
            double destinationLatitude,
            double destinationLongitude)
        {
            const double R = 6371; // Radius of the earth in km
            var srcLatRad = Converter.DegreesToRadians(sourceLatitude);
            var destLatRad = Converter.DegreesToRadians(destinationLatitude);

            var deltaLat = Converter.DegreesToRadians(destinationLatitude - sourceLatitude);
            var deltaLon = Converter.DegreesToRadians(destinationLongitude - sourceLongitude);
            var a = Math.Sin(deltaLat / 2) * Math.Sin(deltaLat / 2) +
                Math.Cos(srcLatRad) * Math.Cos(destLatRad) *
                Math.Sin(deltaLon / 2) * Math.Sin(deltaLon / 2);

            var c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));
            return R * c; // Distance in kilometers
        }
    }
}
