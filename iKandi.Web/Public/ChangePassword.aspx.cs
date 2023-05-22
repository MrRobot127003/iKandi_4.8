using System;
using iKandi.Web;

public partial class ChangePassword : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //ChangePassword1.NewPasswordRegularExpression = @"(?=^.{4,20}$)(?=(?:.*?\d){1})(?=(?:.*?[a-zA-Z]){1})(?=(?:.*?[!@#$%*()_+^&amp;}{:;?.]){1})(?!.*\s)[0-9a-zA-Z!@#$%*()_+^&amp;]*$";
        //ChangePassword1.PasswordHintText =
        //    "Please enter a password at least 4 to 20 characters long, containing a number, a character and one special character.";
        //ChangePassword1.NewPasswordRegularExpressionErrorMessage =
        //    "Error : Please enter a password at least 4 to 20 characters long, containing a number, a character and one special character.";
    }

    protected void ChangePassword1_ChangedPassword(object sender, EventArgs e)
    {
        this.MembershipControllerInstance.SetIsFirstTime(Convert.ToInt32(Session["LoggedUserId"]));
        Session.Remove("LoggedUserId");
    }
   
}