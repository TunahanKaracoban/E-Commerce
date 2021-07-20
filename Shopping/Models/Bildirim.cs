using Shopping.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Shopping.Models
{
    public class Bildirim
    {
        ContextDb db = new ContextDb();
        public List<Order> SiparisBekleyenListe()
        {
            return db.Orders.Where(i => i.OrderState == EnumOrderState.Bekleniyor).ToList();
        }
    }
}