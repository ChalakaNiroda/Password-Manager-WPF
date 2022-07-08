using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//created by chalaka niroda
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace gui_project1
{
    class validation
    {
        //created by chalaka niroda
        //created by chalaka niroda

        public int emailvalidation(string email)
        {

           
            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            Match match = regex.Match(email);
               if (match.Success)
               {
                return 1;
               }

               else
                 {
                return 0;
                 }
                

        }
    }
}
