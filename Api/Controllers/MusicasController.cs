using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MusicasController : ControllerBase
    {
        [HttpGet("favoritas")]
        public ActionResult<List<Musica>> GetFavoritas()
        {
            return Musicas.BuscarFavoritas();
        }

        [HttpGet("da-semanda")]
        public ActionResult<List<Musica>> GetDaSemana()
        {
            return Musicas.BuscarDaSemana();
        }

        [HttpGet]
        public ActionResult<List<Musica>> Get()
        {
            return Musicas.BuscarTodas();
        }

        
        [HttpPost]
        public ActionResult Post([FromBody] MusicaDto musicaDto)
        {
            try
            {
                Musicas.Adicionar(musicaDto);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        
        [HttpPut]
        public ActionResult Put([FromBody] MusicaDto musicaDto)
        {
            try
            {
                Musicas.Atualizar(musicaDto);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }


        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                Musicas.Remover(id);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
