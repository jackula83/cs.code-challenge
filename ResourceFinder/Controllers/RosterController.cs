using MediatR;
using Microsoft.AspNetCore.Mvc;
using ResourceApplicationEntities.Controllers;
using ResourceApplicationEntities.Requests;
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
   public class RosterController : CommonController
   {
      public RosterController(IMediator a_mediator) : base(a_mediator) { }

      [HttpPost]
      public async Task<IActionResult> Post()
         => await this.RunAsync(() => m_mediator.Send(new RosterResetRequest()));
   }
}
