namespace AddressInfos
{
    public class AddressInfos
    {
        public Guid AddressInfosId { get; set; }
        public string Street { get; set; }
        public string? Complement { get; set; }
        public string ZipCode { get; set; }
        public string? Neighborhood { get; set; }
        public string City { get; set; }
        public string? StateInitials { get; set; }
        public int? IBGECode { get; set; }
        public int? GIACode { get; set; }
        public string? Unit { get; set; }
    }
}
