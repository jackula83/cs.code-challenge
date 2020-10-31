using ResourceEntities.Interfaces.Business;
using ResourceEntities.Interfaces.Fx;
using System;
using System.Collections.Generic;
using System.Text;

namespace ResourceEntities.Responses
{
   public class SpecialtyListResponse : IResponse
   {
      public List<ISpecialtyModel> Result { get; set; }
   }
}
