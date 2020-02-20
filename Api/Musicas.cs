using System;
using System.Collections.Generic;
using System.Linq;

namespace Api
{
    public static class Musicas
    {
    //             private musicas : Array<Musica> = [
    //        ,
    //        new Musica(2,'Another one Bites the Dust','QUEEN', 'The Game', new Date('1980-8-22')),
    //        new Musica(3,'Fortunate Son','Creedence', 'Willy and the Poor Boys'),
    //        new Musica(4,'Sound of Silence','Simon & Garfunkel')
    //      ];

    //      private musicasDaSemana : Array<Musica> = [
    //        new Musica(1,'Best of You','Foo Fighters', 'In Your Honor', new Date('2005-5-30')),
    //new Musica(2,'Stranger Things Have Happened','Foo Fighters', 'Echoes, Silence, Patience & Grace')
        private static List<Musica> ListaMusicas = new List<Musica>() {
            new Musica(1, "Back in Black", "AC/DC", "Back in Black", new DateTime(1980, 7, 25), Classificacao.Favorita),
            new Musica(2,"Another one Bites the Dust","QUEEN", "The Game", new DateTime(1980,8,22), Classificacao.Favorita),
            new Musica(3,"Fortunate Son","Creedence", "Willy and the Poor Boys", classificacao : Classificacao.Favorita),
            new Musica(4,"Sound of Silence","Simon & Garfunkel", classificacao : Classificacao.Favorita),
            new Musica(5,"Best of You","Foo Fighters", "In Your Honor", new DateTime(2005,5,30), Classificacao.DaSemana),
            new Musica(6,"Stranger Things Have Happened","Foo Fighters", "Echoes, Silence, Patience & Grace", classificacao : Classificacao.DaSemana)
        };
        private static List<Musica> BuscarPorClassificacao(Classificacao classificacao) => ListaMusicas.Where(x => x.Classificacao == classificacao).ToList();
        public static void Adicionar(MusicaDto musicaDto)
        {
            var proximoId = ListaMusicas.Max(x => x.Id) + 1;
            if (proximoId <= 0)
                throw new ArgumentException("Erro na geração do Id.");
            var musica = new Musica(proximoId, musicaDto.Nome, musicaDto.Autor, musicaDto.Album, musicaDto.DataLancamento, musicaDto.Classificacao);
            ListaMusicas.Add(musica);
        }
        public static void Remover(int idMusica)
        {
            var musica = BuscarPorId(idMusica);
            if (musica == null)
                throw new ArgumentException("Música não foi encontrada.");
            
            ListaMusicas.Remove(musica);
        }
        public static void Atualizar(MusicaDto musicaDto)
        {
            var musica = ListaMusicas.FirstOrDefault(x => x.Id == musicaDto.Id);
            if(musica != null)
                musica.Atualizar(musicaDto.Nome, musicaDto.Autor, musicaDto.Album, musicaDto.DataLancamento);
        }
        public static List<Musica> BuscarTodas() => ListaMusicas;
        public static Musica BuscarPorId(int id) => ListaMusicas.FirstOrDefault(x => x.Id == id);
        public static List<Musica> BuscarFavoritas() => BuscarPorClassificacao(Classificacao.Favorita);
        public static List<Musica> BuscarDaSemana() => BuscarPorClassificacao(Classificacao.DaSemana);

    }
   
    public class Musica
    {
        public int Id { get; set; }
        public string Nome { get; private set; }
        public string Autor { get; private set; }
        public string Album {get; private set; }
        public DateTime? DataLancamento { get; private set; }
        public Classificacao Classificacao { get; private set; }
        public Musica(int id, string nome, string autor, string album = "", DateTime? dataLancamento = null, Classificacao classificacao = Classificacao.SemClassificacao)
        {
            if (string.IsNullOrWhiteSpace(nome))
                throw new ArgumentException("Nome da música deve ser informado.");
            if (string.IsNullOrWhiteSpace(autor))
                throw new ArgumentException("Autor da música deve ser informado.");
            Id = id;
            Nome = nome;
            Autor = autor;
            Album = album;
            DataLancamento = dataLancamento;
            Classificacao = classificacao;
        }

        public void Atualizar(string nome, string autor, string album = "", DateTime? dataLancamento = null)
        {
            if (string.IsNullOrWhiteSpace(nome))
                throw new ArgumentException("Nome da música deve ser informado.");
            if (string.IsNullOrWhiteSpace(autor))
                throw new ArgumentException("Autor da música deve ser informado.");

            Nome = nome;
            Autor = autor;
            Album = album;
            DataLancamento = dataLancamento;
        }
    }

    public enum Classificacao : short
    {
        SemClassificacao = 0,
        Favorita = 1,
        DaSemana = 2
    }
}
