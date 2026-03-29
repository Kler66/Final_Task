namespace Final_Task
{
    public class UserData
    {
        public string FirstName { get; set; } = "Name";

        public string LastName { get; set; } = "Last";

        public string Email { get; set; } = $"user_{Guid.NewGuid().ToString("N").Substring(0, 8)}@test.com";

        public string Address { get; set; } = "Address";

        public string City { get; set; } = "City";

        public string RegionState { get; set; } = "Conwy";

        public string ZIPCode { get; set; } = "1010";

        public int Country { get; set; } = 94;

        public string LoginName { get; set; } = $"user_{Guid.NewGuid().ToString("N").Substring(0, 8)}";

        public string Password { get; set; } = "Open";

    }
}
