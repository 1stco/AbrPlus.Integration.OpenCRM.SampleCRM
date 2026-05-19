using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace AbrPlus.Integration.OpenCRM.SampleCRM.Controllers
{
    [ApiController]
    [Route("public/jsonrpc")]
    public class PublicJsonRpcController : ControllerBase
    {
        private readonly IJsonRpcActionsService _actions;

        public PublicJsonRpcController(IJsonRpcActionsService actions)
        {
            _actions = actions;
        }

        [HttpPost]
        public Task<JsonRpcResponse<object>> Invoke([FromBody] JsonRpcRequest<JsonElement> request)
        {
            return _actions.Invoke(request);
        }
    }
}
