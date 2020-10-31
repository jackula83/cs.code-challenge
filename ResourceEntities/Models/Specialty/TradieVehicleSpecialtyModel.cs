using ResourceEntities.Interfaces.Business;
using System;
using System.Collections.Generic;
using System.Text;

namespace ResourceEntities.Models.Specialty
{
   public class TradieVehicleSpecialtyModel : SpecialtyModel, ISpecialtyModel
   {
      public TradieVehicleSpecialtyModel() : base("D", "Tradie Vehicle", "tradievehicle.png") { }
   }
}
