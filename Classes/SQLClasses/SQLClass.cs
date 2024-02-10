using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GBF_Never_Buddy.Classes.SQLClasses
{
    public class SQLClass
    {
        HomePage? homePage;

        public void LockParent()
        {
            var parent = Application.OpenForms["HomePage"];
            if (parent != null)
            {
                homePage = (HomePage)parent;
                homePage.Enabled = false;
            }
        }

        public void UnlockParent()
        {
            var parent = Application.OpenForms["HomePage"];
            if (parent != null)
            {
                homePage = (HomePage)parent;
                homePage.Enabled = true;
            }
        }
    }

}
