using ResourceBusinessEntities.Interfaces.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ResourceApplicationEntities.Responses
{
   public class SpecialtyListResponse : CommandResponse
   {
      public List<ISpecialtyModel> Result { get; set; }
   }
}
