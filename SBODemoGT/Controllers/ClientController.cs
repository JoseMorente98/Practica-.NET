using BusinessLayer;
using EntityLayer;
using Microsoft.AspNetCore.Mvc;

namespace SBODemoGT.Controllers
{
    public class ClientController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public List<Client> GetClients()
        {
            return ClientBAL.Instance.GetClients();
        }
    }
}
