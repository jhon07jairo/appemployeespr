using Newtonsoft.Json;

namespace AppEmployeesProyect.Models

{
    public class EmployeeResponse
    {
        public string status { get; set; }

		[JsonProperty("data")]
		public List<Employee> employees { get; set; }

        public string message { get; set; }
    }
}
