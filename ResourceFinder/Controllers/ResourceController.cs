using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ResourceEntities.BaseClasses;
using ResourceEntities.Interfaces.Application;
using ResourceEntities.Interfaces.Business;
using ResourceEntities.Requests;
using ResourceEntities.Responses;
using ResourceFinder.Interfaces;

namespace ResourceFinder.Controllers
{
   [Route("[controller]")]
   [ApiController]
   public class ResourceController : CommonController<IAllocateResourceHandler>
   {
      public ResourceController(IAllocateResourceHandler a_handler) : base(a_handler) { }

      [HttpGet("{language}")]
      public async Task<ActionResult> Get(string language)
         => await this.Get(language, default);

      [HttpGet("{language}/{specialty}")]
      public async Task<ActionResult> Get(string language, string specialty)
      {
         AllocateResourceRequest sr = new AllocateResourceRequest
         {
            Language = language,
            Specialty = specialty
         };

         return await this.RunAsync(() => m_handler.Handle(sr));
      }
   }
}
