using System;
using System.Collections.Generic;
using System.Linq;

namespace Api
{
    public class MusicasService : IMusicaService
    {
        private static List<Musica> ListaMusicas = new List<Musica>();
        private List<Musica> BuscarPorClassificacao(Classificacao classificacao) => ListaMusicas.Where(x => x.Classificacao == classificacao).ToList();
        public void Adicionar(MusicaDto musicaDto)
        {
            var musica = new Musica(musicaDto.Nome, musicaDto.Autor, musicaDto.Album, musicaDto.DataLancamento, musicaDto.Classificacao);
            ListaMusicas.Add(musica);
        }
        public void Remover(int idMusica)
        {
            var musica = BuscarPorId(idMusica);
            if (musica == null)
                throw new ArgumentException("Música não foi encontrada.");
            
            ListaMusicas.Remove(musica);
        }
        public void Atualizar(MusicaDto musicaDto)
        {
            var musica = BuscarPorId(musicaDto.Id);
            if (musica == null)
                throw new ArgumentException("Música não foi encontrada.");

            musica.Atualizar(musicaDto.Nome, musicaDto.Autor, musicaDto.Album, musicaDto.DataLancamento);
        }
        public List<MusicaDto> BuscarTodas() => Mapper.MapToDto(ListaMusicas);
        public Musica BuscarPorId(int id) => ListaMusicas.FirstOrDefault(x => x.Id == id);
        public List<MusicaDto> BuscarFavoritas() => Mapper.MapToDto(BuscarPorClassificacao(Classificacao.Favorita));
        public List<MusicaDto> BuscarDaSemana() => Mapper.MapToDto(BuscarPorClassificacao(Classificacao.DaSemana));

    }
}
