using Newtonsoft.Json;

namespace AppEmployeesProyect.Models
{
    public class EmployeeIdResponse
    {
        public string status { get; set; }

		[JsonProperty("data")]
		public Employee employee { get; set; }

        public string message { get; set; }
    }
}
