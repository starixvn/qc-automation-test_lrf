using System;
using System.IO;
using System.Diagnostics;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using Selenium;
using NUnit.Core;

namespace SeleniumTests
{
    public class Utility
    {
        public Boolean isNumeric(string str)
        {
            try
            {
                double.Parse(str);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public void checkvalue(string value1, string strOperator, string value2, string strPassMsg, string strFailMsg)
        { 
            // if value is numeric
            if (isNumeric(value1) == true && isNumeric(value2) == true)
            {
                double strTmp1 = Convert.ToDouble(value1);
                double strTmp2 = Convert.ToDouble(value2);
                switch(strOperator)
                {
                    case ">":
                        if (strTmp1 > strTmp2)
                        {
                            Console.WriteLine(strPassMsg);
                        }
                        else 
                        {
                            Console.WriteLine(strFailMsg);
                        }
                        break;
                    case "<":
                        break;
                }

            }

        }
    }
}
