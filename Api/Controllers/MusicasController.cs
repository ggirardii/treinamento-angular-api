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
        public ActionResult<List<MusicaDto>> GetFavoritas()
        {
            var resultado = Musicas.BuscarFavoritas();
            return Mapper.MapToDto(resultado);
        }

        [HttpGet("da-semanda")]
        public ActionResult<List<MusicaDto>> GetDaSemana()
        {
            var resultado = Musicas.BuscarDaSemana();
            return Mapper.MapToDto(resultado);
        }

        [HttpGet]
        public ActionResult<List<MusicaDto>> Get()
        {
            var resultado = Musicas.BuscarTodas();
            return Mapper.MapToDto(resultado);
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
