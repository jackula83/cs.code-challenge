using ResourceBusinessEntities.Interfaces.Models;
using ResourceBusinessEntities.Interfaces.Application;
using System;
using System.Collections.Generic;
using System.Text;

namespace ResourceBusinessEntities.Models.Language
{
   /// <summary>
   /// The default, generic English mongrel
   /// </summary>
   public class EnglishLanguageModel : LanguageModel, ILanguageModel, IImageFile
   {
      public EnglishLanguageModel() : base("English", "englishflag.png")
      {
      }
   }
}
