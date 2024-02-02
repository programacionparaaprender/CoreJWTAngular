using FBTarjetaApi6.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FBTarjetaApi6.Controllers
{
    [ApiVersion("2.0")]
    [Route("api/[controller]")]
    //[Authorize]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly UsuarioService _usuarioService;
        public UsuarioController(UsuarioService usuarioService)
        {
            this._usuarioService = usuarioService;
        }


        [HttpGet]
        [Route("porUsuarioID/{usuarioID}")]
        [ProducesResponseType(typeof(Usuario), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult porUsuarioID(int usuarioID)
        {
            Usuario resultado = new Usuario();
            try
            {
                resultado = _usuarioService.porUsuarioID(usuarioID);
                if (resultado != null)
                {
                    return Ok(new { message = "El usuario se obtuvo de forma exitosa", data = resultado });
                }
                return BadRequest(new { message = "El usuario no existe" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message, data = resultado });
            }
        }

        // GET: api/<UsuarioController>
        [HttpGet]
        [ProducesResponseType(typeof(Usuario), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Get()
        {
            List<Usuario> resultado = new List<Usuario>();
            try
            {
                resultado = _usuarioService.ObtenerUsuarios();
                return Ok(new { message = "Las usuarios se han obtenido de forma exitosa", data = resultado });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message, data = resultado });
            }
        }

        // GET api/<UsuarioController>/5
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Usuario), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Get(int id)
        {
            Usuario resultado = new Usuario();
            try
            {
                resultado = _usuarioService.porUsuarioID(id);
                if (resultado != null)
                {
                    return Ok(new { message = "El usuario se obtuvo de forma exitosa", data = resultado });
                }
                //return Ok("Prueba de que todo funciona");
                //return HttpResult(200, resultado);
                return BadRequest(new { message = "El usuario no existe" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message, data = resultado });
            }
        }

        // POST api/<UsuarioController>
        [HttpPost]
        [ProducesResponseType(typeof(TarjetaCredito), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Post([FromBody] Usuario _usuario)
        {
            Usuario resultado = new Usuario();
            try
            {
                resultado = _usuarioService.agregarUsuario(_usuario);
                if (resultado.id != 0)
                {
                    //Created
                    return Created("url", new { message = "El usuario fue creado de forma exitosa", data = resultado });
                }

            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
            return BadRequest(new { message = "No se registro", data = resultado });
        }

        // PUT api/<UsuarioController>/5
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(TarjetaCredito), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Put(int id, [FromBody] Usuario _usuario)
        {
            try
            {
                if (id != _usuario.id)
                {
                    return NotFound();
                }
                var resultado = _usuarioService.editarUsuario(id, _usuario);

                if (resultado)
                    return Created("url", new { message = "El usuario fue actualizado de forma exitosa", data = _usuario });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return BadRequest(new { message = "No se actualizo", data = _usuario });
        }

        // DELETE api/<TarjetaController>/5
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(Usuario), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Delete(int id)
        {
            Usuario _tarjeta = new Usuario();
            try
            {
                _tarjeta = _usuarioService.porUsuarioID(id);
                var resultado = _usuarioService.eliminarUsuario(id);
                if (resultado)
                {
                    return Created("url", new { message = "El usuario fue eliminado de forma satisfactoria", data = _tarjeta });
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message, data = _tarjeta });
            }
            return BadRequest(new { message = "No se elimino", data = _tarjeta });
        }
    }
}
