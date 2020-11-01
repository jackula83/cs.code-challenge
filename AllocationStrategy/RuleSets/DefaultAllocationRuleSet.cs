using AllocationStrategy.Interfaces;
using AllocationStrategy.Rules;
using ResourceEntities.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace AllocationStrategy.RuleSets
{
   public class DefaultAllocationRuleSet : IRuleSet
   {
      public IStrategyContext CreateStrategyContext(string a_language, string a_specialty)
      {
         List<Rule> ruleList = new List<Rule>
         {
            // special rule for tradie vehicles regardless of language
            new TradieVehicleRule(default, a_specialty),

            // match against both language and specialty
            new NonDefaultLanguageRule(a_language, a_specialty),
            new DefaultLanguageRule(a_language, a_specialty),

            // match against specialty only
            new DefaultLanguageRule(default, a_specialty),

            // match against non-default language only
            new NonDefaultLanguageRule(a_language, default),

            // if nothing matches, just pick a random one
            new RandomRule(default, default)
         };

         return new AllocationStrategy(ruleList);
      }
   }
}
