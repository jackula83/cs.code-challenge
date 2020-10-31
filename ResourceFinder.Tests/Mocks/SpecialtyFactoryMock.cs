using ResourceEntities.BaseClasses;
using ResourceEntities.Interfaces.Application;
using ResourceEntities.Interfaces.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ResourceFinder.Tests.Mocks
{
   public class SpecialtyFactoryMock : AbstractFactory<ISpecialtyModel, string>, ISpecialtyFactory
   {
      private readonly List<ISpecialtyModel> m_languageList = new List<ISpecialtyModel>
      {
         new SpecialtyModelMock(),
         new SpecialtyModelMock(),
         new SpecialtyModelMock(),
         new SpecialtyModelMock()
      };

      protected override bool IgnoreInit => true;

      public override List<ISpecialtyModel> Enumerate()
         => m_languageList;

      public override ISpecialtyModel GetObject(string a_id)
        => m_languageList.FirstOrDefault(x => x.Id == a_id);

      public override void Register(ISpecialtyModel a_obj)
         => m_languageList.Add(a_obj);
   }
}
