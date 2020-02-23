using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using System;

namespace Api.Configurations
{
    public class StartupFilter : IStartupFilter
    {
        public Action<IApplicationBuilder> Configure(Action<IApplicationBuilder> next)
        {
            return builder =>
            {
                var musicaService = (IMusicaService)builder.ApplicationServices.GetService(typeof(IMusicaService));
                musicaService.Adicionar(new MusicaDto() {
                    Nome = "Back in Black",
                    Autor = "AC/DC",
                    Album = "Back in Black",
                    DataLancamento = new DateTime(1980, 7, 25),
                    Classificacao = Classificacao.Favorita
                });
                musicaService.Adicionar(new MusicaDto() {
                    Nome = "Another one Bites the Dust",
                    Autor = "QUEEN",
                    Album = "The Game",
                    DataLancamento = new DateTime(1980, 8, 22),
                    Classificacao = Classificacao.Favorita
                });
                musicaService.Adicionar(new MusicaDto() {
                    Nome = "Fortunate Son",
                    Autor = "Creedence",
                    Album = "Willy and the Poor Boys",
                    Classificacao = Classificacao.Favorita
                });
                musicaService.Adicionar(new MusicaDto() {
                    Nome = "Sound of Silence",
                    Autor = "Simon & Garfunkel",
                    Classificacao = Classificacao.Favorita
                });
                musicaService.Adicionar(new MusicaDto() {
                    Nome = "Best of You",
                    Autor = "Foo Fighters",
                    Album = "In Your Honor",
                    DataLancamento = new DateTime(2005, 5, 30),
                    Classificacao = Classificacao.DaSemana
                });
                musicaService.Adicionar(new MusicaDto() {
                    Nome = "Stranger Things Have Happened",
                    Autor = "Foo Fighters",
                    Album = "Echoes, Silence, Patience & Grace",
                    Classificacao = Classificacao.DaSemana
                });

                next(builder);
            };
        }
    }
}
