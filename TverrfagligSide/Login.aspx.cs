using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BL;

namespace TverrfagligSide
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Login1_Authenticate(object sender, AuthenticateEventArgs e)
        {
            BLayer BL = new BLayer();
            int count = BL.GetUserCountByUsername(Login1.UserName,Login1.Password);

            if (count==1)
            {
                e.Authenticated = true;
            }
        }
       
    }
}