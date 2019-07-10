using System.Web.Mvc;
using SignalRProgressBarSimpleExample.Util;
using System.Threading;
using System.Threading.Tasks;

namespace SignalRProgressBarSimpleExample.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public JsonResult LongRunningProcess()
        {
            Task.Run(() => { LongProcess(); });

            return Json("Started", JsonRequestBehavior.AllowGet);
        }

        private void LongProcess()
        {
            //THIS COULD BE SOME LIST OF DATA
            int itemsCount = 100;

            for (int i = 0; i <= itemsCount; i++)
            {
                //SIMULATING SOME TASK
                Thread.Sleep(500);

                //CALLING A FUNCTION THAT CALCULATES PERCENTAGE AND SENDS THE DATA TO THE CLIENT
                Functions.SendProgress("Process in progress...", i, itemsCount);
            }
        }
    }
}