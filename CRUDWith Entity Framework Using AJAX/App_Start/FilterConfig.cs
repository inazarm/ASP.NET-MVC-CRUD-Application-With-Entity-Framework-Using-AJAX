using System.Web;
using System.Web.Mvc;

namespace CRUDWith_Entity_Framework_Using_AJAX
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
