using Microsoft.AspNetCore.Mvc;
using NewsLetters.Data;

namespace NewsLetters.Controllers
{
    public class NewsController : Controller
    {
        private readonly ApplicationDbContext _db;

        public NewsController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<News> objNewsList = _db.News;
            return View(objNewsList);
        }

        //GET
        public IActionResult Create()
        {
            return View();
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(News obj)
        {
            if (ModelState.IsValid)
            {
                _db.News.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);

        }
        //GET
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var newsFromDb = _db.News.Find(id);
            //var newsFromDb = _db.News.FirstOrDefault(u=>u.Id==id);
            //var newsFromDbSingle = _db.News.SingleOrDefault(u => u.Id == id);

            if (newsFromDb == null)
            {
                return NotFound();
            }
            return View(newsFromDb);
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(News obj)
        {
            if (ModelState.IsValid)
            {
                _db.News.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);

        }

        //GET
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var newsFromDb = _db.News.Find(id);
            //var newsFromDb = _db.News.FirstOrDefault(u=>u.Id==id);
            //var newsFromDbSingle = _db.News.SingleOrDefault(u => u.Id == id);

            if (newsFromDb == null)
            {
                return NotFound();
            }
            return View(newsFromDb);
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(int? id)
        {
            var obj = _db.News.Find(id);
            if (obj == null)
            {
                return NotFound();
            }

            _db.News.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
