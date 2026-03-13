using System;
using System.Collections.Generic;
using System.Text;

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
            _baseUrl = baseUrl;
            _workspace = workspace;
            _projectId = projectId;
            _apiKey = apiKey;
        }
    }
}
