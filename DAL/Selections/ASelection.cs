using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Database;

namespace DAL.Selections {
   public abstract class ASelection
   {
       private readonly db_MERPEntities1 _database;

       protected ASelection() {
           _database = DatabaseFactory.getDatabase();
       }

       protected db_MERPEntities1 Database {
           get { return _database; }
       }
   }
}
