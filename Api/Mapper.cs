using System.Collections.Generic;
using System.Linq;

namespace Api
{
    public static class Mapper
    {
        public static MusicaDto MapToDto(Musica musica)
            => new MusicaDto
            {
                Nome = musica.Nome,
                Autor = musica.Autor,
                Album = musica.Album,
                DataLancamento = musica.DataLancamento,
                Classificacao = musica.Classificacao
            };
        public static List<MusicaDto> MapToDto(List<Musica> musicas) => musicas.Select(x => MapToDto(x)).ToList();
    }
}
