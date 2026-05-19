using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace AbrPlus.Integration.OpenCRM.SampleCRM.Controllers
{
    [ApiController]
    [Route("private/jsonrpc")]
    [Authorize]
    public class PrivateJsonRpcController : ControllerBase
    {
        private readonly IJsonRpcActionsService _actions;

        public PrivateJsonRpcController(IJsonRpcActionsService actions)
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
