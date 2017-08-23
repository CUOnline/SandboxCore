using System.Collections.Generic;
using System.Threading.Tasks;

namespace SandboxCore.Clients
{
    public abstract class ClientBase : HttpClientWrapperBase
    {
        protected string ApiController;
        protected string ApiPath;

        protected ClientBase(string apiController)
        {
            ApiController = apiController;
        }

        public async Task<IEnumerable<T>> GetAll<T>()
        {
            return await ExecuteGet<IEnumerable<T>>(ApiController);
        }

        public async Task<T> Get<T>(int modelId)
        {
            ApiPath = ApiController + "/" + modelId;
            return await ExecuteGet<T>(ApiPath);
        }
    }
}