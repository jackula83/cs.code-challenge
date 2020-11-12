using MediatR;
using ResourceApplicationEntities.Requests;
using ResourceApplicationEntities.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ResourceFinder.Interfaces
{
   public interface ILanguageListHandler : IRequestHandler<LanguageListRequest, LanguageListResponse>
   {
   }
}
