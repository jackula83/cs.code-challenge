using ResourceEntities.Interfaces.Fx;
using ResourceEntities.Requests;
using ResourceEntities.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ResourceFinder.Interfaces
{
   public interface IRosterResetHandler : IRequestResponseHandler<RosterResetRequest, RosterResetResponse>
   {
   }
}
