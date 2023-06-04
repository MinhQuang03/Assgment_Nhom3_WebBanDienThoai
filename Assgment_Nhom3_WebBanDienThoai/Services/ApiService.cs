using Newtonsoft.Json;
using System.Text;
using Assgment_Nhom3_WebBanDienThoai.Models;

namespace Assgment_Nhom3_WebBanDienThoai.Services
{
    public class ApiService
    {
        public async Task<bool> ApiPostService(object item, string requestUrl)
        {
            string jsonData = JsonConvert.SerializeObject(item);
            HttpContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.PostAsync(requestUrl, content);
            if (response.IsSuccessStatusCode)
            {
                return true;
            }

            return false;
        }

        public async Task<bool> ApiPutService(object item, string requestUrl)
        {
            string jsonData = JsonConvert.SerializeObject(item);
            HttpContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.PutAsync(requestUrl, content);
            if (response.IsSuccessStatusCode)
            {
                return true;
            }

            return false;
        }
        public async Task<bool> ApiDeleteService(string requestUrl)
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.DeleteAsync(requestUrl);
            if (response.IsSuccessStatusCode)
            {
                return true;
            }

            return false;
        }

    }
}
