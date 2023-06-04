using Newtonsoft.Json;
using System.Text;

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
    }
}
