using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MangaShop.Models;


namespace MangaShop.Controllers
{
    public class MangaController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        [HttpGet]
        public ActionResult Index()
        {
            List<Manga> mangas = db.Mangas.ToList(); 
            ViewBag.Mangas = mangas;
            return View();
        }

        [HttpGet]
        public ActionResult Products()
        {
            List<Manga> mangas = db.Mangas.ToList();
            ViewBag.Mangas = mangas;
            return View();
        }

        public ActionResult Details(int? id)
        {
            if (id.HasValue)
            {
                Manga manga = db.Mangas.Find(id);
                if (manga != null)
                {
                    return View(manga);
                }
                return HttpNotFound("Couldn't find the manga with id " + id.ToString() + "!");
            }
            return HttpNotFound("Missing manga id parameter!");
        }


        [HttpGet]
        public ActionResult New()
        {
            Manga manga = new Manga();
            manga.PublisherList = GetAllPublishers();
            manga.GenresList = GetAllGenres();
            manga.Genres = new List<Genre>();
            return View(manga);
        }

        [HttpPost]
        public ActionResult New(Manga mangaRequest)
        {
            mangaRequest.PublisherList = GetAllPublishers();

            // memoram intr-o lista doar genurile care au fost selectate
            var selectedGenres = mangaRequest.GenresList.Where(b => b.Checked).ToList();
            try
            {
                if (ModelState.IsValid)
                {
                    mangaRequest.Genres = new List<Genre>();
                    for (int i = 0; i < selectedGenres.Count(); i++)
                    {
                        // unei manga pe care vrem sa o adaugam in baza de date ii 
                        // asignam genurile selectate 
                        Genre genre = db.Genres.Find(selectedGenres[i].Id);
                        mangaRequest.Genres.Add(genre);
                    }
                    db.Mangas.Add(mangaRequest);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(mangaRequest);
            }
            catch (Exception e)
            {
                var msg = e.Message;
                return View(mangaRequest);
            }
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id.HasValue)
            {
                Manga manga = db.Mangas.Find(id);
                manga.PublisherList = GetAllPublishers();
                manga.GenresList = GetAllGenres();

                foreach (Genre checkedGenre in manga.Genres)
                {   // iteram prin genurile care erau atribuite unei manga inainte de momentul accesarii formularului
                    // si le selectam/bifam  in lista de checkbox-uri
                    manga.GenresList.FirstOrDefault(g => g.Id == checkedGenre.GenreId).Checked = true;
                }
                if (manga == null)
                {
                    return HttpNotFound("Coludn't find the manga with id " + id.ToString() + "!");
                }
                return View(manga);
            }
            return HttpNotFound("Missing book id parameter!");
        }

        [HttpPut]
        public ActionResult Edit(int id, Manga mangaRequest)
        {
            mangaRequest.PublisherList = GetAllPublishers();

            // preluam acea manga pe care vrem sa o modificam din baza de date
            Manga manga = db.Mangas.Include("Publisher").SingleOrDefault(b => b.MangaId.Equals(id));

            // memoram intr-o lista doar genurile care au fost selectate din formular
            var selectedGenres = mangaRequest.GenresList.Where(b => b.Checked).ToList();
            try
            {
                if (ModelState.IsValid)
                {
                    if (TryUpdateModel(manga))
                    {
                        manga.Title = mangaRequest.Title;
                        manga.Author = mangaRequest.Author;
                        manga.Summary = mangaRequest.Summary;
                        manga.NoOfPages = mangaRequest.NoOfPages;
                        manga.PublisherId = mangaRequest.PublisherId;
                        manga.Price = mangaRequest.Price;
                        manga.Image = mangaRequest.Image;
                        manga.VolumeNumber = mangaRequest.VolumeNumber;

                        manga.Genres.Clear();
                        manga.Genres = new List<Genre>();

                        for (int i = 0; i < selectedGenres.Count(); i++)
                        {
                            // cartii pe care vrem sa o editam ii asignam genurile selectate 
                            Genre genre = db.Genres.Find(selectedGenres[i].Id);
                            manga.Genres.Add(genre);
                        }
                        db.SaveChanges();
                    }
                    return RedirectToAction("Index");
                }
                return View(mangaRequest);
            }
            catch (Exception)
            {
                return View(mangaRequest);
            }
        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            Manga manga = db.Mangas.Find(id);
            if (manga != null)
            {
                db.Mangas.Remove(manga);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return HttpNotFound("Couldn't find the manga with id " + id.ToString() + "!");
        }

        [NonAction]
        public List<CheckBoxViewModel> GetAllGenres()
        {
            var checkboxList = new List<CheckBoxViewModel>();
            foreach (var genre in db.Genres.ToList())
            {
                checkboxList.Add(new CheckBoxViewModel
                {
                    Id = genre.GenreId,
                    Name = genre.Name,
                    Checked = false
                });
            }
            return checkboxList;
        }

        [NonAction]
        public IEnumerable<SelectListItem> GetAllPublishers()
        {
            var selectList = new List<SelectListItem>();
            foreach (var publisher in db.Publishers.ToList())
            {
                selectList.Add(new SelectListItem
                {
                    Value = publisher.PublisherId.ToString(),
                    Text = publisher.Name
                });
            }
            return selectList;
        }
    }
}