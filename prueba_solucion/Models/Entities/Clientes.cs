using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace prueba_solucion.Models.Entities.Clientes
{
    [Table("clientes")]
    public class ClientesEntity
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Required]
        [Column("nombre")]
        [StringLength(255)]
        public string ? Nombre { get; set; }

        [Required]
        [Column("telefono")]
        [StringLength(15)]
        public string ? Telefono { get; set; }

        [Required]
        [Column("correo")]
        [StringLength(255)]
        public string ? Correo { get; set; }

        [Required]
        [Column("nit")]
        [StringLength(20)]
        public string ? Nit { get; set; }

        [Column("direccion")]
        public string ? Direccion { get; set; }

        [Required]
        [Column("fechasys")]
        public DateTime FechaSys { get; set; } = DateTime.Now;

        [Required]
        [Column("fecha_nacimiento")]
        public DateTime FechaNacimiento { get; set; }

        [Required]
        [Column("estatus")]
        [StringLength(10)]
        public string Estatus { get; set; } = "activo";
    }
}
