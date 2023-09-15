using Algo;
using BrokenAPI.Model;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Xml.Linq;
using UserInterfaceWeb.Models;

namespace UserInterfaceWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private string ApiUrl = "https://localhost:7174/api/Home?sSearch=";
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            SpiralMatrix spiralMatrix = new SpiralMatrix();
            int[][] Case1 = {
                new []{1,2,3,4},
                new []{5,6,7,8},
                new []{9,10,11,12},
                new []{13,14,15,16},
            };
            int[][] Case2 = {
                new []{1,2,3},
                new []{4,5,6},
                new []{7,8,9}
            };
            MatrixResult model=new MatrixResult();
            model.Result1=  String.Join(",",spiralMatrix.SpiralOrder(Case1));
            model.Result2 = String.Join(",",spiralMatrix.SpiralOrder(Case2));

            return View(model);
        }


        public async Task<dynamic> GetUser(string sEcho,int iDisplayLength, int iDisplayStart, int iSortCol_0, string sSortDir_0, string sSearch)
        {
            string Url = ApiUrl + sSearch;
            HttpClient client = new HttpClient();
            var clientResult= await client.GetAsync(Url);
            if (clientResult.IsSuccessStatusCode)
            {
                var JsonResult = clientResult.Content.ReadAsStringAsync().Result;
                var userList = JsonConvert.DeserializeObject<List<User>>(JsonResult);
                var result = new
                {
                    sEcho,
                    iTotalRecords = userList.Count(),
                    iTotalDisplayRecords = userList.Count(),
                    aaData = userList
                };
                return result;
            }
            else {
                var result = new
                {
                    sEcho,
                    iTotalRecords = 0,
                    iTotalDisplayRecords = 0,
                    aaData = ""
                };
                return result;
            }
          
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}