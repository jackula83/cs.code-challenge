using ResourceBusinessEntities.Interfaces.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ResourceApplicationEntities.Responses
{
   public class LanguageListResponse : CommandResponse
   {
      public List<ILanguageModel> Result { get; set; }
   }
}
