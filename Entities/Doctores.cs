using System;
using System.ComponentModel.DataAnnotations;

namespace CRUD_Students_POO2.Entities
{
    public class Doctores

    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "El nombre del doctor es requerido")]
        [StringLength(35, MinimumLength = 3, ErrorMessage = "La longitud del nombre debe ser entre 5 y 35 caracteres")]
        public string Name { get; set; }

        [Required(ErrorMessage = "El apellido del doctor es requerido")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "La edad del doctor es requerida")]
        [Range(25, 75, ErrorMessage = "La edad debe estar entre 25 y 75 años")]
        public int Age { get; set; }

        [Required(ErrorMessage = "La especialidad del doctor es requerida")]
        public string specialism { get; set; }

        [Required(ErrorMessage = "El número de teléfono del doctor es requerido")]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "El número de teléfono debe tener 10 dígitos")]
        public int Tel { get; set; }
        public long Cel { get; set; }

        [Required(ErrorMessage = "La dirección del doctor es requerida")]
        public string address { get; set; }
    }
}