namespace UberSystem.Dto.Responses
{
    public class DriverResponseModel
    {
        public Guid Id { get; set; }

        public string? UserName { get; set; }

        public string Email { get; set; } = null!;

        /// <summary>
        /// Driver's id from Driver table
        /// </summary>
        public long DriverId { get; set; }

        /// <summary>
        /// Driver's cab type
        /// </summary>
        public string? Type { get; set; }

        /// <summary>
        /// Driver registration number
        /// </summary>
        public string? RegNo { get; set; }

        public DateTime? Dob { get; set; }

        public byte[]? CreateAt { get; set; }
    }
}
