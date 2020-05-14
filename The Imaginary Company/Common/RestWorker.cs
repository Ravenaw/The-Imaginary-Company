using InventoryLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace The_Imaginary_Company.Common
{
    class RestWorker
    {
        string localhost = "http://localhost:57352";
       
        /////////////////////
        public async Task<ObservableCollection<Article>> GetArticlesAsync()
        {

            string url = localhost + "/api/Hotel";
            using (HttpClient client = new HttpClient())
            {
                string response = await client.GetStringAsync(url);
                ObservableCollection<Article> List = JsonConvert.DeserializeObject<ObservableCollection<Article>>(response);
                return List;
            }
        }

        //public async Task<Hotel> GetHotel(int id)
        //{

        //    string url = localhost + "/api/Hotel/" + id;
        //    using (HttpClient client = new HttpClient())
        //    {
        //        string response = await client.GetStringAsync(url);
        //        Hotel List = JsonConvert.DeserializeObject<Hotel>(response);
        //        return List;
        //    }
        //}
        //public void CreateHotel(Hotel hotel)
        //{

        //    string url = localhost + "/api/Hotel";

        //    using (HttpClient client = new HttpClient())
        //    {
        //        string data = JsonConvert.SerializeObject(hotel);
        //        StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
        //        HttpResponseMessage response = client.PostAsync(url, content).Result;
        //        try
        //        {
        //            response.EnsureSuccessStatusCode();
        //        }
        //        catch (Exception ex)
        //        {
        //            Console.WriteLine(ex.Message);
        //        }
        //    }
        //}


        //public void UpdateHotel(int id, Hotel hotel)
        //{
        //    string url = localhost + "/api/Hotel/" + id;
        //    using (HttpClient client = new HttpClient())
        //    {
        //        string data = JsonConvert.SerializeObject(hotel);
        //        StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
        //        HttpResponseMessage response = client.PutAsync(url, content).Result;
        //        try
        //        {
        //            response.EnsureSuccessStatusCode();
        //        }
        //        catch (Exception ex)
        //        {
        //            Console.WriteLine(ex.Message);
        //        }
        //    }
        //}
        //public void DeleteHotel(int id)
        //{
        //    string url = localhost + "/api/Hotel/" + id;

        //    using (HttpClient client = new HttpClient())
        //    {
        //        HttpResponseMessage response = client.DeleteAsync(url).Result;
        //        try
        //        {
        //            response.EnsureSuccessStatusCode();
        //        }
        //        catch (Exception ex)
        //        {
        //            Console.WriteLine(ex.Message);
        //        }
        //    }
        //}



    }
}
