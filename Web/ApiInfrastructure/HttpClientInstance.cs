namespace Levelnis.Learning.CallingWebApiFromMvc.Web.ApiInfrastructure
{
    using System;
    using System.Net.Http;

    /// <summary>
    /// Creates a Singleton instance of HttpClient - note that this is for demo purposes only. 
    /// I would recommend that you use a Dependency Injection container such as Autofac for managing the lifecycle of your objects.
    /// If we used Autofac here there would be no need for this class.
    /// </summary>
    public static class HttpClientInstance
    {
        private const string BaseUri = "Http://localhost:28601/";
        private static readonly HttpClient instance = new HttpClient {BaseAddress = new Uri(BaseUri)};

        public static HttpClient Instance
        {
            get { return instance; }
        }
    }
}