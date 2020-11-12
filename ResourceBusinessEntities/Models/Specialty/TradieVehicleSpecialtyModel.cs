using ResourceBusinessEntities.Interfaces.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ResourceBusinessEntities.Models.Specialty
{
   public class TradieVehicleSpecialtyModel : SpecialtyModel, ISpecialtyModel
   {
      public TradieVehicleSpecialtyModel() : base("D", "Tradie Vehicle", "tradievehicle.png") { }
   }
}
