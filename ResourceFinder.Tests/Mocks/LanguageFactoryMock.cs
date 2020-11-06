using ResourceBusinessEntities.BaseClasses;
using ResourceBusinessEntities.Interfaces.Application;
using ResourceBusinessEntities.Interfaces.Features;
using ResourceBusinessEntities.Interfaces.Models;
using ResourceBusinessEntities.Models.Language;
using System;
using System.Collections.Generic;
using System.Text;

namespace ResourceFinder.Tests.Mocks
{
   public class LanguageFactoryMock : AbstractFactory<ILanguageModel, Type>, ILanguageFactory
   {
      private readonly List<ILanguageModel> m_languageList = new List<ILanguageModel>
      {
         new LanguageModelMock(),
         new LanguageModelMock(),
         new LanguageModelMock(),
         new LanguageModelMock()
      };

      protected override bool IgnoreInit => true;

      public override List<ILanguageModel> Enumerate()
         => m_languageList;

      public override ILanguageModel GetObject(Type a_id)
         => m_languageList[0];

      public override void Register(ILanguageModel a_obj)
         => this.m_languageList.Add(a_obj);
   }
}
