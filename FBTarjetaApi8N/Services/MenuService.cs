using Models.Models;

namespace FBTarjetaApi6.Services
{
    public class MenuService
    {
        private readonly ApplicationDbContext _applicationBDContext;
        public MenuService(ApplicationDbContext applicationBDContext)
        {
            this._applicationBDContext = applicationBDContext;
        }

        public List<Menu> ObtenerMenus()
        {

            var resultado = _applicationBDContext.Menus.ToList();
            return resultado;
        }
    }
}
