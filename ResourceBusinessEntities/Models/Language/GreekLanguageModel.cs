using ResourceBusinessEntities.Interfaces.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ResourceBusinessEntities.Models.Language
{
   public class GreekLanguageModel : LanguageModel, ILanguageModel
   {
      public GreekLanguageModel() : base("Greek", "greekflag.png") { }
   }
}
