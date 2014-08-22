using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Age_UIChangePassword
{
    public string divTitle = "//div[@id='header_main' and text()='Change Password']";
    //public string txtUserNametemp = "TxtUsern";
    public string txtOldPassword = "txtOldPwd";
    public string txtPassword = "txtNewPwd";
    public string txtConfirmPassword = "txtConfirmPwd";
    //public string btnSubmit = "//input[@class='log_button' and @type='submit']";
    public string btnSubmit = "//input[@value='Submit']";
    public string btnReset = "//input[@value='Reset']";
    public string divErrMessage = "spmsgerr";
    public string lblOldPassword = "//td[text()='Old Password']";
    public string lblPassword = "//td[text()='Password']";
    public string lblConfirmPassword = "//td[text()='Confirm Password']";
}

