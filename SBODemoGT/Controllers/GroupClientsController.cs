using BusinessLayer;
using EntityLayer;
using Microsoft.AspNetCore.Mvc;

namespace SBODemoGT.Controllers
{
    public class GroupClientsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public List<GroupClient> GetGroupClients()
        {
            return GroupClientBAL.Instance.GetGroupClients();
        }
    }
}
