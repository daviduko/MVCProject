namespace MVCProject.Models.ViewModels
{
    public class DetailAnimalViewModel
    {
        public Animal AnimalDetail { get; set; } = new Animal();
        public List<TipoAnimal> TiposDeAnimal { get; set; } = new List<TipoAnimal>();
    }
}
