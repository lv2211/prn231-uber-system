namespace UberSystem.Dto.Helpers
{
    /// <summary>
    /// Converter helper
    /// </summary>
    public static class Converter
    {
        public static double DegreesToRadians(double degrees)
        {
            return degrees * Math.PI / 180;
        }
    }
}
