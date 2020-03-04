using System;

namespace Api
{
    public class MusicaDto
    {
        public int? Id { get; set; }
        public string Nome { get; set; }
        public string Autor { get; set; }
        public string Album { get; set; }
        public DateTime? DataLancamento { get; set; }
        public Classificacao Classificacao { get; set; }
    }
}
