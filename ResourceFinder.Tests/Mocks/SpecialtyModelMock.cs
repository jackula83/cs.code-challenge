﻿using ResourceEntities.Interfaces.Business;
using ResourceEntities.Models.Specialty;
using System;
using System.Collections.Generic;
using System.Text;

namespace ResourceFinder.Tests.Mocks
{
   public class SpecialtyModelMock : SpecialtyModel, ISpecialtyModel
   {
      public SpecialtyModelMock() : base(Guid.NewGuid().ToString(), Guid.NewGuid().ToString(), Guid.NewGuid().ToString())
      {
      }
   }
}
