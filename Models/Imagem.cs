using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace AlbumDeFotos.Models
{
    public class Imagem
    {
        public int ImagemId { get; set; }
        [ValidateNever]
        public string Link { get; set; }
        public int AlbumId{ get; set; }
        [ValidateNever]
        public Album Album { get; set; }
    }
}
