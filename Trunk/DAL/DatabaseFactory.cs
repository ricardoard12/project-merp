using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Database;

namespace DAL {
    public class DatabaseFactory
    {

        public static db_MERPEntities1 _database;

        public static db_MERPEntities1  getDatabase() {
            return _database ?? (_database = new db_MERPEntities1());
        }
    }
}
