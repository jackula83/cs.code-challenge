using ResourceEntities.Interfaces.Business;
using ResourceEntities.Models.Specialty;
using System;
using System.Collections.Generic;
using System.Text;

namespace AllocationStrategy.Rules
{
   public class TradieVehicleRule : Rule
   {
      private static string TradieSpecialtyCriteria = new TradieVehicleSpecialtyModel().SpecialtyCriteria;

      public TradieVehicleRule(string a_language, string a_specialty) : base(a_language, a_specialty) { }

      /// <summary>
      /// Gets the first tradie vehicle specialist available regardless of language
      /// </summary>
      public override ISalesPerson ApplyRule(List<ISalesPerson> a_personList)
      {
         // only apply rule if tradie vehicle has been requested
         if (string.Compare(m_specialty, TradieSpecialtyCriteria, true) == 0)
         {
            //  if matched, allow nested rule because this rule does not follow consistent convention
            this.InnerRule = new RandomRule(default, default);

            return this.ChooseFirst(a_personList, m_language, m_specialty);
         }

         return default;
      }
   }
}
