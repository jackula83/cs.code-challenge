using ResourceEntities.Interfaces.Business;
using System;
using System.Collections.Generic;
using System.Text;

namespace ResourceEntities.Interfaces.Application
{
   public interface ILanguageFactory : IAbstractFactory<ILanguageModel, Type>
   {
   }
}
