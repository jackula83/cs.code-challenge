using AllocationStrategy.Rules;
using System;
using System.Collections.Generic;
using System.Text;

namespace AllocationStrategy.Interfaces
{
   public interface IRuleSet
   {
      IStrategyContext CreateStrategyContext(string a_language, string a_specialty);
   }
}
