using ResourceBusinessEntities.Interfaces.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ResourceBusinessEntities.Models.Language
{
   public abstract class LanguageModel
   {
      public string FileName { get; set; }
      public string Name { get; set; }

      public LanguageModel(string a_name, string a_imageFile)
      {
         this.Name = a_name;
         this.FileName = a_imageFile;
      }
   }
}
