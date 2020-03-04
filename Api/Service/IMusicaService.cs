using System.Collections.Generic;

namespace Api
{
    public interface IMusicaService
    {
        int Adicionar(MusicaDto musicaDto);
        void Remover(int idMusica);
        void Atualizar(MusicaDto musicaDto);
        List<MusicaDto> BuscarTodas();
        List<MusicaDto> BuscarFavoritas();
        List<MusicaDto> BuscarDaSemana();
    }
}
