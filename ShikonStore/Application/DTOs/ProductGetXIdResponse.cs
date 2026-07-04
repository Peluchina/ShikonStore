namespace ShikonStore.Application.DTOs
{
    public class ProductGetXIdResponse
    {
        public int IdProducto { get; set; }
        public string? NombreProducto { get; set; }
        public string? Categoria { get; set; }
        public string? Descripcion { get; set; }
        public int Cantidad { get; set; }
        public decimal Precio { get; set; }
        public bool Estado { get; set; }
    }
}
