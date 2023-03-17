using AkasiaDataEngineer.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using AkasiaDataEngineer.DBAzureAkasia;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Services;
using Google.Apis.Sheets.v4;
using Google.Apis.Sheets.v4.Data;
using System.Reflection.Metadata.Ecma335;
using AkasiaDataEngineer.Models;
using AkasiaDataEngineer.DBWarehouse;

namespace AkasiaDataEngineer.Controllers
{
    public class HomeController : Controller
    {
        /// <summary>
        /// Google Sheets Linke : https://docs.google.com/spreadsheets/d/18kdYambNKPDFmwEdeezKiMn5Zffdfyt77rNOktf5cGU/edit#gid=0
        /// </summary>
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public class dashboard_graph
        {
            public int jan { get; set; }
            public int feb { get; set; }
            public int mar { get; set; }
            public int apr { get; set; }
            public int may { get; set; }
            public int jun { get; set; }
            public int jul { get; set; }
            public int aug { get; set; }
            public int sep { get; set; }
            public int oct { get; set; }
            public int nov { get; set; }
            public int dec { get; set; }
        }

        public class dashboard
        {
            public dashboard_graph graph_a { get; set; }
            public dashboard_graph graph_b { get; set; }
            
            public List<DBWarehouse.DataTraining> report { get; set; }
        }
        public IActionResult Index()
        {
            var dbwarehouse = new WarehouseContext();
            int thisyear = DateTime.Today.Year;
            dashboard result = new dashboard();
            result.graph_a = new dashboard_graph();
            result.graph_b = new dashboard_graph();
            result.report = new List<DBWarehouse.DataTraining>();
            for (int i = 1; i <= 12; i++)
            {
                if (i == 1)
                {
                    result.graph_a.jan = dbwarehouse.DataTrainings.Where(x => x.Completeddate.Value.Month == i && x.Completeddate.Value.Year == thisyear).Count();
                    result.graph_b.jan = dbwarehouse.DataTrainings.Where(x => x.Completeddate.Value.Month == i && x.Completeddate.Value.Year == thisyear).Select(x => x.Traningtype).Distinct().Count();
                }
                else if (i == 2)
                {
                    result.graph_a.feb = dbwarehouse.DataTrainings.Where(x => x.Completeddate.Value.Month == i && x.Completeddate.Value.Year == thisyear).Count();
                    result.graph_b.feb = dbwarehouse.DataTrainings.Where(x => x.Completeddate.Value.Month == i && x.Completeddate.Value.Year == thisyear).Select(x => x.Traningtype).Distinct().Count();
                }
                else if (i == 3)
                {
                    result.graph_a.mar = dbwarehouse.DataTrainings.Where(x => x.Completeddate.Value.Month == i && x.Completeddate.Value.Year == thisyear).Count();
                    result.graph_b.mar = dbwarehouse.DataTrainings.Where(x => x.Completeddate.Value.Month == i && x.Completeddate.Value.Year == thisyear).Select(x => x.Traningtype).Distinct().Count();
                }
                else if (i == 4)
                {
                    result.graph_a.apr = dbwarehouse.DataTrainings.Where(x => x.Completeddate.Value.Month == i && x.Completeddate.Value.Year == thisyear).Count();
                    result.graph_b.apr = dbwarehouse.DataTrainings.Where(x => x.Completeddate.Value.Month == i && x.Completeddate.Value.Year == thisyear).Select(x => x.Traningtype).Distinct().Count();
                }
                else if (i == 5)
                {
                    result.graph_a.may = dbwarehouse.DataTrainings.Where(x => x.Completeddate.Value.Month == i && x.Completeddate.Value.Year == thisyear).Count();
                    result.graph_b.may = dbwarehouse.DataTrainings.Where(x => x.Completeddate.Value.Month == i && x.Completeddate.Value.Year == thisyear).Select(x => x.Traningtype).Distinct().Count();
                }
                else if (i == 6)
                {
                    result.graph_a.jun = dbwarehouse.DataTrainings.Where(x => x.Completeddate.Value.Month == i && x.Completeddate.Value.Year == thisyear).Count();
                    result.graph_b.jun = dbwarehouse.DataTrainings.Where(x => x.Completeddate.Value.Month == i && x.Completeddate.Value.Year == thisyear).Select(x => x.Traningtype).Distinct().Count();
                }

                else if (i == 7)
                {
                    result.graph_a.jul = dbwarehouse.DataTrainings.Where(x => x.Completeddate.Value.Month == i && x.Completeddate.Value.Year == thisyear).Count();
                    result.graph_b.jul = dbwarehouse.DataTrainings.Where(x => x.Completeddate.Value.Month == i && x.Completeddate.Value.Year == thisyear).Select(x => x.Traningtype).Distinct().Count();
                }
                else if (i == 8)
                {
                    result.graph_a.aug = dbwarehouse.DataTrainings.Where(x => x.Completeddate.Value.Month == i && x.Completeddate.Value.Year == thisyear).Count();
                    result.graph_b.aug = dbwarehouse.DataTrainings.Where(x => x.Completeddate.Value.Month == i && x.Completeddate.Value.Year == thisyear).Select(x => x.Traningtype).Distinct().Count();
                }
                else if (i == 9)
                {
                    result.graph_a.sep = dbwarehouse.DataTrainings.Where(x => x.Completeddate.Value.Month == i && x.Completeddate.Value.Year == thisyear).Count();
                    result.graph_b.sep = dbwarehouse.DataTrainings.Where(x => x.Completeddate.Value.Month == i && x.Completeddate.Value.Year == thisyear).Select(x => x.Traningtype).Distinct().Count();
                }
                else if (i == 10)
                {
                    result.graph_a.oct = dbwarehouse.DataTrainings.Where(x => x.Completeddate.Value.Month == i && x.Completeddate.Value.Year == thisyear).Count();
                    result.graph_b.oct = dbwarehouse.DataTrainings.Where(x => x.Completeddate.Value.Month == i && x.Completeddate.Value.Year == thisyear).Select(x => x.Traningtype).Distinct().Count();
                }
                else if (i == 11)
                {
                    result.graph_a.nov = dbwarehouse.DataTrainings.Where(x => x.Completeddate.Value.Month == i && x.Completeddate.Value.Year == thisyear).Count();
                    result.graph_b.nov = dbwarehouse.DataTrainings.Where(x => x.Completeddate.Value.Month == i && x.Completeddate.Value.Year == thisyear).Select(x => x.Traningtype).Distinct().Count();
                }
                else if (i == 12)
                {
                    result.graph_a.dec = dbwarehouse.DataTrainings.Where(x => x.Completeddate.Value.Month == i && x.Completeddate.Value.Year == thisyear).Count();
                    result.graph_b.dec = dbwarehouse.DataTrainings.Where(x => x.Completeddate.Value.Month == i && x.Completeddate.Value.Year == thisyear).Select(x => x.Traningtype).Distinct().Count();
                }
            }
            result.report = dbwarehouse.DataTrainings.ToList();
            return View(result);
        }

        public List<GoogleSheetModels> syncDataFromGoogleSheets()
        {
            string[] Scopes = { SheetsService.Scope.Spreadsheets };
            string sheet = "Sheet1";
            string SpreadsheetId = "18kdYambNKPDFmwEdeezKiMn5Zffdfyt77rNOktf5cGU";
            SheetsService service;

            GoogleCredential credential;
            using (var stream = new FileStream("GoogleSheetKey/delta-carving-379812-c1a78ba93347.json", FileMode.Open, FileAccess.Read))
            {
                credential = GoogleCredential.FromStream(stream).CreateScoped(Scopes);
            }

            service = new SheetsService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = "Akasia-DataEngineer",
            });


            var myInvList = new List<GoogleSheetModels>();
            var range = $"{sheet}!A:C";
            int j = 0;
            SpreadsheetsResource.ValuesResource.GetRequest request = service.Spreadsheets.Values.Get(SpreadsheetId, range);
            var response = request.Execute();
            IList<IList<object>> values = response.Values;
            if (values != null && values.Count > 0)
            {
                foreach (var row in values)
                {
                    j++;
                    if (j > 0)
                    {
                        var myInv = new GoogleSheetModels()
                        {
                            id = row[0].ToString(),
                            title = row[1].ToString(),
                            date = row[2].ToString()
                        };

                        myInvList.Add(myInv);
                    }
                }
            }
            else
            {
                myInvList.Clear();
            }
            return myInvList;
        }

        public List<AzureEmployee> syncDataFromAzure()
        {
            var context = new AzureContext();
            List<AzureEmployee> result = new List<AzureEmployee>();
            var listemployee = context.CurrentPositions.ToList();
            foreach (var a in listemployee)
            {
                var myInv = new AzureEmployee()
                {
                    id = a.Employeeid,
                    nama = a.Fullname,
                    position = a.Postitle
                };
                result.Add(myInv);
            }
            return result;
        }

        public IActionResult ETLProcessing()
        {
            try
            {
                var cont = new WarehouseContext();
                var deletedata = cont.DataTrainings.ToList();
                foreach (var b in deletedata)
                {
                    using (var ctx = new WarehouseContext())
                    {
                        ctx.Remove(b);
                        ctx.SaveChanges();
                    }
                }

                List<GoogleSheetModels> DataFromGoogleSheets = syncDataFromGoogleSheets();
                List<AzureEmployee> dataFromAzure = syncDataFromAzure();

                var datajoin = from a in dataFromAzure
                               join b in DataFromGoogleSheets
                               on a.id equals b.id
                               select new { a.id, a.nama, a.position, b.title, b.date };

                foreach (var a in datajoin)
                {
                    using (var context = new WarehouseContext())
                    {
                        DateOnly dt = DateOnly.Parse(a.date);
                        Random random = new Random();
                        var obj = new DataTraining()
                        {
                            Id = random.Next(),
                            Employeeid = a.id,
                            Fullname = a.nama,
                            Birthdate = DateOnly.FromDateTime(DateTime.Today),
                            Address = "Address",
                            Postitle = a.position,
                            Traningtype = a.title,
                            Completeddate = dt
                        };
                        context.DataTrainings.Add(obj);
                        context.SaveChanges();
                    }
                }
                //return Content("Succes : ETL Process has been done...");
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                //return Content("Error : " + ex.ToString());
                return RedirectToAction("Error");
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