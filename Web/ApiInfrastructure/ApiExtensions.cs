namespace Levelnis.Learning.CallingWebApiFromMvc.Web.ApiInfrastructure
{
    using System.Collections.Generic;

    public static class ApiExtensions
    {
        public static KeyValuePair<string, string> AsPair(this string key, string value)
        {
            return new KeyValuePair<string, string>(key, value);
        }
    }
}