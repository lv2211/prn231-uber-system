using System.Text.Json.Serialization;
using UberSystem.Domain.Enums;

namespace UberSystem.Dto.Requests
{
    public class TripRequestModel
    {
        public long? CustomerId { get; set; }

        public long? DriverId { get; set; }

        //public long? PaymentId { get; set; }

        public TripStatus Status { get; set; }

        public double? SourceLatitude { get; set; }

        public double? SourceLongitude { get; set; }

        public double? DestinationLatitude { get; set; }

        public double? DestinationLongitude { get; set; }

        [JsonIgnore]
        public byte[] CreateAt { get; set; } = null!; 
    }
}
