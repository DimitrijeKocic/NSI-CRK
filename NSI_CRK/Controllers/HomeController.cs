using NSI_CRK.DAL;
using NSI_CRK.Models;
using System.Web.Mvc;

namespace NSI_CRK.Controllers
{
    public class HomeController : Controller
    {
        private IUnitOfWork unitOfWork = new UnitOfWork();

        public ActionResult Index()
        {
            ViewBag.NumberOfEmployees = unitOfWork.EmployeesRepository.GetNumberOfEmployees();
            ViewBag.SalarySum = unitOfWork.EmployeesRepository.GetSalarySum();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult GenerateSalaries(Months month)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.PaymentsRepository.GenerateSalaries(month);
                unitOfWork.Save();
                return RedirectToAction("Index", "Payments");
            }

            return View();
        }

        public ActionResult About()
        {
            return View();
        }
    }
}