using FBTarjetaApi6.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.Models;

namespace FBTarjetaApi6.Controllers
{
    [ApiVersion("2.0")]
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class MenuController : ControllerBase
    {
        private readonly MenuService _menuService;
        public MenuController(MenuService menuService)
        {
            this._menuService = menuService;
        }

        // GET: api/<MenuController>
        [HttpGet]
        [ProducesResponseType(typeof(Menu), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Get()
        {
            List<Menu> resultado = new List<Menu>();
            try
            {
                resultado = _menuService.ObtenerMenus();
                return Ok(new { message = "Los menus se han obtenido de forma exitosa", data = resultado });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message, data = resultado });
            }
        }
    }
}
