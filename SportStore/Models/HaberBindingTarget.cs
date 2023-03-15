using System;
using System.ComponentModel.DataAnnotations;

namespace SportStore.Models
{
    public class HaberBindingTarget
    {
        [Required]
        public string HaberBasligi { get; set; }

        public string HaberIcerigi { get; set; }

        public DateTime HaberTarihi { get; set; }


        public Haber ToHaber() => new Haber()
        {
            HaberBasligi = this.HaberBasligi,
            HaberIcerigi = this.HaberIcerigi,
            HaberTarihi = this.HaberTarihi,
         
        };
    }
}
