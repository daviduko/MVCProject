using System.ComponentModel.DataAnnotations;
using System.Timers;

namespace MVCProject.Models.ViewModels
{
    public class InsertAnimalViewModel
    {
        [Required(ErrorMessage = "El nombre del animal es obligatorio")]
        [StringLength(50, ErrorMessage = "El nombre no puede tener más de 50 caracteres")]
        [Display(Name = "Nombre del Animal")]
        public string NombreAnimal { get; set; }

        [Required(ErrorMessage = "La raza del animal es obligatorio")]
        [StringLength(50, ErrorMessage = "La raza no puede tener más de 50 caracteres")]
        [Display(Name = "Raza")]
        public string Raza {  get; set; }
        
        [Required(ErrorMessage = "Debe seleccionar un tipo de animal")]
        [Display(Name = "Tipo de Animal")]
        public int RIdTipoAnimal { get; set; }

        [Display(Name = "Fecha de Nacimiento")]
        [DataType(DataType.Date, ErrorMessage = "Debe ingresar una fecha válida")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime? FechaNacimiento { get; set; }
        public List<TipoAnimal> TiposDeAnimal { get; set; } = new List<TipoAnimal>();
    }
}
