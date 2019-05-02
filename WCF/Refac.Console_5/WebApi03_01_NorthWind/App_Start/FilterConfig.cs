using System.Web;
using System.Web.Mvc;

namespace WebApi03_01_NorthWind
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
