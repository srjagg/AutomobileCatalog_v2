namespace AutomobileCatalog.Models.ModelsDto
{
    public class CarsDto
    {
        public int Id { get; set; }
        public string Modelo { get; set; }
        public string Descripcion { get; set; }
        public decimal? Precio { get; set; }
        public decimal? Kilometraje { get; set; }
        public int BrandId { get; set; }
    }
}
