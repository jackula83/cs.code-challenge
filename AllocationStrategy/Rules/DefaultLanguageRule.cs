using ResourceBusinessEntities.Interfaces.Models;
using ResourceBusinessEntities.Models.Language;
using System;
using System.Collections.Generic;
using System.Text;

namespace AllocationStrategy.Rules
{
   public class DefaultLanguageRule : Rule
   {
      public DefaultLanguageRule(string a_language, string a_specialty) : base(a_language, a_specialty) { }

      public override ISalesPerson ApplyRule(List<ISalesPerson> a_personList)
      {
         // only apply if default language and choose someone regardless of language
         if (m_specialty != default && (m_language == default || string.Compare(m_language, Rule.DefaultLanguage, true) == 0))
            return this.ChooseFirst(a_personList, default, m_specialty);

         return default;
      }
   }
}
