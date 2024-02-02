using Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace FBTarjetaApi6.Services
{
    public class TarjetaCreditoService
    {
        private readonly ApplicationDbContext _applicationBDContext;
        public TarjetaCreditoService(ApplicationDbContext applicationBDContext)
        {
            this._applicationBDContext = applicationBDContext;
        }


        public TarjetaCredito agregarTarjeta(TarjetaCredito _tarjeta)
        {
            int resultado = 0;
            try
            {
                _applicationBDContext.TarjetaCreditos.Add(_tarjeta);
                resultado = _applicationBDContext.SaveChanges();
                if (resultado == 1)
                {
                    int lastId = _applicationBDContext.TarjetaCreditos.Max(x => x.Id);
                    _tarjeta.Id = lastId;
                    return _tarjeta;
                }
                else
                {
                    return new TarjetaCredito();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<TarjetaCredito> ObtenerTarjetas()
        {
            List<TarjetaCredito> resultado = _applicationBDContext.TarjetaCreditos.ToList();
            try
            {
                resultado = _applicationBDContext.TarjetaCreditos.ToList();
            }
            catch (Exception ex)
            {
                string mensaje = ex.Message;
            }
            return resultado;
        }

        public Boolean editarTarjetaCredito(int id, TarjetaCredito n)
        {
            int resultado = 0;
            try
            {
                TarjetaCredito update = _applicationBDContext.TarjetaCreditos.Where(x => x.Id == id).FirstOrDefault();
                if(update != null)
                {
                    update.Titular = n.Titular;
                    update.NumeroTarjeta = n.NumeroTarjeta;
                    update.fechaExpiracion = n.fechaExpiracion;
                    update.CVV = n.CVV;
                    resultado = _applicationBDContext.SaveChanges();
                    if (resultado == 1)
                        return true;
                    else
                        return false;
                }
                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public TarjetaCredito porTarjetaID(int TarjetaId)
        {
            try
            {
                var r = _applicationBDContext.TarjetaCreditos.Where(x => x.Id == TarjetaId).FirstOrDefault();
                return r;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public Boolean eliminarTarjeta(int TarjetaId)
        {
            int resultado = 0;
            try
            {
                TarjetaCredito Tarjeta = _applicationBDContext.TarjetaCreditos.Where<TarjetaCredito>(x => x.Id == TarjetaId).FirstOrDefault();
                _applicationBDContext.Remove(Tarjeta);
                resultado = _applicationBDContext.SaveChanges();
                if (resultado == 1)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
