using ResourceBusinessEntities.Interfaces.Models;
using ResourceCommonEntities.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ResourceBusinessEntities.Interfaces.Features
{
   public interface ISpecialtyFactory : IAbstractFactory<ISpecialtyModel, string>
   {
   }
}
