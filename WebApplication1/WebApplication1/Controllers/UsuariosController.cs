using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Web.Http;
using System.Web.Http.Description;
using WebApplication1.ModelosDataCenter;
using WebApplication1.ViewModels;


namespace WebApplication1.Controllers
{
    public class UsuarioController :ApiController
    {
        private Model1 db = new Model1();

        [HttpPost]
        [Route("api/Usuarios/Login")]
        [ResponseType(typeof(Usuario))]
        public IHttpActionResult LoginMovil([FromBody] login login)
        {


            login.Password = GetMd5Hash(login.Password);

            var usuario = db.Usuarios.Where(u =>
                                            u.NickName.ToUpper() == login.NickName.ToUpper() &&
                                            u.Password == login.Password
                                            ).FirstOrDefault();
            if (usuario == null)
            {
                return NotFound();
            }

            if (usuario.TieneDerecho(1000))
            {
                UsuarioLoginViewModel usuarioLogin = new UsuarioLoginViewModel(usuario);

                return Ok(usuarioLogin);
        }

            return Ok(new
            {
                Result = true,
                Message = "El usuario no tiene permiso para acceder a la aplicación de Mis Oficios"
            });

        } 



        private string GetMd5Hash(string Valor)
        {
            MD5 md5 = MD5.Create();
            byte[] hash = md5.ComputeHash(Encoding.ASCII.GetBytes(Valor));
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("x2"));
            }
            return sb.ToString();
        } // GetMd5Hash
    }
}