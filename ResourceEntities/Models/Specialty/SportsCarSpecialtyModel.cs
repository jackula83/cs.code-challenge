using ResourceEntities.Interfaces.Business;
using System;
using System.Collections.Generic;
using System.Text;

namespace ResourceEntities.Models.Specialty
{
   public class SportsCarSpecialtyModel : SpecialtyModel, ISpecialtyModel
   {
      public SportsCarSpecialtyModel() : base("B", "Sports Car", "sportsvehicle.png") { }
   }
}
