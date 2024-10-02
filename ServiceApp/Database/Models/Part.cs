using System.ComponentModel.DataAnnotations.Schema;

namespace ServiceApp.Database.Models
{
    public class Part
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        [ForeignKey("DeviceId")]
        public int DeviceId { get; set; } = 0;
    }
}
