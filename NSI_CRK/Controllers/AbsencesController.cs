using System.Linq;
using System.Net;
using System.Web.Mvc;
using NSI_CRK.DAL;
using NSI_CRK.Models;

namespace NSI_CRK.Controllers
{
    public class AbsencesController : Controller
    {
        private IUnitOfWork unitOfWork = new UnitOfWork();

        //bice potreban za dependency injection
        //public AbsencesController(IUnitOfWork unitOfWork)
        //{
        //    this.unitOfWork = unitOfWork;
        //}

        public ActionResult Index(string SearchString = null)
        {
            return View(unitOfWork.AbsencesRepository.GetFilteredAbsences(SearchString).ToList());
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Absence absence = unitOfWork.AbsencesRepository.GetById(id);
            if (absence == null)
            {
                return HttpNotFound();
            }
            return View(absence);
        }

        public ActionResult Create()
        {
            return View();
        }

        public PartialViewResult RenderEmployees()
        {
            return PartialView("RenderEmployees", unitOfWork.EmployeesRepository.GetAll());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,EmployeeID,Type,BeginDate,EndDate,NumberOfDays")] Absence absence)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.AbsencesRepository.Insert(absence);
                unitOfWork.Save();
                return RedirectToAction("Index");
            }

            return View(absence);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Absence absence = unitOfWork.AbsencesRepository.GetById(id);
            if (absence == null)
            {
                return HttpNotFound();
            }
            return View(absence);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,EmployeeID,Type,BeginDate,EndDate,NumberOfDays")] Absence absence)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.AbsencesRepository.Update(absence);
                unitOfWork.Save();
                return RedirectToAction("Index");
            }
            return View(absence);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Absence absence = unitOfWork.AbsencesRepository.GetById(id);
            if (absence == null)
            {
                return HttpNotFound();
            }
            return View(absence);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            unitOfWork.AbsencesRepository.Delete(id);
            unitOfWork.Save();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            unitOfWork.Dispose();
            base.Dispose(disposing);
        }
    }
}
