using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApiHeader : MonoBehaviour
{
    public const string access_token_header = "x-access-token";
    public const string authorization = "Authorization";

    private static string access_token;
    private static string api_key;
    public static string getAccessToken()
    {
        if (string.IsNullOrEmpty(access_token))
            access_token = PlayerPrefs.GetString("access_token");
        return access_token;
    }
    public static void setAccessToken(string accessToken)
    {
        Debug.Log(accessToken);
        access_token = accessToken;
        PlayerPrefs.SetString("access_token", access_token);
    }
    public static void DeleteSavedToken()
    {
        PlayerPrefs.DeleteKey("access_token");
    }
    public static string getApiKey()
    {
        return api_key;
    }
   
}
