using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using NSI_CRK.DAL;
using NSI_CRK.Models;

namespace NSI_CRK.Controllers
{
    public class AbsencesController : Controller
    {
        private IGenericRepository<Absence> repository = null;
        private IAbsencesRepository absences_repository = null;

        public AbsencesController()
        {
            this.repository = new GenericRepository<Absence>();
            this.absences_repository = new AbsencesRepository();
        }
        public AbsencesController(IGenericRepository<Absence> repository)
        {
            this.repository = repository;
        }
        public AbsencesController(AbsencesRepository repository)
        {
            this.absences_repository = repository;
        }

        // GET: Absences
        public ActionResult Index(string SearchString = null)
        {
            return View(absences_repository.GetFilteredAbsences(SearchString).ToList());
        }

        // GET: Absences/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Absence absence = repository.GetById(id);
            if (absence == null)
            {
                return HttpNotFound();
            }
            return View(absence);
        }

        // GET: Absences/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Absences/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Type,BeginDate,EndDate,NumberOfDays")] Absence absence)
        {
            if (ModelState.IsValid)
            {
                repository.Insert(absence);
                repository.Save();
                return RedirectToAction("Index");
            }

            return View(absence);
        }

        // GET: Absences/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Absence absence = repository.GetById(id);
            if (absence == null)
            {
                return HttpNotFound();
            }
            return View(absence);
        }

        // POST: Absences/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Type,BeginDate,EndDate,NumberOfDays")] Absence absence)
        {
            if (ModelState.IsValid)
            {
                repository.Update(absence);
                repository.Save();
                return RedirectToAction("Index");
            }
            return View(absence);
        }

        // GET: Absences/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Absence absence = repository.GetById(id);
            if (absence == null)
            {
                return HttpNotFound();
            }
            return View(absence);
        }

        // POST: Absences/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            repository.Delete(id);
            repository.Save();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            repository.Dispose();
            base.Dispose(disposing);
        }
    }
}
