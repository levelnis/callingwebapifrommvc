namespace Levelnis.Learning.CallingWebApiFromMvc.ApiHelper.Response
{
    using System.Collections.Generic;

    public class ErrorStateResponse
    {
        public string Message { get; set; }
        public IDictionary<string, string[]> ModelState { get; set; }
    }
}