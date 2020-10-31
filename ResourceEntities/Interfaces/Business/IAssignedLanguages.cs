using ResourceEntities.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ResourceEntities.Interfaces.Business
{
   public interface IAssignedLanguages
   {
      List<ILanguage> LanguageList { get; }
   }
}
