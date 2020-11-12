using ResourceBusinessEntities.Interfaces.Application;
using ResourceCommonEntities.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ResourceBusinessEntities.Interfaces.Models
{
   public interface ISpecialty : IFactoryObject
   {
      string Id { get; }
      string SpecialtyCriteria { get; }
   }
}
