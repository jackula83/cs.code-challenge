using ResourceBusinessEntities.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ResourceBusinessEntities.Interfaces.Models
{
   public interface IAssignedLanguages
   {
      List<ILanguage> LanguageList { get; }
   }
}
