using ResourceEntities.Interfaces.Fx;
using ResourceEntities.Requests;
using ResourceEntities.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace ResourceFinder.Interfaces
{
   public interface IAllocateResourceHandler : IRequestResponseHandler<AllocateResourceRequest, AllocateResourceResponse>
   {
   }
}
