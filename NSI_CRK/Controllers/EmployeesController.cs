using System.Linq;
using System.Net;
using System.Web.Mvc;
using NSI_CRK.DAL;
using NSI_CRK.Models;

namespace NSI_CRK.Controllers
{
    public class EmployeesController : Controller
    {
        private IUnitOfWork unitOfWork = new UnitOfWork();

        //bice potreban za dependency injection
        //public EmployeesController(IUnitOfWork unitOfWork)
        //{
        //    this.unitOfWork = unitOfWork;
        //}

        public ActionResult Index(string SearchString = null)
        {
            return View(unitOfWork.EmployeesRepository.GetFilteredEmployees(SearchString).ToList());
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = unitOfWork.EmployeesRepository.GetById(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,CompanyID,FirstName,LastName,Email,City,Address,TelephoneNumber,DateOfBirth,DateOfEmployment,DateOfContractExpiration,Position,Salary")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.EmployeesRepository.Insert(employee);
                unitOfWork.Save();
                return RedirectToAction("Index");
            }

            return View(employee);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = unitOfWork.EmployeesRepository.GetById(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,CompanyID,FirstName,LastName,Email,City,Address,TelephoneNumber,DateOfBirth,DateOfEmployment,DateOfContractExpiration,Position,Salary")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.EmployeesRepository.Update(employee);
                unitOfWork.Save();
                return RedirectToAction("Index");
            }
            return View(employee);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = unitOfWork.EmployeesRepository.GetById(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            unitOfWork.EmployeesRepository.Delete(id);
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
