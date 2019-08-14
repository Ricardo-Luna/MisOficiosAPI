namespace WebApplication1.ModelosDataCenter
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Data.Entity.Spatial;

    [Table("Grupos")]
    public partial class Grupo
    {
       
        [Key]
        public Guid IdGrupo { get; set; }

        [StringLength(50)]
        public string Nombre { get; set; }

        [StringLength(250)]
        public string Descripcion { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? FechaActualizacion { get; set; }

        public Guid? IdUsuarioActualizacion { get; set; }

        // VIRTUAL

        public virtual ICollection<Derecho> Derechos { get; set; }
        
        public virtual ICollection<Usuario> Usuarios { get; set; }

        // METODOS

        public bool TieneDereho(int derecho)
        {
            if (Derechos != null)
            {
                var total = (from d in Derechos where d.IdDerecho == derecho select d).Count();

                if (total > 0)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
