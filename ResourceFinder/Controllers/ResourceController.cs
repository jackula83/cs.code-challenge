using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ResourceApplicationEntities.Controllers;
using ResourceApplicationEntities.Requests;
using ResourceBusinessEntities.BaseClasses;
using ResourceBusinessEntities.Interfaces.Application;
using ResourceBusinessEntities.Interfaces.Models;
using ResourceFinder.Interfaces;

namespace ResourceFinder.Controllers
{
   [Route("[controller]")]
   [ApiController]
   public class ResourceController : CommonController
   {
      public ResourceController(IMediator a_mediator) : base(a_mediator) { }

      [HttpGet("{language}")]
      public async Task<IActionResult> Get(string language)
         => await this.Get(language, default);

      [HttpGet("{language}/{specialty}")]
      public async Task<IActionResult> Get(string language, string specialty)
      {
         AllocateResourceRequest sr = new AllocateResourceRequest
         {
            Language = language,
            Specialty = specialty
         };

         return await this.RunAsync(() => m_mediator.Send(sr));
      }
   }
}
