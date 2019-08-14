using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;
using System.Linq;

namespace WebApplication1.ModelosDataCenter
{
    
    [Table("Usuarios")]
    public partial class Usuario
    {
        
        [Key]
        public Guid IdUsuario { get; set; }

        public Guid IdPersona { get; set; }

        public Guid? IdArea { get; set; }

        public Guid? IdEmpleado { get; set; }

        public Guid? IdUsuarioJefe { get; set; }

        [StringLength(25)]
        public string NickName { get; set; }

        [StringLength(32)]
        public string Password { get; set; }

        [StringLength(255)]
        public string Correo { get; set; }

        [StringLength(150)]
        public string Puesto { get; set; }

        public UsuarioStatusTipo Status { get; set; }

        public UsuarioRolTipo Rol { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime FechaAlta { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? FechaVigencia { get; set; }

        [StringLength(255)]
        public string ArchivoCartaResponsabilidad { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime FechaActualizacion { get; set; }

        public Guid IdUsuarioActualizacion { get; set; }

        // VIRTUAL

        public virtual Persona Persona { get; set; }

        public virtual Area Area { get; set; }

        // public virtual Empleado Empleado { get; set; }

        [ForeignKey("IdUsuarioJefe")]
        public virtual Usuario Jefe { get; set; }

        public virtual ICollection<Grupo> Grupos { get; set; }

        public virtual ICollection<Derecho> Derechos { get; set; }

        //[NotMapped]
        //public ICollection<GrupoDerechos> GrupoPermisos { get; set; }
        //[NotMapped]
        //public ICollection<UsuarioDerechos> UsuarioPermisos { get; set; }
        //[NotMapped]
        //[StringLength(150)]
        //public string NombreCompleto { get; set; }
        
        public bool TieneDerecho(int derecho)
        {
            if (Derechos != null)
            {
                var total = (from d in Derechos where d.IdDerecho == derecho select d).Count();

                if (total == 0)
                {
                    if (Grupos != null)
                    {
                        foreach (Grupo grupo in Grupos)
                        {
                            if (grupo.TieneDereho(derecho)) {
                                return true;
                            }
                        }
                    }
                }
                else {
                    return true;
                }
            }

            return false;
        } // TieneDerecho
        
    } // Usuario

    public enum UsuarioStatusTipo
    {
        Ninguno,
        Activo,
        Baja
    }

    public enum UsuarioRolTipo
    {
        Ninguno,
        Presidente,
        Regidor,
        Director,
        Jefe,
        Empleado
    }
}
