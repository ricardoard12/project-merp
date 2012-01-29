using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Database;

namespace DAL.Selections {
   public abstract class ASelection
   {
       
       public static db_MERPEntities1 MerpDatabase() {
          return DatabaseFactory.getDatabase();     
       }
   }
}
