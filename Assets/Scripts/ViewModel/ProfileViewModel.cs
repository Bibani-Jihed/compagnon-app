using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class ProfileViewModel : MonoBehaviour
{
    // Start is called before the first frame update
    private static WebRequestHandler WebRequestHandler;
    private static ProfileViewModel sInstance;

    public static ProfileViewModel GetInstance()
    {
        if (sInstance == null)
        {
            sInstance = new ProfileViewModel();
            WebRequestHandler = WebRequestHandler.GetInstance();
        }
        return sInstance;
    }
    public async Task<Sprite> GetAvatar(string uri)
    {
        
        Texture2D texture = await WebRequestHandler.HttpsGetTexture(uri);
        Texture2D RoundTxt = ImageCropper.RoundCrop(texture);
        return Sprite.Create(RoundTxt as Texture2D, new Rect(0f, 0f, RoundTxt.width, RoundTxt.height), Vector2.zero);
    }
    public async Task<Sprite> GetFlag(string country_code)
    {   
        Texture2D texture = await WebRequestHandler.HttpsGetTexture(Api.FLAGS_URL + "/" + User.CurrentUser.country_code + ".png");
        return Sprite.Create(texture as Texture2D, new Rect(0f, 0f, texture.width, texture.height), Vector2.zero);
    }
    public void Logout()
    {
        LoginViewModel.GetInstance().Logout();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
