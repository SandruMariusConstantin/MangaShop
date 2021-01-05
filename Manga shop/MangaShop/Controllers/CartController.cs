using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MangaShop.Models;

namespace MangaShop.Controllers
{
    public class CartController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        [HttpGet]
        public ActionResult Index()
        {
            List<Cart> cart = db.Carts.ToList();
            if (cart.Count != 0) { 
                ViewBag.Number = cart[0].numberOfproducts;
                ViewBag.Total = cart[0].totalPrice;
                ViewBag.Manga = cart[0].MangaToBuy.ToList();
            }
            return View();
        }

        /*
        [HttpGet]
        public ActionResult ViewOrders()
        {
            List<Cart> orders = db.Orders.ToList();
            ViewBag.Cart = orders;
            return View();
        }
        */

        public ActionResult Add(int? id)
        {
            if (id.HasValue)
            {
                Manga manga = db.Mangas.Find(id);

                List<Cart> carts = db.Carts.ToList();

                if (manga != null)
                {

                    if (carts.Count == 0)
                    {
                        Cart cart = new Cart
                        {
                            numberOfproducts = 1,
                            totalPrice = manga.Price,
                            MangaToBuy = new List<Manga>()
                        };

                        cart.MangaToBuy.Add(manga);

                        db.Carts.Add(cart);
                        db.SaveChanges();

                        return RedirectToAction("Index");
                    }

                    try
                    {
                        if (ModelState.IsValid)
                        {
                            if (TryUpdateModel(carts))
                            {
                                carts[0].numberOfproducts = carts[0].numberOfproducts + 1;
                                carts[0].totalPrice = carts[0].totalPrice + manga.Price;
                                carts[0].MangaToBuy.Add(manga);
                              
                                db.SaveChanges();
                            }
                            return RedirectToAction("Index");
                        }
                    }
                    catch (Exception)
                    {
                    }
                    return RedirectToAction("Index");
                }
                return HttpNotFound("Couldn't find the manga with id " + id.ToString() + "!");
            }
            return HttpNotFound("Missing manga id parameter or the number of how many to buy!");
        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            Manga manga = db.Mangas.Find(id);
            List<Cart> carts = db.Carts.ToList();

            if (manga != null)
            {
                try
                {
                    if (ModelState.IsValid)
                    {
                        if (TryUpdateModel(carts))
                        {
                            carts[0].numberOfproducts = carts[0].numberOfproducts - 1;
                            carts[0].totalPrice = carts[0].totalPrice - manga.Price;
                            carts[0].MangaToBuy.Remove(manga);

                            db.SaveChanges();
                        }
                        return RedirectToAction("Index");
                    }
                }
                catch (Exception)
                {
                }
                return RedirectToAction("Index");
            }
            return HttpNotFound("Couldn't find the manga with id " + id.ToString() + "!");
        }

        public ActionResult Submit()
        {
            List<Cart> carts = db.Carts.ToList();

            //db.Orders.Add(carts[0]);
            db.SaveChanges();

            try
            {
                if (ModelState.IsValid)
                {
                    if (TryUpdateModel(carts))
                    {
                        carts[0].numberOfproducts = 0;
                        carts[0].totalPrice = 0;
                        carts[0].MangaToBuy.Clear();

                        db.SaveChanges();
                    }
                }
            }
            catch (Exception)
            {
            }
               
            return View();
        }
    }
}