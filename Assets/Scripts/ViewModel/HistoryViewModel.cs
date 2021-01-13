using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class HistoryViewModel : MonoBehaviour
{
    private static WebRequestHandler WebRequestHandler;
    private static HistoryViewModel sInstance;
    // Start is called before the first frame update
    public static HistoryViewModel GetInstance()
    {
        if (sInstance == null)
        {
            sInstance = new HistoryViewModel();
            WebRequestHandler = WebRequestHandler.GetInstance();
        }
        return sInstance;
    }
    void Start()
    {

    }
    public async Task<Game> GetGame(string game_id)
    {
        GameData gameData = await GameViewModel.GetInstance().GetGameById(game_id);
        return gameData.game;
    }
    public async Task<Sprite> GetGameIcon(string uri)
    {
        return await GameViewModel.GetInstance().GetGameIcon(uri);
    }
    public async Task<List<Challenge>> GetGameFinishedChallenges(string game_id)
    {
        return await GameViewModel.GetInstance().GetGameFinishedChallenges(game_id);
    }
    public async Task<Sprite> GetAvatar(string uri)
    {
        Texture2D texture = await WebRequestHandler.HttpsGetTexture(uri);
        Texture2D RoundTxt = ImageCropper.RoundCrop(texture);
        return Sprite.Create(RoundTxt as Texture2D, new Rect(0f, 0f, RoundTxt.width, RoundTxt.height), Vector2.zero);
    }
    // Update is called once per frame
    void Update()
    {

    }
}
