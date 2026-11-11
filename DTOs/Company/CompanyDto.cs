namespace Company.DTOs.Company
{
    public class CompanyDto
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string Code { get; set; } = null!;

        public string RegistrationNumber { get; set; } = null!;

        public char LegalIdentifier { get; set; }

        public string EconomicCode { get; set; } = null!;

        public string PhoneNumber { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string Address { get; set; } = null!;

        public string? WebSite { get; set; } = null!;

        public bool IsActive { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }
    }
}
