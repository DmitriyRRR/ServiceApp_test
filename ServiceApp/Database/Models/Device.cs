using System.ComponentModel.DataAnnotations.Schema;

namespace ServiceApp.Database.Models
{
    public class Device
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        [ForeignKey("ClientId")]
        public int ClientId { get; set; } = 0; //temporary, db schemes will be maintance and change
    }
}
