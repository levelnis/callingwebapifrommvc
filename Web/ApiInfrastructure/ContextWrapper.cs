namespace Levelnis.Learning.CallingWebApiFromMvc.Web.ApiInfrastructure
{
    using System.Web;
    using ApiHelper;

    public class ContextWrapper : IContextWrapper
    {
        private const string ApiTokenKey = "ApiToken";

        public object ApiToken
        {
            get { return Current.Session != null ? Current.Session[ApiTokenKey] : null; }
            set { if (Current.Session != null) Current.Session[ApiTokenKey] = value; }
        }

        private static HttpContextBase Current
        {
            get { return new HttpContextWrapper(HttpContext.Current); }
        }
    }
}