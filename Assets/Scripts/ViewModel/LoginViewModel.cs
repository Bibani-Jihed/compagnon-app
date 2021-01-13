using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class LoginViewModel 
{
    // Start is called before the first frame update
    private static WebRequestHandler WebRequestHandler;
    private static LoginViewModel sInstance;
    
    public static LoginViewModel GetInstance()
    {
        if (sInstance == null)
        {
            sInstance = new LoginViewModel();
            WebRequestHandler = WebRequestHandler.GetInstance();
        } 
        return sInstance;
    }
    public async Task<User> Login(string email_username, string password)
    {
        WWWForm form = new WWWForm();
        form.AddField("game_id", "5aa62f71e7c48800057cab19");
        form.AddField("password", password);
        if (RegexUtilities.IsValidEmail(email_username))
        {
            form.AddField("email", email_username);
        }
        else
        {
            form.AddField("username", email_username.ToUpper());
        }
        User user= await WebRequestHandler.HttpsPost<User>(Api.LOGIN_URL, form);
        PlayerPrefs.SetString("CurrentUser", JsonConvert.SerializeObject(user));
        return user;
    }
    public void Logout()
    {
        ApiHeader.DeleteSavedToken();
        PlayerPrefs.DeleteKey("CurrentUser");
    }
}
