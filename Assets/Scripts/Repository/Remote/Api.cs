using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Api 
{
    public static readonly string BASE_URL = "https://api.seemba.com";
    public static readonly string API_VERSION = BASE_URL+"/api/v1";
    //Games Services
    public static readonly string GAMES_URL = API_VERSION + "/games";
    //Challenges Services
    public static readonly string FINISHED_CHALLENGES_URL = API_VERSION + "/challenges/finished?game_id=";
    //User Services
    public static readonly string LOGIN_URL = API_VERSION + "/authenticate";
    public static readonly string FLAGS_URL = BASE_URL+ "/flags";


}
