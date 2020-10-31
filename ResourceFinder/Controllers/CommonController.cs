using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ResourceEntities.Interfaces.Fx;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace ResourceFinder.Controllers
{
   public abstract class CommonController<THandlerType> : ControllerBase
      where THandlerType : IHandler
   {
      protected readonly THandlerType m_handler = default;

      public CommonController(THandlerType a_handler) : base()
         => m_handler = a_handler;

      protected ContentResult JsonContent(object a_content)
         => Content(JsonConvert.SerializeObject(a_content), Application.Json);

      protected async Task<ActionResult> RunAsync<TResultType>(Func<Task<TResultType>> a_func)
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