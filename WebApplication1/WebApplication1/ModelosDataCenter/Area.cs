namespace WebApplication1.ModelosDataCenter
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Areas")]
    public partial class Area
    {
        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        //public Area()
        //{
        //    Areas1 = new HashSet<Area>();
        //}

        [Key]
        public Guid IdArea { get; set; }

        public Guid? IdAreaPadre { get; set; }

        // public Guid? IdAreaOrigen { get; set; }

        [StringLength(25)]
        public string Clave { get; set; }

        [StringLength(10)]
        public string Abreviacion { get; set; }

        [StringLength(100)]
        public string Nombre { get; set; }

        [StringLength(100)]
        public string NombreNomina { get; set; }

        [StringLength(100)]
        public string Cargo { get; set; }

        [StringLength(100)]
        public string Responsable { get; set; }

        [StringLength(100)]
        public string Ubica { get; set; }

        [StringLength(100)]
        public string Descripcion { get; set; }

        public int Activo { get; set; }

        public int? Estatus { get; set; }

        public int Tipo { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? FechaAlta { get; set; }

        public Guid IdUsuarioActualizacion { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime FechaActualizacion { get; set; }

        // VIRTUAL

        [ForeignKey("IdAreaPadre")]
        public virtual Area AreaPadre { get; set; }

        [ForeignKey("IdAreaPadre")]
        public virtual ICollection<Area> AreasHijo { get; set; }
    }
}
