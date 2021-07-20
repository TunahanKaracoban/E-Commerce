using Shopping.Context;
using Shopping.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Shopping.Controllers
{
    public class OrderController : Controller
    {
        ContextDb db = new ContextDb();
        [Authorize(Roles ="admin")]
        public ActionResult Index()
        {
            var orders = db.Orders.Select(i => new AdminOrderModel()
            {
                Id=i.Id,
                OrderNumber=i.OrderNumber,
                OrderDate=i.OrderDate,
                OrderState=i.OrderState,
                Total=i.Total,
                Count=i.OrderLines.Count,
            }).OrderByDescending(i => i.OrderDate).ToList();
            return View(orders);
        }
        public ActionResult Details(int id)
        {
            var entity = db.Orders.Where(i => i.Id == id).Select(i => new OrderDetailsModel()
            {
                OrderId = i.Id,
                OrderNumber = i.OrderNumber,
                Total = i.Total,
                UserName=i.UserName,
                OrderDate = i.OrderDate,
                OrderState = i.OrderState,
                AdressTitle = i.AdressTitle,
                Adress = i.Adress,
                City = i.City,
                District = i.District,
                Neighborhood = i.Neighborhood,
                PostCode = i.PostCode,
                OrderLines = i.OrderLines.Select(x => new OrderLineModel()
                {
                    ProductId = x.ProductId,
                    Image = x.Product.Image,
                    ProductName = x.Product.Name,
                    Quantity = x.Quantity,
                    Price = x.Price
                }).ToList()
            }).FirstOrDefault();
            return View(entity);
        }
        public ActionResult UpdateOrderState(int OrderId,EnumOrderState OrderState)
        {
            var order = db.Orders.FirstOrDefault(i => i.Id == OrderId);
            if (order!=null)
            {
                order.OrderState = OrderState;
                db.SaveChanges();
                return RedirectToAction("Details", new { id = OrderId });
            }
            return RedirectToAction("Index");
        }
        public ActionResult BeklenenSiparisler()
        {
            var orders = db.Orders.Where(i => i.OrderState == EnumOrderState.Bekleniyor).ToList();
            return View(orders);
        }
        public ActionResult KargolananSiparisler()
        {
            var orders = db.Orders.Where(i => i.OrderState == EnumOrderState.Kargolandı).ToList();
            return View(orders);
        }
        public ActionResult TamamlananSiparisler()
        {
            var orders = db.Orders.Where(i => i.OrderState == EnumOrderState.Tamamlandı).ToList();
            return View(orders);
        }
        public ActionResult PaketlenenSiparisler()
        {
            var orders = db.Orders.Where(i => i.OrderState == EnumOrderState.Paketlendi).ToList();
            return View(orders);
        }
    }
}