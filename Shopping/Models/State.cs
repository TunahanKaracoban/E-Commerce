using Shopping.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Shopping.Models
{
    public class State
    {
        ContextDb db = new ContextDb();
        public StateModelStyle GetModelStyle()
        {
            StateModelStyle models = new StateModelStyle();
            models.BeklenenSiparisSayisi = db.Orders.Where(i => i.OrderState == EnumOrderState.Bekleniyor).ToList().Count();
            models.KargolananSiparisSayisi=db.Orders.Where(i => i.OrderState == EnumOrderState.Kargolandı).ToList().Count();
            models.TamamlananSiparisSayisi = db.Orders.Where(i => i.OrderState == EnumOrderState.Tamamlandı).ToList().Count();
            models.PaketlenenSiparisSayisi = db.Orders.Where(i => i.OrderState == EnumOrderState.Paketlendi).ToList().Count();
            models.UrunSayisi = db.Products.Count();
            models.SiparisSayisi = db.Orders.Count();
            return models;
        }
    }
    public class StateModelStyle
    {
        public int UrunSayisi { get; set; }
        public int SiparisSayisi { get; set; }
        public int BeklenenSiparisSayisi { get; set; }
        public int KargolananSiparisSayisi { get; set; }
        public int TamamlananSiparisSayisi { get; set; }
        public int PaketlenenSiparisSayisi { get; set; }

    }
}