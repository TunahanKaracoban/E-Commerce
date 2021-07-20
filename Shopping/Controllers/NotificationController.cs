using Shopping.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Shopping.Controllers
{
    public class NotificationController : Controller
    {
        // GET: Notification
        public PartialViewResult BildirimMenusu()
        {
            return PartialView(new Bildirim().SiparisBekleyenListe());
        }
    }
}