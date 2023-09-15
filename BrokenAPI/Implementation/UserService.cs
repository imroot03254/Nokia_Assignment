using BrokenAPI.Interface;
using BrokenAPI.Model;
using Newtonsoft.Json;
using System.Net;
using System.Net.Mail;

namespace BrokenAPI.Implementation
{
    public class UserService:IUserService
    {
        private string BaseUrl = "https://swapi.tech/api/people?page=1&limit=1000"; //Fething all the users

        public async Task<List<User>> GetUsers(string sSearch) 
        { 
                
                HttpClient client = new HttpClient();
            var result = await client.GetAsync(BaseUrl);
            if (result.StatusCode == HttpStatusCode.OK)
            {
                var JsonResult = result.Content.ReadAsStringAsync().Result;
                var userList = JsonConvert.DeserializeObject<ApiResponse>(JsonResult);
                return userList.results.Where(x=>x.name.Contains(sSearch == null?x.name: sSearch) || x.uid.Contains(sSearch == null ? x.uid : sSearch)).ToList();
            }
            else
                return null;
        }
            
    }
}
