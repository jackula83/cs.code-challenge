using ResourceBusinessEntities.Interfaces.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ResourceBusinessEntities.Models.Specialty
{
   public abstract class SpecialtyModel
   {
      public string Id { get; set; }
      public string SpecialtyCriteria { get; set; }
      public string FileName { get; set; }

      public SpecialtyModel(string a_id, string a_specialty, string a_fileName)
      {
         this.Id = a_id;
         this.SpecialtyCriteria = a_specialty;
         this.FileName = a_fileName;
      }
   }
}
