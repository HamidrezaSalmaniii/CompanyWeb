namespace Company.DTOs.Company
{
    public class CreateCompanyDto
    {
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
    }
}
