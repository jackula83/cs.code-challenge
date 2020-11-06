using ResourceBusinessEntities.Interfaces.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ResourceBusinessEntities.Models.Specialty
{
   public class SportsCarSpecialtyModel : SpecialtyModel, ISpecialtyModel
   {
      public SportsCarSpecialtyModel() : base("B", "Sports Car", "sportsvehicle.png") { }
   }
}
