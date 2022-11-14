using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
namespace middleeast_project
{
    public class connection
    {
        public static string getconnectionstrings()
        {
            return ConfigurationManager.ConnectionStrings["cs"].ConnectionString;
        }

    }
    public class utlis
    {
        public static bool IsValidExtension(string filename)
        {
            bool isValid = false;
            string[] fileExtension = { ".jpg", ".png", ".jpeg" };
            for (int i = 0; i <= fileExtension.Length - 1; i++)
            {
                if (filename.Contains(fileExtension[i]))
                {
                    isValid = true;
                    break;
                }
            }
            return isValid;
        }
    }
        
}