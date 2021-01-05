using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MangaShop.Models
{
    public class Cart
    {
        public int CartId { get; set; }

        public int numberOfproducts { get; set; }

        public double totalPrice { get; set; }

        public virtual ICollection<Manga> MangaToBuy { get; set; }
    }
}