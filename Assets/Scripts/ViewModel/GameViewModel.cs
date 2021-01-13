using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class GameViewModel 
{
    private static WebRequestHandler WebRequestHandler;
    private static GameViewModel sInstance;
    public static GameViewModel  GetInstance()
    {
        if (sInstance == null)
        {
            sInstance = new GameViewModel();
            WebRequestHandler = WebRequestHandler.GetInstance();
        }
        return sInstance;
    }
    public async Task<List<Game>> GetAllGames()
    {   
        return await WebRequestHandler.HttpsGetArray<List<Game>>(Api.GAMES_URL);
    }
    public async Task<GameData> GetGameById(string game_id)
    {
        return await WebRequestHandler.HttpsGet<GameData>(Api.GAMES_URL+"/"+ game_id);
    }
    public async Task<Sprite> GetGameIcon(string uri)
    {
        Texture2D texture=await WebRequestHandler.HttpsGetTexture(uri);
        return Sprite.Create(texture as Texture2D, new Rect(0f, 0f, texture.width, texture.height), Vector2.zero);
    }
    public async Task<List<Challenge>> GetGameFinishedChallenges(string game_id)
    {
        return await WebRequestHandler.HttpsGet<List <Challenge>> (Api.FINISHED_CHALLENGES_URL+ game_id);
    }

}
