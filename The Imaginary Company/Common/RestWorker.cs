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
        string serverurl = "https://ticweb.azurewebsites.net";
       
        public async Task<ObservableCollection<Article>> GetArticlesAsync()
        {

            string url = serverurl + "/api/Articles";
            using (HttpClient client = new HttpClient())
            {
                string response = await client.GetStringAsync(url);
                ObservableCollection<Article> List = JsonConvert.DeserializeObject<ObservableCollection<Article>>(response);
                return List;
            }
        }

        public async Task<Article> GetArticleAsync(int TIC)
        {

            string url = serverurl + "/api/Articles/" +TIC;
            using (HttpClient client = new HttpClient())
            {
                string response = await client.GetStringAsync(url);
                Article theArticle = JsonConvert.DeserializeObject<Article>(response);
                return theArticle;
            }
        }

        public async Task<Article> GetArticleByIanAsync(int IAN)
        {

            string url = serverurl + "/api/Articles/byIAN/" + IAN;
            using (HttpClient client = new HttpClient())
            {
                string response = await client.GetStringAsync(url);
                Article theArticle = JsonConvert.DeserializeObject<Article>(response);
                return theArticle;
            }
        }

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

        public void CreateArticle(Article article)
        {

            string url = serverurl + "/api/Articles";

            using (HttpClient client = new HttpClient())
            {
                string data = JsonConvert.SerializeObject(article);
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

        public void UpdateArticle(int TIC, Article article)
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
        public void DeleteArticle(int TIC)
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
    }
}
