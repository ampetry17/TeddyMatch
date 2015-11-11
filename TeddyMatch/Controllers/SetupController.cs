using System.Web.Mvc;
using TeddyMatch.Model;
using TeddyMatch.TMObjectLibrary;

namespace TeddyMatch.Controllers
{
    public class SetupController : Controller
    {
        // GET: Setup
        public ActionResult Index()
        {
            return View(TeddyMatchModel.InitializeModelObject(Session["Model"]));
        }

        // GET: Setup/Create
        public ActionResult Create()
        {
            MatchWord Word = new MatchWord();
            return View(Word);
        }

        // POST: Setup/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                TeddyMatchModel.Add(Session, new MatchWord { Word = Request.Form["Word"], ImageUrl = Request.Form["ImageURL"] });
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Setup/Edit/5
        public ActionResult Edit(string id)
        {
            return View();
        }

        // POST: Setup/Edit/5
        [HttpPost]
        public ActionResult Edit(string id, FormCollection collection)
        {
            try
            {
                TeddyMatchModel.Update(Session, new MatchWord {Word = Request.Form["Word"], ImageUrl = Request.Form["ImageURL"]}, id);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // POST: Setup/Delete/5
        [HttpPost]
        public ActionResult Delete(string id, FormCollection collection)
        {
            try
            {
                TeddyMatchModel.Delete(Session, id);

                return RedirectToAction("Index");
            }
            catch
            {
                return RedirectToAction("Index");
            }
        }
    }
}
