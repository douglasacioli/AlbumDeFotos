namespace AlbumDeFotos.Models
{
    public class UnidadeFuncionalRepository
    {
        public static List<UnidadeFuncional> ObterUnidades()
        {
            return new List<UnidadeFuncional>
    {
        new UnidadeFuncional
        {
            Id = 1,
            Nome = "Unidade 1",
            Status = "Disponível",
            CoordenadaXInicio = 56,
            CoordenadaYInicio = 88,
            CoordenadaXFim = 389,
            CoordenadaYFim = 1058
        },
        new UnidadeFuncional
        {
            Id = 2,
            Nome = "Unidade 2",
            Status = "Ocupado",
            CoordenadaXInicio = 396,
            CoordenadaYInicio = 1150,  // Ajustado para a posição correta
            CoordenadaXFim = 1407,
            CoordenadaYFim = 1350      // Ajustado para a altura correta
        },
        new UnidadeFuncional
        {
            Id = 3,
            Nome = "Unidade 3",
            Status = "Bloqueado",
            CoordenadaXInicio = 1401,
            CoordenadaYInicio = 1095,
            CoordenadaXFim = 1599,
            CoordenadaYFim = 45
        }
    };
        }


        //public static void AtualizarCoordenadas(int id, double xInicio, double yInicio, double xFim, double yFim)
        //{
        //    var unidade = unidades.FirstOrDefault(u => u.Id == id);
        //    if (unidade != null)
        //    {
        //        unidade.CoordenadaXInicio = xInicio;
        //        unidade.CoordenadaYInicio = yInicio;
        //        unidade.CoordenadaXFim = xFim;
        //        unidade.CoordenadaYFim = yFim;
        //    }

        //    // Adicionar código para salvar no banco de dados se estiver utilizando um banco real
        //}
    }
}
