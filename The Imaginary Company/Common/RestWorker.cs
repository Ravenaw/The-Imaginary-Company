using InventoryLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Collections.ObjectModel;
using System.Data.SqlClient;

namespace The_Imaginary_Company.Common
{
    class RestWorker
    {
        //this is sends requests and data to the webservice, what functions from the webservice the server should run
        string serverurl = "https://ticweb.azurewebsites.net";
        //async returns only tasks or void or Task<T>
        //async is a method modifier (like e.g. public or static), indicating that the method contains code that can be run asynchronously.
        //await is an operator, which specifies where code will be executed asyn-chronously.

        public async Task<ObservableCollection<Article>> GetArticlesAsync()
        {

            string url = serverurl + "/api/Articles";
            //predifined httpclient object
            // "using" is used to specify that the HttpClient is only used during the execution and will close when it's done
            using (HttpClient client = new HttpClient())
            {
                //GetStringAsync is a predefined method that HttpClient has 
                //because the method GetStringAsync is async, we need the await operator, and this is why we created the method async
                //we could also use the GetStringAsync.Result, but it takes longer than using the async function
                string response = await client.GetStringAsync(url);
                ObservableCollection<Article> List = JsonConvert.DeserializeObject<ObservableCollection<Article>>(response);
                return List;
            }
        }
        //returning one article based on the TIC number
        public async Task<Article> GetArticleAsync(string TIC)
        {

            string url = serverurl + "/api/Articles/" + TIC;
            using (HttpClient client = new HttpClient())
            {
                string response = await client.GetStringAsync(url);
                Article theArticle = JsonConvert.DeserializeObject<Article>(response);
                return theArticle;
            }
        }
        //returning one article based on the IAN number
        public async Task<Article> GetArticleByIanAsync(string IAN)
        {

            string url = serverurl + "/api/Articles/byIAN/" + IAN;
            using (HttpClient client = new HttpClient())
            {
                string response = await client.GetStringAsync(url);
                Article theArticle = JsonConvert.DeserializeObject<Article>(response);
                return theArticle;
            }
        }
        //returning one article based on the Location
        public async Task<Article> GetArticleByLocationAsync(string Loc)
        {

            string url = serverurl + "/api/Articles/byLoc/" + Loc;
            using (HttpClient client = new HttpClient())
            {
                string response = await client.GetStringAsync(url);
                Article theArticle = JsonConvert.DeserializeObject<Article>(response);
                return theArticle;
            }
        }
        //create an article on the webservice
        public void CreateArticle(Article article)
        {

            string url = serverurl + "/api/Articles";

            using (HttpClient client = new HttpClient())
            {
                string data = JsonConvert.SerializeObject(article);
                StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
                //we use the .Result instead of the await because we want to receive an response from the webservice
                HttpResponseMessage response = client.PostAsync(url, content).Result;
                try
                {
                    response.EnsureSuccessStatusCode();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
        //IMPORTANT POST: ADDING PUT: UPDATE
        public void UpdateArticle(string TIC, Article article)
        {
            string url = serverurl + "/api/Articles/" + TIC;
            using (HttpClient client = new HttpClient())
            {
                string data = JsonConvert.SerializeObject(article);
                StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
                HttpResponseMessage response = client.PutAsync(url, content).Result;
                try
                {
                    response.EnsureSuccessStatusCode();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
        public void DeleteArticle(string TIC)
        {
            string url = serverurl + "/api/Articles/" + TIC;

            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = client.DeleteAsync(url).Result;
                try
                {
                    response.EnsureSuccessStatusCode();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
        public async Task<ObservableCollection<User>> GetUsersAsync()
        {

            string url = serverurl + "/api/User";
            using (HttpClient client = new HttpClient())
            {
                string response = await client.GetStringAsync(url);
                ObservableCollection<User> List = JsonConvert.DeserializeObject<ObservableCollection<User>>(response);
                return List;
            }
        }
        public void DeleteUser(string username)
        {
            string url = serverurl + "/api/User/" + username;

            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = client.DeleteAsync(url).Result;
                try
                {
                    response.EnsureSuccessStatusCode();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
        public async Task<User> GetUserAsync(string username)
        {

            string url = serverurl + "/api/User/" + username;
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    string response = await client.GetStringAsync(url);
                    User theUser = JsonConvert.DeserializeObject<User>(response);
                    return theUser;
                }
                catch (Exception ex)
                {
                    User bye = new User();
                    Console.WriteLine(ex.Message);
                    return bye;
                }
            }
        }
        public void CreateUser(User user)
        {

            string url = serverurl + "/api/User";

            using (HttpClient client = new HttpClient())
            {
                string data = JsonConvert.SerializeObject(user);
                StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
                HttpResponseMessage response = client.PostAsync(url, content).Result;
                try
                {
                    response.EnsureSuccessStatusCode();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
