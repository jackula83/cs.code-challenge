using MediatR;
using ResourceApplicationEntities.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace ResourceApplicationEntities.Requests
{
   public class LanguageListRequest : CommandRequest, IRequest<LanguageListResponse>
   {
   }
}
