using System;

namespace Api
{
    public class Musica
    {
        public int Id { get; set; }
        public string Nome { get; private set; }
        public string Autor { get; private set; }
        public string Album { get; private set; }
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
