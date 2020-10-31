using AllocationStrategy.Rules;
using ResourceEntities.Interfaces.Business;
using System;
using System.Collections.Generic;
using System.Text;

namespace AllocationStrategy.Contexts
{
   internal abstract class CommonStrategy<TObjectType>
      where TObjectType : class
   {
      protected List<Rule> RuleList { get; }

      public CommonStrategy(List<Rule> a_ruleList)
      {
         this.RuleList = a_ruleList;
      }

      public TObjectType ApplyRuleSet(List<TObjectType> a_objectList)
      {
         if (a_objectList.Count == 0)
            return default;

         foreach (var rule in this.RuleList)
         {
            TObjectType result = this.ApplyRuleRecursively(rule, a_objectList);
            if (result != default)
               return result;
         }

         return default;
      }


      protected virtual TObjectType ApplyRuleRecursively(Rule a_rule, List<TObjectType> a_objectList)
      {
         TObjectType result = this.ApplyRule(a_rule, a_objectList);

         if (result == default && a_rule.InnerRule != default)
            return this.ApplyRuleRecursively(a_rule.InnerRule, a_objectList);

         return result;
      }

      protected abstract TObjectType ApplyRule(Rule a_rule, List<TObjectType> a_objectList);
   }
}
