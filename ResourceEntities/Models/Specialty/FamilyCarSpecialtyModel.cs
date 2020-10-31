using ResourceEntities.Interfaces.Business;
using System;
using System.Collections.Generic;
using System.Text;

namespace ResourceEntities.Models.Specialty
{
   public class FamilyCarSpecialtyModel : SpecialtyModel, ISpecialtyModel
   {
      public FamilyCarSpecialtyModel() : base("C", "Family Car", "familyvehicle.png") { }
   }
}
