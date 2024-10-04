using System.ComponentModel.DataAnnotations;

namespace UberSystem.Dto.Requests
{
    /// <summary>
    /// Feedback request model for customer to give feedback to driver
    /// </summary>
    public class FeedbackRequestModel
    {
        public long CustomerId { get; set; }

        public long DriverId { get; set; }
        
        public long TripId { get; set; }
        
        [Required(ErrorMessage = "Trip rating is required!")]
        [Range(1, 5, ErrorMessage = "Rating must be from 1 to 5 stars!")]
        public int TripRating { get; set; }

        /// <summary>
        /// Customer feedback with short text
        /// </summary>
        [StringLength(300, ErrorMessage = "Maximum length of feedback is 300 characters!")]
        public string? Feedback { get; set; }
    }
}
