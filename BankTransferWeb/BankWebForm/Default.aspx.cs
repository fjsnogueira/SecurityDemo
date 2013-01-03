using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using BankTransferWeb.Models;

namespace BankTransferWeb {
    public partial class BankTransferWebForm : System.Web.UI.Page {
        // Uncomment to protect against CSRF
        /*
        protected override void OnInit(EventArgs e) {
            ViewStateUserKey = Session.SessionID;
            base.OnInit(e);
        }
        */
        protected void Page_Load(object sender, EventArgs e) {
            if (!IsPostBack) { 
                string username = User.Identity.Name;
                using (BankAccountDataContext context = new BankAccountDataContext()) {
                    AccountItems = from a in context.Accounts.ToList()
                                   select new SelectListItem {
                                       Text = a.Username + " (" + a.Balance.ToString("c") + ")",
                                       Value = a.Id.ToString()
                                   };

                    Account = context.Accounts.First(a => a.Username == username);
                    destinationAccountDropDown.DataSource = AccountItems;
                    DataBind();
                }
            }
        }

        protected Account Account {
            get;
            private set;
        }

        protected IEnumerable<SelectListItem> AccountItems {
            get;
            private set;
        }

        protected virtual void OnSubmitClick(object sender, EventArgs args) {
            using (BankAccountDataContext context = new BankAccountDataContext()) {
                string username = User.Identity.Name;
                Account source = context.Accounts.First(a => a.Username == username);
                int destinationAccountId = Convert.ToInt32(destinationAccountDropDown.SelectedValue);
                Account destination = context.Accounts.FirstOrDefault(a => a.Id == destinationAccountId);

                double amount = Convert.ToDouble(amountTextBox.Text);

                source.Balance -= amount;
                destination.Balance += amount;
                context.SubmitChanges();
            }
            Response.Redirect("~/BankWebForm/");
        }
    }
}
