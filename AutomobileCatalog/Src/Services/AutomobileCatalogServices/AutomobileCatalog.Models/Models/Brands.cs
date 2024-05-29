namespace AutomobileCatalog.Models.Models
{
    public class Brands
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }

        public ICollection<Cars>? Cars { get; set; }
    }
}
