using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using AccountsManager.Model;

namespace AccountsManager.Client
{
    class Client
    {
        private readonly HttpClient client;
        private static string URL = "https://localhost:5001/";

        public Client()
        {
            var httpClientHandler = new HttpClientHandler();
            httpClientHandler.ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator;

            client = new HttpClient(httpClientHandler);
        }

        public async Task<List<Assignment>> GetAssignments()
        {
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Add("User-Agent", ".NET Client");

            var json = await client.GetStringAsync(URL + "api/v1/assignment");
            var assignments = JsonConvert.DeserializeObject<List<Assignment>>(json);
            return assignments;
        }

        public async void UpdateAssignment(Assignment assignment)
        {
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Add("User-Agent", ".NET Client");
            var jsonContent = JsonConvert.SerializeObject(assignment);
            using (var content = new StringContent(jsonContent, Encoding.UTF8, "application/json"))
            {
                string endpoint = URL + "api/v1/assignment/" + assignment.Id.ToString();
                await client.PutAsync(endpoint, content);
            }
        }

        public async void AddAssignment(Assignment assignment)
        {
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Add("User-Agent", ".NET Client");
            var jsonContent = JsonConvert.SerializeObject(assignment);
            using (var content = new StringContent(jsonContent, Encoding.UTF8, "application/json"))
            {
                string endpoint = URL + "api/v1/assignment";
                var r = await client.PostAsync(endpoint, content);
                Console.WriteLine(r);
            }
        }

        public async Task<List<Company>> GetCompanies()
        {
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Add("User-Agent", ".NET Client");

            var json = await client.GetStringAsync(URL + "api/v1/companies");
            var companies = JsonConvert.DeserializeObject<List<Company>>(json);
            return companies;
        }

        public async Task<List<Employee>> GetEmployees()
        {
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Add("User-Agent", ".NET Client");

            var json = await client.GetStringAsync(URL + "api/v1/employees");
            var employees = JsonConvert.DeserializeObject<List<Employee>>(json);
            return employees;
        }
    }
}
