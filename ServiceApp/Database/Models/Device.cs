using System.ComponentModel.DataAnnotations.Schema;

namespace ServiceApp.Database.Models
{
    public class Device
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public string? Description { get; set; }

        public List<Part> Parts { get; set; } = new List<Part>();

        [ForeignKey("ClientId")]
        public int ClientId { get; set; } = 0; //temporary, db schemes will be maintance and change
    }
}
