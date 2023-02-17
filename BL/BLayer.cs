using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBL; 

namespace BL
{
    public class BLayer
    {
        private DBLayer dbl = new DBLayer();
        public int GetUserCountByUsername(string username, string password)
        {
            return dbl.GetUserCountByUsername(username, password);
        }
        public void CreateUser(string username, string password, string mail)
        {
            int id = dbl.InsertUser(username, password, mail);
            string un = username + "#" + GenerateCodeFromId(id);
            //todo UPDATE this user - we have the unique id...
        }
        private string GenerateCodeFromId(int id)
        {
            if (id.ToString().Length == 1)
                return "000" + id;
            if (id.ToString().Length == 2)
                return "00" + id;
            if (id.ToString().Length == 3)
                return "0" + id;
            if (id.ToString().Length == 4)
                return id.ToString();
            return "error";
        }
    }
}
