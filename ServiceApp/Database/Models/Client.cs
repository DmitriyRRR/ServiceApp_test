namespace ServiceApp.Database.Models
{
    public class Client
    {
        public int Id { get; set; }
        public required string Name { get; set; }

        public List<Device> Devices { get; set; } =new List<Device>();
    }
}
