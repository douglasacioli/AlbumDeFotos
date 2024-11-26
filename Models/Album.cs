using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace AlbumDeFotos.Models
{
    public class Album
    {
        public int  AlbumId { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        [StringLength(50, ErrorMessage = "Máximo 50 caractéres")]
        public string Destino { get; set; }
        public string FotoTopo { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        [Required(ErrorMessage = "Campo Obrigatório")]
        public DateTime Inicio { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        [Required(ErrorMessage = "Campo Obrigatório")]
        public DateTime Fim { get; set; }

        [ValidateNever]
        public ICollection<Imagem> Imagens { get; set; }
    }
}
