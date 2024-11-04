using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace ApplicationForMissingAnimals.Models
{
    public class Animal
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter the animal's microchip")]
        [Display(Name = "Microchip")]
        [StringLength(100)]
        public string Microchip { get; set; }

        [Required(ErrorMessage = "Please enter some content")]
        public string Content { get; set; }

        [Display(Name = "Title")]
        public string Title { get; set; }


        [Required(ErrorMessage = "Please enter the City")]
        public string City { get; set; }

        [Required(ErrorMessage = "Please enter the Street")]
        public string Street { get; set; }

        [Required(ErrorMessage = "Please enter some information")]
        public string Information { get; set; }

        [Required(ErrorMessage = "Please choose type")]
        public string Type { get; set; }


        [Required(ErrorMessage = "Please enter the animal's name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter animal's age")]
        public int Age { get; set; }

        [Required(ErrorMessage = "Please enter description")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Please enter color")]
        public string Color { get; set; }

        [Required(ErrorMessage = "Please choose profile image")]
        public string ProfilePicture { get; set; }

        public Animal()
        {
            Title = Microchip+ " " ;
        }
    }
}
