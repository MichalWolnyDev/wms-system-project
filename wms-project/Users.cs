using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wms_project
{
    class Users
    {
        public string uname;
        public string upassword;
        public bool isAdmin;

        public void setUsers(string name, string password, bool isAdmin)
        {
            this.uname = name;
            this.upassword = password;
            this.isAdmin = isAdmin;
        }
    }
}
