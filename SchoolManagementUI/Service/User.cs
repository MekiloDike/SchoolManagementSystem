using Newtonsoft.Json;
using SchoolManagementUI.ViewModel;
using System.Text;


namespace SchoolManagementUI.Service
{
    public class User : IUser
    {
        public async Task Signin(LoginVM loginVM)
        {
            try
            {
                using var client = new HttpClient();
                var baseUrl = "https://localhost:7147";
                var url = $"{baseUrl}/api/UserManagement/LogInUsers";
                /*var body = new LoginVM
                {
                    Email = "ugwujachukwuemeka@yahoomail.com",
                    Password = "Mekilodike89@",
                    RememberMe = true,
                };*/
                // Serialize the body object to JSON
                var jsonBody = JsonConvert.SerializeObject(loginVM);

                // Create StringContent from JSON
                var httpContent = new StringContent(jsonBody, Encoding.UTF8, "application/json");

                var response = client.PostAsync(url, httpContent).Result;
                if (response != null && response.IsSuccessStatusCode)
                {
                    var result = JsonConvert.DeserializeObject<string>(response.Content.ToString());

                    var responseString = await response.Content.ReadAsStringAsync();

                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }


        public async Task Register(RegisterVM registerVM)
        {
            try
            {
                using var client = new HttpClient();
                var baseUrl = "https://localhost:7147";
                var url = $"{baseUrl}/api/UserManagement/CreateNewUsers";

                // Serialize the body object to JSON
                var jsonBody = JsonConvert.SerializeObject(registerVM);

                // Create StringContent from JSON
                var httpContent = new StringContent(jsonBody, Encoding.UTF8, "application/json");

                var response = client.PostAsync(url, httpContent).Result;
                if (response != null && response.IsSuccessStatusCode)
                {
                    var result = JsonConvert.DeserializeObject<string>(response.Content.ToString());

                    var responseString = await response.Content.ReadAsStringAsync();

                }
            }
            catch (Exception ex) { throw; }

        }
    }
}
            
            
            
     
