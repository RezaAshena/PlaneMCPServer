using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace PlaneMCPServer
{
    public class PlaneApiService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly string _baseUrl;
        private readonly string _workspace;
        private readonly string _projectId;
        private readonly string _apiKey;

        public PlaneApiService(
            IHttpClientFactory httpClientFactory,
            string baseUrl,
            string workspace,
            string projectId,
            string apiKey
            )
        {
            _httpClientFactory = httpClientFactory;
            _baseUrl = baseUrl.TrimEnd('/');
            _workspace = workspace;
            _projectId = projectId;
            _apiKey = apiKey;
        }


        public async Task<string> GetProjectStatesAsync()
        {
            var httpClient = _httpClientFactory.CreateClient();

            httpClient.DefaultRequestHeaders.Add("X-API-Key", _apiKey);

            var url = $"{_baseUrl}/api/v1/workspaces/{_workspace}/projects/{_projectId}/states";

            var response = await httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            return content;
        }

        public async Task<string> CreateworkItemAsync(string name, string descriptionHtml, string stateId)
        {
            var httpClient = _httpClientFactory.CreateClient();
            httpClient.DefaultRequestHeaders.Add("X-API-Key", _apiKey);
            var url = $"{_baseUrl}/api/v1/workspaces/{_workspace}/projects/{_projectId}/work-items";

            var requestBody = new
            {
                name = name,
                description_html = descriptionHtml,
                stateId = stateId
            };

         var JsonContent = JsonSerializer.Serialize(requestBody);
            var content = new StringContent(JsonContent, Encoding.UTF8, "application/json");

            var response = await httpClient.PostAsync(url, content);
            response.EnsureSuccessStatusCode();
            var responseContent = await response.Content.ReadAsStringAsync();
            return responseContent;
        }
    }
}