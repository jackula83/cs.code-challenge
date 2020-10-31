using ResourceEntities.Interfaces.Application;
using ResourceEntities.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ResourceEntities.Interfaces.Business
{
   public interface ISalesPerson : IPerson, IAssignedLanguages, IAssignedSpecialties, IFactoryObject
   {
   }
}
