using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.ModelosDataCenter;

namespace WebApplication1.ViewModels
{
    public class UsuarioLoginViewModel
    {
        private ModelosDataCenter.Usuario usuario;

        public Guid IdUsuario { get; set; }

        public Guid IdPersona { get; set; }

        public Guid IdArea { get; set; }

        public string NickName { get; set; }

        public string Password { get; set; }

        public string NombreCompleto { get; set; }

        public string Correo { get; set; }

        public string Puesto { get; set; }

        public int Status { get; set; }

        public int Rol { get; set; }

        public List<UsuarioPermisoViewModel> Permisos { get; set; }

        public UsuarioLoginViewModel(Usuario Usuario)
        {
            if (Usuario != null)
            {
                IdUsuario = Usuario.IdUsuario;
                IdPersona = Usuario.IdPersona;
                IdArea = Usuario.IdArea ?? Guid.Empty;
                NickName = Usuario.NickName;
                Password = Usuario.Password;
                Correo = Usuario.Correo;
                Puesto = Usuario.Puesto;
                Status = (int)Usuario.Status;
                Rol = (int)Usuario.Rol;

                if (Usuario.Persona != null)
                {
                    NombreCompleto = Usuario.Persona.NombreCompleto();
                }
                else { NombreCompleto = string.Empty; }

                //  El rango de permisos especificado es para la aplicación de MIS OFICIOS, para otros rangos de permisos, ver la libreria Zapotlan.Administracion.Usuarios.Derechos en su código fuente
                Permisos = new List<UsuarioPermisoViewModel>();
                List<int> permisoEnteros = new List<int>();

                permisoEnteros = Usuario.Derechos.Select(d => d.IdDerecho).Where(d => d >= 1000 && d <= 1012).ToList();

                foreach (Grupo grupo in Usuario.Grupos)
                {
                    permisoEnteros = grupo.Derechos.Select(d => d.IdDerecho).Where(d => d >= 1000 && d <= 1012).ToList().Union(permisoEnteros).ToList();
                }
                permisoEnteros.Sort();
                foreach(int item in permisoEnteros)
                {
                    Permisos.Add(new UsuarioPermisoViewModel(item));
                }
            }
        }
        
        //public UsuarioLoginViewModel(ModelosDataCenter.Usuario usuario)
        //{
        //    this.usuario = usuario;
        //}
    }

    public class UsuarioPermisoViewModel
    {
        public int numeroPermiso { get; set; }
        public UsuarioPermisoViewModel(int Item)
        { numeroPermiso = Item; }
    }

}