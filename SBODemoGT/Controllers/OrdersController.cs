using BusinessLayer;
using EntityLayer;
using Microsoft.AspNetCore.Mvc;
using SBODemoGT.Models;

namespace SBODemoGT.Controllers
{
    public class OrdersController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public List<Orders> GetOrders()
        {
            return OrdersBAL.Instance.GetOrders();
        }

        public Orders GetOrder(int docEntry)
        {
            return OrdersBAL.Instance.GetOrder(docEntry);
        }

        public List<Orders> FilterOrder(Order order)
        {
            return OrdersBAL.Instance.FilterOrders(order.DateInit, order.DateFinish, order.GroupNum, order.CardCode);
        }
    }
}
