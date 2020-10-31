using ResourceEntities.Interfaces.Business;
using System;
using System.Collections.Generic;
using System.Text;

namespace ResourceEntities.Models.Language
{
   public class GreekLanguageModel : LanguageModel, ILanguageModel
   {
      public GreekLanguageModel() : base("Greek", "greekflag.png") { }
   }
}
