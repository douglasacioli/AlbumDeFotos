

namespace AlbumDeFotos.Models
{
    public class MapaLeitoStatusViewModel
    {
        public string Andar { get; set; }
        public string ImagemAndar { get; set; }  // Caminho para a imagem da planta do andar
        public List<UnidadeFuncional> UnidadesFuncionais { get; set; }
    }
}
