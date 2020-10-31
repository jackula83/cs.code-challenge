using ResourceEntities.Interfaces.Business;
using System;
using System.Collections.Generic;
using System.Text;

namespace AllocationStrategy.Interfaces
{
   public interface IStrategyContext
   {
      ISalesPerson ApplyRuleSet(List<ISalesPerson> a_personList);
   }
}
