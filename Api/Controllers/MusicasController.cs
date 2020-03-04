using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MusicasController : ControllerBase
    {
        private readonly IMusicaService _musicaService;
        public MusicasController(IMusicaService musicaService)
        {
            _musicaService = musicaService;
        }

        [HttpGet("favoritas")]
        public ActionResult<List<MusicaDto>> GetFavoritas()
        {
            return _musicaService.BuscarFavoritas();
        }

        [HttpGet("da-semana")]
        public ActionResult<List<MusicaDto>> GetDaSemana()
        {
            return _musicaService.BuscarDaSemana();
        }

        [HttpGet]
        public ActionResult<List<MusicaDto>> Get()
        {
            return _musicaService.BuscarTodas();
        }

        
        [HttpPost]
        public ActionResult Post([FromBody] MusicaDto musicaDto)
        {
            try
            {
                var musicaId = _musicaService.Adicionar(musicaDto);
                return Ok(musicaId);
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
                _musicaService.Atualizar(musicaDto);
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
                _musicaService.Remover(id);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
