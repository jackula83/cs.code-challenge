﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ResourceEntities.Responses;
using ResourceFinder.Interfaces;

namespace ResourceFinder.Controllers
{
   [Route("[controller]")]
   [ApiController]
   public class LanguageController : CommonController<ILanguageListHandler>
   {
      public LanguageController(ILanguageListHandler a_handler) : base(a_handler) { }

      [HttpGet]
      public async Task<ActionResult> Get()
         => await this.RunAsync(() => m_handler.Handle(null));
   }
}