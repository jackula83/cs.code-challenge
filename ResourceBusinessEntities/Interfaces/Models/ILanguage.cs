using ResourceBusinessEntities.Interfaces.Application;
using ResourceCommonEntities.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ResourceBusinessEntities.Interfaces.Models
{
   public interface ILanguage : IFactoryObject
   {
      string Name { get; }
   }
}
