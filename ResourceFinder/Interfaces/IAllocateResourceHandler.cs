using MediatR;
using ResourceApplicationEntities.Requests;
using ResourceApplicationEntities.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace ResourceFinder.Interfaces
{
   public interface IAllocateResourceHandler : IRequestHandler<AllocateResourceRequest, AllocateResourceResponse>
   {
   }
}
