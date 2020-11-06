using ResourceBusinessEntities.Interfaces.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AllocationStrategy.Rules
{
   public class NonDefaultLanguageRule : Rule
   {
      public NonDefaultLanguageRule(string a_language, string a_specialty) : base(a_language, a_specialty) { }

      public override ISalesPerson ApplyRule(List<ISalesPerson> a_personList)
      {
         // only apply if non-default language and no specialty
         if (string.Compare(m_language, Rule.DefaultLanguage, true) != 0)
            return this.ChooseFirst(a_personList, m_language, m_specialty);

         return default;
      }
   }
}
