using System;
using System.Collections.Generic;
using System.Text;

namespace ResourceCommonEntities.Interfaces
{
   public interface IAbstractFactory<TObjectType, TIdentifierType>
      where TObjectType : IFactoryObject
      where TIdentifierType : class
   {
      void Register(TObjectType a_object);
      TObjectType GetObject(TIdentifierType a_id);
      List<TObjectType> Enumerate();
   }
}
