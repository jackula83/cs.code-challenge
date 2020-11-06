using MediatR;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace ResourceApplicationEntities.Controllers
{
   public abstract class CommonController : ControllerBase
   {
      protected readonly IMediator m_mediator = default;

      public CommonController(IMediator a_mediator) : base()
         => m_mediator = a_mediator;

      protected ContentResult JsonContent(object a_content)
         => Content(JsonConvert.SerializeObject(a_content), Application.Json);

      protected async Task<IActionResult> RunAsync<TResultType>(Func<Task<TResultType>> a_func)
      {
         try
         {
            TResultType results = await a_func();
            return await Task.Run(() => JsonContent(results));
         }
         catch (Exception)
         {
            // only reveal implementation details during debuging, out-of-scope: add logging for release
#if DEBUG
            throw;
#else
            return BadRequest();
#endif
         }
      }
   }
}