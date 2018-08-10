using ECommerce.Models;

namespace ECommerce.Controllers
{
    public class Singleton
    {
        private static Context context;
        private Singleton() { }
        public static Context Instance()
        {
            if (context == null) context = new Context();
            return context;
        }
    }
}