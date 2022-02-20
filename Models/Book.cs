using System;
using System.ComponentModel.DataAnnotations;

namespace BookCatalog.Models
{
    public class Book
    {
        public int Id { get; set; }

        [Display(Name="Tytuł")]
        [Required(ErrorMessage = "Tytuł nie może być pusty!")]
        [MaxLength(200)]
        public string Title { get; set; }

        [Display(Name = "Rok publikacji")]
        [Required(ErrorMessage = "Proszę podać datę publikacji!")]
        public DateTime PublishDate { get; set; }

        [Required]
        [Range(1,5000, ErrorMessage = "Nie przechowujemy książek grubszych niż 5000 stron!")]
        [Display(Name = "Liczba stron")]
        public int NumberOfPages { get; set; }

        [Required(ErrorMessage = "Proszę podać numer katalogowy!")]
        [Display(Name = "Numer katalogowy")]
        public string CatalogNumber { get; set; }

        [Display(Name = "Wypożyczony?")]
        public bool IsRented { get; set; }
    }
}
