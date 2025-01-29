using Newtonsoft.Json;
using SchoolManagementUI.ViewModel;
using System.Text;


namespace SchoolManagementUI.Service
{
    public class User : IUser
    {
        private readonly ILogger<User> logger;
        public User(ILogger<User> logger)
        {

            this.logger = logger;

        }
        public async Task<string> Signin(LoginVM loginVM)
        {
            try
            {
                var responseString = "";
                using var client = new HttpClient();
                var baseUrl = "https://localhost:7147";
                var url = $"{baseUrl}/api/UserManagement/LogInUsers";
           
                // Serialize the body object to JSON
                var jsonBody = JsonConvert.SerializeObject(loginVM);

                // Create StringContent from JSON
                var httpContent = new StringContent(jsonBody, Encoding.UTF8, "application/json");

                logger.LogInformation($"Making calls to login API with url: {url}");
                logger.LogInformation($"Making calls to login API with request body: {jsonBody}");
                var response = client.PostAsync(url, httpContent).Result;
                if (response != null && response.IsSuccessStatusCode)
                {
                     responseString = await response.Content.ReadAsStringAsync();
                    logger.LogInformation($"Response body: {response}");

                }
                return responseString;
            }
            catch (Exception ex)
            {
                logger.LogError($"Something went wrong {ex.Message}");
                logger.LogTrace($"Something went wrong {ex.StackTrace}");
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
                  //  var result = JsonConvert.DeserializeObject<string>(response.Content.ToString());

                    var responseString = await response.Content.ReadAsStringAsync();

                }
            }
            catch (Exception ex) { throw; }

        }
    }
}
            
            
            
     
