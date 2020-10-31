using ResourceEntities.Interfaces.Business;
using ResourceEntities.Models.Language;
using System;
using System.Collections.Generic;
using System.Text;

namespace ResourceFinder.Tests.Mocks
{
   public class LanguageModelMock : LanguageModel, ILanguageModel
   {
      public LanguageModelMock() : base(Guid.NewGuid().ToString(), default) { }
   }
}
