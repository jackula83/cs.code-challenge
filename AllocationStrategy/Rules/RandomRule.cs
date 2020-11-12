using ResourceBusinessEntities.Interfaces.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AllocationStrategy.Rules
{
   public class RandomRule : Rule
   {
      public RandomRule(string a_language, string a_specialty) : base(a_language, a_specialty) { }

      public override ISalesPerson ApplyRule(List<ISalesPerson> a_personList)
         => this.ChooseRandom(a_personList);
   }
}
