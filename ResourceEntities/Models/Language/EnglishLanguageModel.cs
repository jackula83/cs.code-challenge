using ResourceEntities.Interfaces.Business;
using ResourceEntities.Interfaces.Application;
using System;
using System.Collections.Generic;
using System.Text;

namespace ResourceEntities.Models.Language
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
