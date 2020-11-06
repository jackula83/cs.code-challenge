using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ResourceApplicationEntities.Controllers;
using ResourceApplicationEntities.Requests;
using ResourceFinder.Interfaces;

namespace ResourceFinder.Controllers
{
   [Route("[controller]")]
   [ApiController]
   public class SpecialtyController : CommonController
   {
      public SpecialtyController(IMediator a_mediator) : base(a_mediator) { }

      [HttpGet]
      public async Task<IActionResult> Get()
         => await this.RunAsync(() => m_mediator.Send(new SpecialtyListRequest()));
   }
}
