using ResourceBusinessEntities.Interfaces.Application;
using ResourceCommonEntities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ResourceBusinessEntities.BaseClasses
{
   public abstract class AbstractFactory<TObjectType, TIdentifierType> : IAbstractFactory<TObjectType, TIdentifierType>
      where TObjectType : IFactoryObject
      where TIdentifierType : class
   {
      protected abstract bool IgnoreInit { get; }

      public AbstractFactory()
      {
         if (IgnoreInit)
            return;

         // get all specialties
         IEnumerable<Type> typeList = AppDomain.CurrentDomain.GetAssemblies()
             .SelectMany(a => a.GetTypes())
             .Where(t => typeof(TObjectType).IsAssignableFrom(t) && !t.IsInterface);

         // store a single copy in memory
         foreach (var t in typeList)
            this.Register((TObjectType)Activator.CreateInstance(t));
      }

      public abstract TObjectType GetObject(TIdentifierType a_id);

      public abstract void Register(TObjectType a_obj);

      public abstract List<TObjectType> Enumerate();
   }
}
