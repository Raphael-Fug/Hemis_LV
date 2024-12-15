using Microsoft.AspNetCore.Components.Authorization;
using System.Linq.Expressions;
using System.Net.Http.Headers;
namespace C500Hemis.API
{
    public class ApiServices
    {
        IConfigurationRoot configuration = new ConfigurationBuilder()
                  .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                  .AddJsonFile("appsettings.json")
                  .Build();
        private readonly HttpClient _httpClient;
        // private readonly AuthenticationStateProvider _authenticationStateProvider;
        public ApiServices(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri(configuration.GetConnectionString("API") ?? "http://14.0.22.12:8080");
            // _authenticationStateProvider = authenticationStateProvider;
        }

        public async Task<List<T>> GetAll<T>(string apiPath, string lamda = null)
        {
            HttpResponseMessage response;
            if (lamda == null)
            {
                apiPath = apiPath + "?lamda=\" \"";
            }
            else
            {
                apiPath = apiPath + "?lamda=" + lamda;
            }
            response = await _httpClient.GetAsync(apiPath);

            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadFromJsonAsync<List<T>>();
                if (data == null)
                {
                    throw new NullReferenceException("The API response is null.");
                }
                return data;
            }
            else
            {
                throw new HttpRequestException($"Request failed with status code {response.StatusCode}: {response.ReasonPhrase}");
            }
        }
        public async Task<T> GetId<T>(string apiPath, int id)
        {
            // string token = await GetTokenAsync();
            // _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await _httpClient.GetAsync(apiPath + $"/{id}");
            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadFromJsonAsync<T>();
                if (data == null)
                {
                    throw new NullReferenceException("The API response or Data is null.");
                }
                return data;
            }
            else
            {
                throw new HttpRequestException($"Request failed with status code {response.StatusCode}: {response.ReasonPhrase}");
            }
        }

        public async Task Create<T>(string apiPath, object data)
        {
            // string token = await GetTokenAsync();
            // _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var jsonContent = JsonContent.Create(data);
            var response = await _httpClient.PostAsync(apiPath, jsonContent);
            if (response.IsSuccessStatusCode)
            {
                // _notificationService.Notify(NotificationSeverity.Success, $"Thông báo:", "Đã thêm mới dữ liệu", duration: 1500);
            }
            else
            {
                // _notificationService.Notify(NotificationSeverity.Error, $"Có lỗi đã xảy ra", duration: -1);
            }
        }

        public async Task Update<T>(string apiPath, int id, object data)
        {
            // string token = await GetTokenAsync();
            // _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var jsonContent = JsonContent.Create(data);
            var response = await _httpClient.PutAsync(apiPath + $"/{id}", jsonContent);
            if (response.IsSuccessStatusCode)
            {
                // _notificationService.Notify(NotificationSeverity.Success, $"Thông báo:", "Đã cập nhật dữ liệu dữ liệu", duration: 1500);
            }
            else
            {
                // _notificationService.Notify(NotificationSeverity.Error, $"Có lỗi đã xảy ra", duration: -1);
            }
        }

        /// <summary>
        /// Phương thức xóa các bản ghi
        /// </summary>
        /// <param name="url">Đường dẫn đến API và các tham số</param>
        /// <returns></returns>
        public async Task<bool> Delete<T>(string apiPath, int id, bool showMessage = true)
        {
            // string token = await GetTokenAsync();
            // _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            apiPath = apiPath + $"/{id}";
            var response = await _httpClient.DeleteAsync(apiPath);
            if (response.IsSuccessStatusCode)
            {
                return true;
                // if(showMessage)
                // _notificationService.Notify(NotificationSeverity.Info, $"Xoá dữ liệu thành công", duration: 2000);
            }
            else
            {
                return false;
                // if (showMessage)
                // _notificationService.Notify(NotificationSeverity.Error, $"Lỗi khi xoá dữ liệu", duration: -1);
            }
        }
    }
}