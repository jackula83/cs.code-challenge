using ResourceBusinessEntities.Interfaces.Models;
using ResourceBusinessEntities.Models.Database;
using ResourceCommonEntities.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ResourceBusinessEntities.Interfaces.Features
{
   public interface ISalesPersonFactory : IAbstractFactory<ISalesPerson, SalesPersonDataModel>
   {
   }
}
