using Microsoft.EntityFrameworkCore;
using Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using System.Data;

namespace FBTarjetaApi6.Services
{
    public class UsuarioService
    {
        private readonly ApplicationDbContext _applicationBDContext;
        public UsuarioService(ApplicationDbContext applicationBDContext)
        {
            this._applicationBDContext = applicationBDContext;
        }


        public Usuario agregarUsuario(Usuario _usuario)
        {
            int resultado = 0;
            try
            {
                _applicationBDContext.Usuarios.Add(_usuario);
                resultado = _applicationBDContext.SaveChanges();
                if (resultado == 1)
                {
                    int lastId = _applicationBDContext.Usuarios.Max(x => x.id);
                    _usuario.id = lastId;
                    return _usuario;
                }
                else
                {
                    return new Usuario();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Usuario> ObtenerUsuarios()
        {

            var resultado = _applicationBDContext.Usuarios.ToList();
            return resultado;
        }

        public Boolean editarUsuario(int id, Usuario usuario)
        {
            int resultado = 0;
            try
            {
                var update = _applicationBDContext.Usuarios.Where(x => x.id == id).FirstOrDefault();
                if(update != null)
                {
                    update.nombre = usuario.nombre;
                    update.email = usuario.email;
                    update.password = usuario.password;
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


        public List<Usuario> findEmailAndPassword(Usuario usuario)
        {
            try
            {
                IQueryable<Usuario> query;
                query = _applicationBDContext.Usuarios.Where(x => x.email == usuario.email);
                query = query.Where(x => x.password == usuario.password);
                List<Usuario> r = query.ToList();
                return r;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public Usuario porUsuarioID(int UsuarioId)
        {
            try
            {
                IQueryable<Usuario> query = _applicationBDContext.Usuarios.Where(x => x.id == UsuarioId);
                Usuario r = query.ToList().FirstOrDefault();
                return r;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public Boolean eliminarUsuario(int id)
        {
            int resultado = 0;
            try
            {
                Usuario usuario = _applicationBDContext.Usuarios.Where<Usuario>(x => x.id == id).FirstOrDefault();
                _applicationBDContext.Remove(usuario);
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
