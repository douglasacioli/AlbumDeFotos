namespace AlbumDeFotos.Models
{
    public class UnidadeFuncional
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Status { get; set; }

        // Novas propriedades para coordenadas da planta do andar
        public double CoordenadaXInicio { get; set; }
        public double CoordenadaYInicio { get; set; }
        public double CoordenadaXFim { get; set; }
        public double CoordenadaYFim { get; set; }

     
    }
}
