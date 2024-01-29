using Newtonsoft.Json;

namespace AppEmployeesProyect.Models
{
    public class Employee
    {
        public int id { get; set; }

		[JsonProperty("employee_name")]
		public string employeeName { get; set; }

		[JsonProperty("employee_salary")]
		public double employeeSalary { get; set; }

		[JsonProperty("employee_age")]
		public int employeeAge { get; set; }

		[JsonProperty("profile_image")]
		public string profileImage { get; set; }

		//[JsonProperty("employee_annual_salary")]
		//public double getAnnualSalary()
		//{
		//	return Math.Round(employeeSalary * 12);
		//}




	}
}
