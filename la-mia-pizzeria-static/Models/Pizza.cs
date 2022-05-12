using la_mia_pizzeria_static.Utils.Validation;
using System.ComponentModel.DataAnnotations;




namespace la_mia_pizzeria_static.Models
{
    public class Pizza
    {
        [Required(ErrorMessage = "Il campo nome è obbligatorio")]
        [StringLength(20, ErrorMessage = "Il nome non può avere più di 20 caratteri")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Il campo descrizione è obbligatorio")]
        [MoreThanFiveWords]
        public string Description { get; set; }

        [Required(ErrorMessage = "l'URL dell'immagine è obbligatorio")]
        [Url(ErrorMessage = "Mi dispiace l'URL inserito non è valido")]
        public string Image { get; set; }

        [Required(ErrorMessage = "Il prezzo della pizza è obbligatorio")]
        public double Prezzo { get; set; }

        public Pizza()
        {

        }

        public Pizza(string name, string description, string image, double prezzo)
        {
            Name = name;
            Description = description;
            Image = image;
            Prezzo = prezzo;
        }
    }
}
