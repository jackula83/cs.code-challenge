using ResourceEntities.Interfaces.Application;
using System;
using System.Collections.Generic;
using System.Text;

namespace ResourceEntities.Interfaces.Business
{
   public interface ISpecialty : IFactoryObject
   {
      string Id { get; }
      string SpecialtyCriteria { get; }
   }
}
