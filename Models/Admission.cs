using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WCS_Test_Backend.Models
{
    public class Admission
    {
        public long Id { get; set; }
        
        [Required]
        [StringLength(20)]
        public string Name { get; set; }
        
        [Required]
        [StringLength(20)]
        public string SureName { get; set; }
        
        [Required]
        [Range(1, 99)]
        public int Age { get; set; }

        [Required]
        [ValidHouse]
        public string House{ get; set; }
    }

    // Para validar que la casa sea una de las cuatro: 
    // "Gryffindor", "Hufflepuff", "Ravenclaw", "Slytherin"
    // Se crea un nuevo atributo que valide que el string en House sea una de 
    // esas.
    // En este ejemplo se usa un arreglo hecho a mano, pero se puede sustituir 
    // por cualquier iterable y se podría cargar de, por ejemplo, una tabla 
    // "Houses" en la base de datos para que la validación sea completamente 
    // dinámica.
    public class ValidHouseAttribute: ValidationAttribute
    {
        string[] houses = {"Gryffindor", "Hufflepuff", "Ravenclaw", "Slytherin"};
        
        public string GetErrorMessage() =>
            $"El nombre de la casa tiene que ser uno de los siguientes: {string.Join(", ", houses)}";
        
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var admission = (Admission)validationContext.ObjectInstance;
            if (!houses.Contains(admission.House)) return new ValidationResult(GetErrorMessage());
            return ValidationResult.Success;
        }
    }
}