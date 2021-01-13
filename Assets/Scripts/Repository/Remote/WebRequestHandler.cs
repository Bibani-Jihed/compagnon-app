
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;

/// <summary>
/// This class does Handler all REST API Request/response of the entire application.
/// the HttpsGetHandler(string uri) is the responsible of GETs Requests, return the response on string format  
/// the HttpsPostHandler(string uri, WWWForm postData) is the responsible of POSTs Requests, initialize the header params from APIHeader class and returns the response on string format  
/// </summary>



[CLSCompliant(false)]
public class WebRequestHandler : MonoBehaviour
{

    private static WebRequestHandler sInstance;
    void Awake()
    {
        Debug.Log("initializing WebRequestHandler");
        sInstance = this;
    }
    public static WebRequestHandler GetInstance()
    {
        if (sInstance == null) sInstance = new WebRequestHandler();
        return sInstance;
    }

    public async Task<string> HttpsGetHandler(string uri)
    {
        
        UnityWebRequest www = UnityWebRequest.Get(uri);
        if (ApiHeader.getAccessToken() != null)
        {
            www.SetRequestHeader(ApiHeader.access_token_header, ApiHeader.getAccessToken());
        }
        var res = await HandleRequest(www);
        
        return res;
    }
    public async Task<string> HttpsPostHandler(string uri, WWWForm postData)
    {
        //Execute Request
        UnityWebRequest www = UnityWebRequest.Post(uri, postData);
        var token = ApiHeader.getAccessToken();
        if (token != null)
        {
            www.SetRequestHeader("x-access-token", token);
            www.SetRequestHeader("content-type", "application/x-www-form-urlencoded");
        }
        var res = await HandleRequest(www);
        return res;
    }
    public async Task<T> HttpsGetArray<T>(string uri)
    {
        string res = await HttpsGetHandler(uri);
        Debug.Log(res);
        var generatedType = JsonConvert.DeserializeObject<T>(res);
        return (T)Convert.ChangeType(generatedType, typeof(T));
    }
    public async Task<T> HttpsGet<T>(string uri)
    {
        string res = await HttpsGetHandler(uri);
        Debug.Log(res);
        var generatedType = JsonConvert.DeserializeObject<GenericResponse<T>>(res);
        return (T)Convert.ChangeType(generatedType.data, typeof(T));

    }
    public async Task<Texture2D> HttpsGetTexture(string uri)
    {
        Debug.Log(Application.persistentDataPath + "/avatar.png");
        if (!string.IsNullOrEmpty(PlayerPrefs.GetString(uri)))
        {
            //Get Image URI from local storage
            uri = PlayerPrefs.GetString(uri);
        }
        UnityWebRequest uwr = UnityWebRequestTexture.GetTexture(uri);
        await  uwr.SendWebRequest();
        if (uwr.isNetworkError || uwr.isHttpError)
        {
            return null;
        }
        else
        {
           
            if (string.IsNullOrEmpty(PlayerPrefs.GetString(uri)))
            {
                var hash = uri.GetHashCode();
                System.IO.File.WriteAllBytes(Application.persistentDataPath + "/"+ hash + ".png", uwr.downloadHandler.data);
                PlayerPrefs.SetString(uri, Application.persistentDataPath + "/" + hash + ".png");
            }
            // Get downloaded asset bundle
            return  DownloadHandlerTexture.GetContent(uwr);
            
        }

    }
    public async Task<T> HttpsPost<T>(string uri, WWWForm postData)
    {
        string res = await HttpsPostHandler(uri, postData);
        Debug.Log(res);
        var generatedType = JsonConvert.DeserializeObject<GenericResponse<T>>(res);
        //Save Token if user logged in
        if (!string.IsNullOrEmpty(generatedType.token)) ApiHeader.setAccessToken(generatedType.token);
        //return data in specific type
        return (T)Convert.ChangeType(generatedType.data, typeof(T));
    }


    private async Task<string> HandleRequest(UnityWebRequest www)
    {
        await www.SendWebRequest();

        if (www.error != null)
        {
            //ThrowException
        }
        return www.downloadHandler.text;
    }
}
