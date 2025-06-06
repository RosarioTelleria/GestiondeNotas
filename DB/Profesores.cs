// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AspnetCoreMvcFull.DB
{
    public partial class Profesores
    {
        public Profesores()
        {
            Materias = new HashSet<Materias>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdProfesor { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Especialidad { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }

        public virtual ICollection<Materias> Materias { get; set; }
    }
}
