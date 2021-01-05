using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MangaShop.Models.MyValidation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;
using MangaShop.Models.MyValidation;

namespace MangaShop.Models
{
    public class Manga
    {
        public int MangaId { get; set; }

        [MinLength(2, ErrorMessage = "Title cannot be less than 2!"),
        MaxLength(200, ErrorMessage = "Title cannot be more than 200!")]
        public string Title { get; set; }

        [MinLength(3, ErrorMessage = "Author cannot be less than 3!"),
        MaxLength(50, ErrorMessage = "Author cannot be more than 50!")]
        public string Author { get; set; }

        [MinLength(2, ErrorMessage = "Summary cannot be less than 2!"),
        MaxLength(5000, ErrorMessage = "Summary cannot be more than 5000!")]
        public string Summary { get; set; }

        [PriceValidator]
        public double Price { get; set; }

        public string Image { get; set; }

        [PageValidator]
        public int NoOfPages { get; set; }

        [VolumeValidator]
        public int VolumeNumber { get; set; }

        // one-to-many relationship
        public int PublisherId { get; set; }
        public virtual Publisher Publisher { get; set; }

        // many-to-many relationship
        public virtual ICollection<Genre> Genres { get; set; }

        // dropdown lists
        public IEnumerable<SelectListItem> PublisherList { get; set; }

        // checkboxes list
        [NotMapped]
        public List<CheckBoxViewModel> GenresList { get; set; }
    }
}