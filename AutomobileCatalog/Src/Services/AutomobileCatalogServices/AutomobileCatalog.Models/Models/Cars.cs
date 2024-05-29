namespace AutomobileCatalog.Models.Models
{
    public class Cars
    {
        public int Id { get; set; }
        public string Modelo { get; set; }
        public string Descripción { get; set; }
        public decimal? Precio { get; set; }
        public decimal? Kilometraje { get; set; }

        public int BrandId { get; set; }
        public Brands Brands { get; set; }
    }
}
