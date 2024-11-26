namespace AlbumDeFotos.Models
{
    public class Leito
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Status { get; set; }
        public int UnidadeFuncionalId { get; set; }

        // Novas propriedades para coordenadas do leito na planta
        public double CoordenadaX { get; set; }  // Coordenada X do leito
        public double CoordenadaY { get; set; }  // Coordenada Y do leito
    }

}
