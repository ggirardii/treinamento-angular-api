using System.Collections.Generic;

namespace Api
{
    public static class Mapper
    {
        public static MusicaDto MapToDto(Musica musica)
        {
            return new MusicaDto
            {
                Nome = musica.Nome,
                Autor = musica.Autor,
                Album = musica.Album,
                DataLancamento = musica.DataLancamento,
                Classificacao = musica.Classificacao
            };
        }
        public static List<MusicaDto> MapToDto(List<Musica> musicas)
        {
            var musicasDto = new List<MusicaDto>();
            foreach (var musica in musicas)
                musicasDto.Add(MapToDto(musica));
            return musicasDto;
        }
    }
}
