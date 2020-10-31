using ResourceEntities.Interfaces.Business;
using ResourceEntities.Models.Language;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AllocationStrategy.Rules
{
   public abstract class Rule
   {
      #region Attributes
      protected string m_language = default;
      protected string m_specialty = default;
      #endregion // Attributes

      #region Properties
      /// <summary>
      /// Allows rule nesting that circumvents the rule order of a particular rule set,
      /// <see cref="TradieVehicleRule"/> for an implementation of nested rules.
      /// </summary>
      public Rule InnerRule { get; set; } = default;
      #endregion // Properties

      public Rule(string a_language, string a_specialty)
      {
         m_language = a_language;
         m_specialty = a_specialty;
      }

      protected static string DefaultLanguage = new EnglishLanguageModel().Name;

      public abstract ISalesPerson ApplyRule(List<ISalesPerson> a_personList);

      #region Helpers
      protected ISalesPerson ChooseRandom(List<ISalesPerson> a_personList)
      {
         if (a_personList.Count > 0)
         {
            Random rand = new Random();

            return a_personList[rand.Next(a_personList.Count)];
         }

         return default;
      }

      protected ISalesPerson ChooseFirst(List<ISalesPerson> a_personList, string a_language = default, string a_specialty = default)
         => a_personList.FirstOrDefault(p =>
               (a_language == default || p.LanguageList.FirstOrDefault(l => l.Name == a_language) != default)
            && (a_specialty == default || p.SpecialtyList.FirstOrDefault(s => s.SpecialtyCriteria == a_specialty) != default));

      //protected ISalesPerson ChooseTradieSpecialty(List<ISalesPerson> a_personList)
      //   => a_personList.FirstOrDefault(p => p.SpecialtyList.FirstOrDefault(x => x is TradieVehicleSpecialtyModel) != default);
      #endregion // Helpers
   }
}
