using System;
using System.Collections.Generic;
using System.Text;

namespace ResourceEntities.Interfaces.Business
{
   public interface IAssignedSpecialties
   {
      List<ISpecialty> SpecialtyList { get; }
   }
}
