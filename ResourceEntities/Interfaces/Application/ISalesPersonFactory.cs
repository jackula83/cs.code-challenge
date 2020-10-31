using ResourceEntities.Interfaces.Business;
using ResourceEntities.Models.Database;
using System;
using System.Collections.Generic;
using System.Text;

namespace ResourceEntities.Interfaces.Application
{
   public interface ISalesPersonFactory : IAbstractFactory<ISalesPerson, SalesPersonDataModel>
   {
   }
}
