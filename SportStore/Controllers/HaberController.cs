using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SportStore.Models;
using System.Linq;

namespace SportStore.Controllers
{
    public class HaberController : Controller
    {
        private IHaberRepository haberRepository;
        public HaberController(IHaberRepository haberRepository)
        {
            this.haberRepository = haberRepository;
        }
        [HttpGet("/Haber/Index")]
        public IActionResult Index()
        {
           var haberler= haberRepository.Haberler;
            return View(haberler);
        }
        [HttpGet("/Haber/HaberDetaylari/{id}")]
        public IActionResult HaberDetaylari(int id)
        {
            //var result = _context.Set<Duyuru>().Find(duyuru_id);
            var haber = haberRepository.Haberler.FirstOrDefault(x=> x.HaberId==id);
            return View(haber);
        }
        //[HttpGet]
        //public IActionResult HaberDetaylari()
        //{
        //    //var result = _context.Set<Duyuru>().Find(duyuru_id);
        //    var haber = haberRepository.Haberler.FirstOrDefault(x => x.HaberId == id);
        //    return View();
        //}
    }
}
