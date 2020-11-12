using ResourceBusinessEntities.BaseClasses;
using ResourceBusinessEntities.Interfaces.Application;
using ResourceBusinessEntities.Interfaces.Features;
using ResourceBusinessEntities.Interfaces.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace ResourceServices
{
   public class SpecialtyFactoryService : AbstractFactory<ISpecialtyModel, string>, ISpecialtyFactory
   {
      #region Attributes
      // if this gets too big, use a dictionary instead
      private List<ISpecialtyModel> m_specialtyList = new List<ISpecialtyModel>();
      #endregion // Attributes

      #region Properties
      protected override bool IgnoreInit => false;
      #endregion // Properties

      public override ISpecialtyModel GetObject(string a_id)
         => m_specialtyList.FirstOrDefault(x => x.Id == a_id);

      public override void Register(ISpecialtyModel a_specialty)
      {
         if (this.GetObject(a_specialty.Id) != default)
            throw new Exception($"Programming error: specialty with ID { a_specialty.Id } is duplicated.");

         m_specialtyList.Add(a_specialty);
      }

      public override List<ISpecialtyModel> Enumerate()
         => m_specialtyList;
   }
}
