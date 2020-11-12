using ResourceBusinessEntities.Interfaces.Application;
using ResourceBusinessEntities.Utilities;
using ResourceCommonEntities.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ResourceBusinessEntities.Interfaces.Models
{
   public interface ISalesPerson : IPerson, IAssignedLanguages, IAssignedSpecialties, IFactoryObject
   {
   }
}
