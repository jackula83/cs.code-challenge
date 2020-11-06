using ResourceBusinessEntities.Interfaces.Application;
using ResourceCommonEntities.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ResourceFinder.Tests.Mocks
{
   public class DataAccessMock : IDataAccess
   {
      public async Task<string> Select()
      {
         // exactly the same as salesperson.json, simply demonstrating dependency inversion :)
         return await Task.Run(() => "[{\"Name\":\"Cierra Vega\",\"Groups\":[\"A\"]},{\"Name\":\"Alden Cantrell\",\"Groups\":[\"B\",\"D\"]},{\"Name\":\"Kierra Gentry\",\"Groups\":[\"A\",\"C\"]},{\"Name\":\"Pierre Cox\",\"Groups\":[\"D\"]},{\"Name\":\"Thomas Crane\",\"Groups\":[\"A\",\"B\"]},{\"Name\":\"Miranda Shaffer\",\"Groups\":[\"B\"]},{\"Name\":\"Bradyn Kramer\",\"Groups\":[\"D\"]},{\"Name\":\"Alvaro Mcgee\",\"Groups\":[\"A\",\"D\",\"C\"]}]");
      }
   }
}
