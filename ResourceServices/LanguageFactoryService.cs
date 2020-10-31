using ResourceEntities.BaseClasses;
using ResourceEntities.Interfaces.Application;
using ResourceEntities.Interfaces.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ResourceServices
{
   public class LanguageFactoryService : AbstractFactory<ILanguageModel, Type>, ILanguageFactory
   {
      #region Attributes
      private List<ILanguageModel> m_languageList = new List<ILanguageModel>();
      #endregion // Attributes

      #region Properties
      protected override bool IgnoreInit => false;
      #endregion // Properties

      public override ILanguageModel GetObject(Type a_id)
         => m_languageList.FirstOrDefault(x => x.GetType() == a_id);

      public override void Register(ILanguageModel a_language)
      {
         if (this.GetObject(a_language.GetType()) != default)
            throw new Exception($"Programming error: language of type { a_language.Name } is duplicated.");

         m_languageList.Add(a_language);
      }

      public override List<ILanguageModel> Enumerate()
         => m_languageList;
   }
}
