using System.Web;
using System.Web.Mvc;

namespace H_Mandiola_Backend
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}