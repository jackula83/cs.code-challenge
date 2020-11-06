using ResourceCommonEntities.Interfaces;
using System.IO;
using System.Threading.Tasks;

namespace ResourceServices
{
   public class DataAccessService : IDataAccess
   {
      public async Task<string> Select()
      {
         using (StreamReader reader = new StreamReader("salesperson.json"))
         {
            return await reader.ReadToEndAsync();
         }
      }
   }
}
