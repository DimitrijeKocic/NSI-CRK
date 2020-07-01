using System.Linq;
using System.Net;
using System.Web.Mvc;
using NSI_CRK.DAL;
using NSI_CRK.Models;

namespace NSI_CRK.Controllers
{
    public class PaymentsController : Controller
    {
        private IUnitOfWork unitOfWork = new UnitOfWork();

        //bice potreban za dependency injection
        //public PaymentsController(IUnitOfWork unitOfWork)
        //{
        //    this.unitOfWork = unitOfWork;
        //}

        public ActionResult Index(string SearchString = null)
        {
            return View(unitOfWork.PaymentsRepository.GetFilteredPayments(SearchString).ToList());
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Payment payment = unitOfWork.PaymentsRepository.GetById(id);
            if (payment == null)
            {
                return HttpNotFound();
            }
            return View(payment);
        }

        public ActionResult Create()
        {
            return View();
        }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Amount,Type,Month,Date")] Payment payment)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.PaymentsRepository.Insert(payment);
                unitOfWork.Save();
                return RedirectToAction("Index");
            }

            return View(payment);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Payment payment = unitOfWork.PaymentsRepository.GetById(id);
            if (payment == null)
            {
                return HttpNotFound();
            }
            return View(payment);
        }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Amount,Type,Month,Date")] Payment payment)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.PaymentsRepository.Update(payment);
                unitOfWork.Save();
                return RedirectToAction("Index");
            }
            return View(payment);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Payment payment = unitOfWork.PaymentsRepository.GetById(id);
            if (payment == null)
            {
                return HttpNotFound();
            }
            return View(payment);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            unitOfWork.PaymentsRepository.Delete(id);
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
