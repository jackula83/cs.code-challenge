using Microsoft.AspNetCore.Mvc;
using ResourceFinder.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ResourceFinder.Controllers
{
   /// <summary>
   /// Helps with integration testing as there is no "stop service" function
   /// </summary>
   [Route("[controller]")]
   [ApiController]
   public class RosterController : CommonController<IRosterResetHandler>
   {
      public RosterController(IRosterResetHandler a_handler) : base(a_handler) { }

      [HttpPost]
      public async Task<ActionResult> Post()
         => await this.RunAsync(() => m_handler.Handle(null));
   }
}
