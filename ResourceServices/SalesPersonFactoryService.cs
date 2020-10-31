using ResourceEntities.BaseClasses;
using ResourceEntities.Interfaces.Application;
using ResourceEntities.Interfaces.Business;
using ResourceEntities.Models;
using ResourceEntities.Models.Database;
using ResourceEntities.Models.Language;
using ResourceEntities.Models.Resource;
using ResourceEntities.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ResourceServices
{
   public class SalesPersonFactoryService : AbstractFactory<ISalesPerson, SalesPersonDataModel>, ISalesPersonFactory
   {
      #region Attributes
      private ISpecialtyFactory m_specialtyFactory = default;
      #endregion // Attributes

      #region Properties
      protected override bool IgnoreInit => true;
      #endregion // Properties

      public SalesPersonFactoryService(ISpecialtyFactory a_specialtyFactory) : base()
         => m_specialtyFactory = a_specialtyFactory;

      public override ISalesPerson GetObject(SalesPersonDataModel a_model)
      {
         List<ISpecialty> specialityList = new List<ISpecialty>();

         foreach (var groupId in a_model.Groups.Where(g => g != Constants.GreekLanguageGroupID))
            specialityList.Add(m_specialtyFactory.GetObject(groupId));

         // the database schema appears to compromise the single responsibility principle by collating language and specialty settings together 
         // into one group. I've decided to model the backend in a way so that language and specialities are separate entities. Can be expanded
         // upon for additional supported languages.
         ILanguage language = default;

         if (a_model.Groups.FirstOrDefault(g => g == Constants.GreekLanguageGroupID) == default)
            language = new EnglishLanguageModel();
         else
            language = new GreekLanguageModel();

         // pass language as list to allow additional future languages
         return new SalesPersonModel(a_model.Name, new List<ILanguage> { language }, specialityList);
      }

      public override void Register(ISalesPerson a_specialty)
      {
         // do nothing, perhaps send this to elasticache in the future
      }

      public override List<ISalesPerson> Enumerate()
         => new List<ISalesPerson>();
   }
}
