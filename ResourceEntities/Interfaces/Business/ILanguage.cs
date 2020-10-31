using ResourceEntities.Interfaces.Application;
using System;
using System.Collections.Generic;
using System.Text;

namespace ResourceEntities.Interfaces.Business
{
   public interface ILanguage : IFactoryObject
   {
      string Name { get; }
   }
}
