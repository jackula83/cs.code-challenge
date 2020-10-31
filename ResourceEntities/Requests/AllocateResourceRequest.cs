using ResourceEntities.Interfaces.Business;
using ResourceEntities.Interfaces.Fx;
using ResourceEntities.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ResourceEntities.Requests
{
   public class AllocateResourceRequest : IRequest
   {
      public string Language { get; set; }
      public string Specialty { get; set; }
   }
}
