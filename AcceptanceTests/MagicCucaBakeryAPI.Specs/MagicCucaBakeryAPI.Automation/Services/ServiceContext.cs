using MagicCucaBakeryAPI.Automation.Models;

namespace MagicCucaBakeryAPI.Automation.Services
{
    public class ServiceContext
    {

        private static ServiceContext instance;

        public Service Service { get; private set; }

        public string Token { get; private set; }

        public ApiResult LastResult { get; private set; }

        private ServiceContext()
        {
            Service = new Service(token => Token = token, result => LastResult = result);
        }

        public static ServiceContext GetInstance()
        {
            if(instance == null)
            {
                instance = new ServiceContext();
            }
            return instance;
        }

        public void Clear()
        {
            Token = null;
            LastResult = null;
        }
    }
}
