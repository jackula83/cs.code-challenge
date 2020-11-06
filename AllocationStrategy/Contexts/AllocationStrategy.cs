using AllocationStrategy.Contexts;
using AllocationStrategy.Interfaces;
using AllocationStrategy.Rules;
using ResourceBusinessEntities.Interfaces.Models;
using System;
using System.Collections.Generic;

namespace AllocationStrategy
{
   internal class AllocationStrategy : CommonStrategy<ISalesPerson>, IStrategyContext
   {
      public AllocationStrategy(List<Rule> a_ruleList) : base(a_ruleList) { }

      protected override ISalesPerson ApplyRule(Rule a_rule, List<ISalesPerson> a_objectList)
         => a_rule.ApplyRule(a_objectList);
   }
}
