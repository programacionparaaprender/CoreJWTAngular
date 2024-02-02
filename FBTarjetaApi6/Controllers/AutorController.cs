using Microsoft.AspNetCore.Mvc;
using Models.Models;
using FBTarjetaApi6.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace FBTarjetaApi6.Controllers
{
    [ApiVersion("2.0")]
    [Route("api/[controller]")]
    [ApiController]
    public class AutorController : ControllerBase
    {
        private readonly AutorService _autorService;
        public AutorController(AutorService noticiaService)
        {
            this._autorService = noticiaService;
        }
        [HttpPost]
        [Route("agregar")]
        [ProducesResponseType(typeof(Autor), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult agregar([FromBody] Autor _autor)
        {
            try
            {
                var resultado = _autorService.agregarAutor(_autor);
                if (resultado)
                    return Ok(resultado);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return BadRequest();
        }

        [HttpPut]
        [Route("editar")]
        [ProducesResponseType(typeof(Autor), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult editar([FromBody] Autor _autor)
        {
            try
            {
                //_noticia.NoticiaId = id;
                var resultado = _autorService.editarAutor(_autor);
                //return Ok("Prueba de que todo funciona");
                //return HttpResult(200, resultado);
                if (resultado)
                    return Ok(resultado);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return BadRequest();
        }


        [HttpGet]
        [Route("porAutorID/{autorID}")]
        [ProducesResponseType(typeof(Autor), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult porNoticiaID(int autorID)
        {
            try { 
            var resultado = _autorService.porAutorID(autorID);
            //return Ok("Prueba de que todo funciona");
            //return HttpResult(200, resultado);
            return Ok(resultado);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("listadoDeAutores")]
        [ProducesResponseType(typeof(Autor), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult listadoDeAutores()
        {
            try
            {
                //_noticia.NoticiaId = id;
                var resultado = _autorService.listadoDeAutores();
                //return Ok("Prueba de que todo funciona");
                //return HttpResult(200, resultado);
                return Ok(resultado);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("eliminar/{autorID}")]
        [ProducesResponseType(typeof(Autor), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult eliminar(int autorID)
        {
            try
            {
                //_noticia.NoticiaId = id;
                var resultado = _autorService.eliminarAutor(autorID);
                //return Ok("Prueba de que todo funciona");
                //return HttpResult(200, resultado);
                if (resultado)
                    return Ok(resultado);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return BadRequest();
        }

    }
}
