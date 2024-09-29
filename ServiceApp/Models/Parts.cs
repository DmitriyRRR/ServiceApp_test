using System.ComponentModel.DataAnnotations.Schema;

namespace ServiceApp.Models
{
    public class Parts
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        // one-to many devices-parts?
    }
}
