using System;
using System.ComponentModel.DataAnnotations;
/*Este archivo define cómo luce un cliente. Los campos [Required] indican que ese campo es obligatorio.*/
namespace IZUMI.Clientes.Shared.Models
{
    public class Cliente
    {
        public int Id { get; set; }

        [Required]
        public string TipoDocumento { get; set; }

        [Required]
        public string NumeroDocumento { get; set; }

        [Required]
        public DateTime FechaNacimiento { get; set; }

        [Required]
        public string PrimerNombre { get; set; }

        public string SegundoNombre { get; set; }

        [Required]
        public string PrimerApellido { get; set; }

        public string SegundoApellido { get; set; }

        [Required]
        public string Direccion { get; set; }

        [Required]
        public string Celular { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string PlanPreferencia { get; set; }
    }
}
