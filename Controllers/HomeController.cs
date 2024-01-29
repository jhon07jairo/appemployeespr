using AppEmployeesProyect.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Data;
using System.Diagnostics;
using System.Net.Http.Headers;

namespace AppEmployeesProyect.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

		string baseURL = "https://dummy.restapiexample.com/api/v1/";
		//string baseURL = "http://localhost:8081/";
		//https://jsonplaceholder.typicode.com/todos/1
		//string baseURL = "https://jsonplaceholder.typicode.com/";
		//https://jsonplaceholder.typicode.com/

		public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            //Call the API
            EmployeeResponse employeeResponse = new EmployeeResponse();



            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseURL);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage getData = await client.GetAsync("employees");

                if (getData.IsSuccessStatusCode)
                {

                    string results = await getData.Content.ReadAsStringAsync();
                    employeeResponse = JsonConvert.DeserializeObject<EmployeeResponse>(results);
                    
				}
                else if ((int)getData.StatusCode == 429)
                {
					await Task.Delay(ObtenerTiempoDeEspera(getData));
					return await Index();
				}
                else
                {
                    Console.WriteLine("Error calling web Api");
                }

            }

            return View(employeeResponse);
        }

        public async Task<IActionResult> Index2() 
        {
			//Call the API
			EmployeeIdResponse employeeIdResponse = new EmployeeIdResponse();



			using (var client = new HttpClient())
			{
				client.BaseAddress = new Uri(baseURL);
				client.DefaultRequestHeaders.Accept.Clear();
				client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

				HttpResponseMessage getData = await client.GetAsync("employee/1");

				if (getData.IsSuccessStatusCode)
				{

					string results = await getData.Content.ReadAsStringAsync();
					employeeIdResponse = JsonConvert.DeserializeObject<EmployeeIdResponse>(results);

				}
				else if ((int)getData.StatusCode == 429)
				{
					await Task.Delay(ObtenerTiempoDeEspera(getData));
					return await Index2();
				}
				else
				{
					Console.WriteLine("Error calling web Api");
				}

			}

			return View(employeeIdResponse);
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

		private int ObtenerTiempoDeEspera(HttpResponseMessage response)
		{

			return 60000;
		}
	}
}