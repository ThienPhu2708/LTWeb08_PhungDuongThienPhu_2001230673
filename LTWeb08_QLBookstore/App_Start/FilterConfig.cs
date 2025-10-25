using System.Web;
using System.Web.Mvc;

namespace LTWeb08_QLBookstore
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
