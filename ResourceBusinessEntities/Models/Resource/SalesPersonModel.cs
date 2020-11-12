using ResourceBusinessEntities.Interfaces.Models;
using ResourceBusinessEntities.Models.Language;
using ResourceBusinessEntities.Models.Specialty;
using ResourceBusinessEntities.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ResourceBusinessEntities.Models.Resource
{
   /// <summary>
   /// Represents a sales person, where each sales person is a new instance of this class. This decision is because I
   /// felt sales people are more variable, as opposed to specialty areas which are fixed.
   /// </summary>
   public class SalesPersonModel : ISalesPerson
   {
      #region Properties
      public string Name { get; }
      public List<ILanguage> LanguageList { get; }
      public List<ISpecialty> SpecialtyList { get; }
      #endregion // Properties

      public SalesPersonModel(string a_name, List<ILanguage> a_languageList, List<ISpecialty> a_specialtyList)
      {
         this.Name = a_name;
         this.LanguageList = a_languageList;
         this.SpecialtyList = a_specialtyList;
      }
   }
}
