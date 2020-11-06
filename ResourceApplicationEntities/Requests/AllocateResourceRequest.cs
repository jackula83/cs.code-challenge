using MediatR;
using ResourceApplicationEntities.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace ResourceApplicationEntities.Requests
{
   public class AllocateResourceRequest : CommandRequest, IRequest<AllocateResourceResponse>
   {
      public string Language { get; set; }
      public string Specialty { get; set; }
   }
}
