using System;
using System.Collections.Generic;
using System.Text;

namespace ResourceBusinessEntities.Interfaces.Models
{
   public interface IAssignedSpecialties
   {
      List<ISpecialty> SpecialtyList { get; }
   }
}
