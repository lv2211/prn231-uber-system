namespace UberSystem.Dto.Requests
{
    /// <summary>
    /// Request model for customers to request a driver for a trip
    /// </summary>
    public class DriverRequestModel
    {
        public long CustomerId { get; set; }

        public double SourceLatitude { get; set; }

        public double SourceLongitude { get; set; }
        
        public double DestinationLatitude { get; set; }
        
        public double DestinationLongitude { get; set; }
    }
}
