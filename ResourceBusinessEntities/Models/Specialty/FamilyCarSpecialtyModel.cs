using ResourceBusinessEntities.Interfaces.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ResourceBusinessEntities.Models.Specialty
{
   public class FamilyCarSpecialtyModel : SpecialtyModel, ISpecialtyModel
   {
      public FamilyCarSpecialtyModel() : base("C", "Family Car", "familyvehicle.png") { }
   }
}
