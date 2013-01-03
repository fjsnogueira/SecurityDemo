using System.Web.Mvc;
using System.Linq;
using BankTransferWeb.Models;
using System.Collections.Generic;

namespace BankTransferWeb.Controllers
{
    [HandleError]
    [Authorize]
    public class HomeController : Controller
    {
        BankAccountDataContext _context = new BankAccountDataContext();

        // Notes:   DEMO CODE ONLY. DO NOT EMULATE!
        [HttpPost]
        public ActionResult Transfer(int destinationAccountId, double amount)
        {
            string username = User.Identity.Name;
            Account source = _context.Accounts.First(a => a.Username == username);
            Account destination = _context.Accounts.FirstOrDefault(a => a.Id == destinationAccountId);

            source.Balance -= amount;
            destination.Balance += amount;
            _context.SubmitChanges();
            return RedirectToAction("Index");
        }

        #region Json Hijack Demo: AdminBalances action

        public JsonResult AdminBalances()
        {
            var balances = from account in _context.Accounts
                           select new
                           {
                               Id = account.Id,
                               Balance = account.Balance
                           };

            return Json(balances, JsonRequestBehavior.AllowGet);
        }
        
        #endregion

        #region Do not look over here. Not relevant to this demo. :)
        public ActionResult Index() {
            string username = User.Identity.Name;
            ViewData["destinationAccountId"] = from a in _context.Accounts.ToList()
                                               select new SelectListItem {
                                                   Text = a.Username + " (" + a.Balance.ToString("c") + ")",
                                                   Value = a.Id.ToString()
                                               };

            Account account = _context.Accounts.First(a => a.Username == username);

            return View(account);
        }


        public ActionResult About()
        {
            return View();
        }

        protected override void Dispose(bool disposing)
        {
            BankAccountDataContext context = _context;
            if (disposing && context != null) {
                context.Dispose();
            }
        }
        #endregion
    }
}
