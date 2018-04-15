using Stripe;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ScoresWebsite.Controllers
{
    public class StripeController : Controller
    {
        //Stripe.setPublishableKey('pk_test_qxv5VdJFxiLP3TNDpHNDDdMx');
        public ActionResult Index()
        {
            var stripePublishKey = ConfigurationManager.AppSettings["pk_test_qxv5VdJFxiLP3TNDpHNDDdMx"];
            ViewBag.StripePublishKey = stripePublishKey;
            return View();
        }

        public ActionResult Charge(string stripeEmail, string stripeToken)
        {
            var customers = new StripeCustomerService();
            var charges = new StripeChargeService();

            var customer = customers.Create(new StripeCustomerCreateOptions
            {
                Email = stripeEmail,
                SourceToken = stripeToken
            });

            var charge = charges.Create(new StripeChargeCreateOptions
            {
                Amount = 100,//charge in cents
                Description = "Sample Charge",
                Currency = "eur",
                CustomerId = customer.Id
            });

            // further application specific code goes here

            return View();
        }
    }
}