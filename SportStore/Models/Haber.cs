using System;
using System.ComponentModel.DataAnnotations;

namespace SportStore.Models
{
    public class Haber
    {
        [Key]
        public long HaberId { get; set; }
        public string HaberBasligi { get; set; }
        public string HaberIcerigi { get; set; }
        public DateTime HaberTarihi { get; set; }
    }
}
