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


//namespace WebApplication1.Controllers
//{
//    public class Usuarios1Controller : ApiController
//    {
//        private Model1 db = new Model1();

//        [HttpPost]
//        [Route("api/Usuarios/Login2")]
//        [ResponseType(typeof(vwUsuario))]
//        public IHttpActionResult LoginMovil([FromBody] login login)
//        {


//            login.Password = GetMd5Hash(login.Password);

//            var usuario = db.vwUsuarios.Where(u =>
//                                            u.NickName.ToUpper() == login.NickName.ToUpper() &&
//                                            u.Password == login.Password
//                                            && u.Status == 1).FirstOrDefault();
//            if (usuario == null)
//            {
//                return BadRequest("El nombre de usuario o contraseña invalidos");
//            }

//            var grupoUsuarios = db.vwGrupoUsuarios.Where(gp => gp.IdUsuario == usuario.IdUsuario).ToList();

//            List<vwGruposDerecho> tmpGrupoDerechos = new List<vwGruposDerecho>();
//            foreach (vwGrupoUsuario item in grupoUsuarios)
//            {
//                var grupoDerecho = db.vwGruposDerechos.Where(g => g.IdGrupo == item.IdGrupo).ToList();

//                foreach (vwGruposDerecho itemGrupoDerechos in grupoDerecho)
//                {
//                    if (itemGrupoDerechos.IdDerecho >= 130 && itemGrupoDerechos.IdDerecho <= 135)
//                    {
//                        Permiso permiso = new Permiso();
//                        permiso.IdPermiso = itemGrupoDerechos.IdGrupo;
//                        permiso.Numero = itemGrupoDerechos.IdDerecho;
//                        usuario.Permisos.Add(permiso);
//                    }

//                }

//            }

//            var usuarioDerechos = db.UsuarioDerechos.Where(ud => ud.IdUsuario == usuario.IdUsuario).ToList();
//            List<UsuarioDerecho> tmpUsuariosDerechos = new List<UsuarioDerecho>();
//            foreach (UsuarioDerecho item in usuarioDerechos)
//            {
//                if (item.IdDerecho >= 130 && item.IdDerecho <= 135)
//                {
//                    Permiso permiso = new Permiso();
//                    permiso.IdPermiso = item.IdUsuario;
//                    permiso.Numero = item.IdDerecho;
//                    usuario.Permisos.Add(permiso);
//                }

//            }

//            var persona = db.Personas.Where(p => p.IdPersona == usuario.IdPersona).First();
//            usuario.NombreCompleto = persona.NombreCompleto ?? null;
//            var area = db.vwAreas.Where(a => a.IdArea == usuario.IdArea).First();
//            usuario.NombreArea = area.Nombre ?? null;


//            return Ok(usuario);

//        }

//        private string GetMd5Hash(string Valor)
//        {
//            MD5 md5 = MD5.Create();
//            byte[] hash = md5.ComputeHash(Encoding.ASCII.GetBytes(Valor));
//            StringBuilder sb = new StringBuilder();
//            for (int i = 0; i < hash.Length; i++)
//            {
//                sb.Append(hash[i].ToString("x2"));
//            }
//            return sb.ToString();
//        }
//    }
//}