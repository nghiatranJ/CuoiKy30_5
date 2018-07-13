using prjModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace WebApp.Controllers
{
    public class SachController : Controller
    {
        // GET: Sach
        public ActionResult Index()
        {
            List<Sach> lst;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:56682/");
                var responeTask = client.GetAsync("Sach");
                responeTask.Wait();
                var result = responeTask.Result;
                if(result.IsSuccessStatusCode)
                {
                    var resultTask = result.Content.ReadAsAsync<List<Sach>>();
                    resultTask.Wait();
                    lst = resultTask.Result;
                }
                else
                {
                    lst = new List<Sach>();
                    ModelState.AddModelError(String.Empty, "not found");
                }
            }

            return View(lst);
        }
        public ActionResult Details(int id)
        {
            Sach sach;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:56682/");
                var responeTask = client.GetAsync("Sach/" + id.ToString());
                responeTask.Wait();
                var result = responeTask.Result;
                if(result.IsSuccessStatusCode)
                {
                    var resultTask = result.Content.ReadAsAsync<Sach>();
                    resultTask.Wait();
                    sach = resultTask.Result;
                }
                else
                {
                    sach = null;
                    ModelState.AddModelError(string.Empty,"not found");
                }
            }
            return View(sach);
        }
    }
}