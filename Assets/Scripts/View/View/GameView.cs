using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameView : MonoBehaviour
{
    public GameObject GamePrefab;
    public GameObject Parent;
    public Toggle AllGames,HotGames,YourGames,RecentGames;
    // Start is called before the first frame update
    async void OnEnable()
    {
        Debug.Log(ApiHeader.getAccessToken());
        //Show Loader
        Loader.GetInstance().Show();
        List<Game> games = await GameViewModel.GetInstance().GetAllGames();
        //Hide Loader
        Loader.GetInstance().Hide();
        ShowGames(games);
        AllGames.onValueChanged.AddListener(delegate {
            if (AllGames.isOn)
            {
                ShowGames(games);
            }
        });
        HotGames.onValueChanged.AddListener(delegate {
            if(HotGames.isOn)
                ShowGames(games.GetRange(0,8));
        });
        YourGames.onValueChanged.AddListener(delegate {
            if (YourGames.isOn)
                ShowGames(games.GetRange(0, 6));
        });
        RecentGames.onValueChanged.AddListener(delegate {
            if (RecentGames.isOn)
                ShowGames(games.GetRange(0, 2));
        });
    }
    void ShowGames(List<Game> games)
    {
        Debug.Log("Show " + games.Count + " Games");
        Refresh();

        foreach (Game game in games)
        {
            ShowGame(game);
        }
    }
    private void Refresh()
    {
        foreach(Transform child in Parent.transform)
        {
            Destroy(child.gameObject);
        }
    }
    async void ShowGame(Game game)
    {
        GameObject GameItem = Instantiate(GamePrefab, new Vector3(360, 719, 0), Quaternion.identity, Parent.transform);
        Text GameDesription = GameItem.transform.GetChild(0).GetComponent<Text>();
        Image GameCover = GameItem.transform.GetChild(1).GetComponent<Image>();
        Text GameRate = GameItem.transform.GetChild(2).GetComponent<Text>();
        Text GameName = GameItem.transform.GetChild(3).GetComponent<Text>();
        Button GameInstall = GameItem.transform.GetChild(4).GetComponent<Button>();

        GameDesription.text = game.description;
        GameRate.text = "9.0";
        GameName.text = game.name;
        GameCover.sprite = await GameViewModel.GetInstance().GetGameIcon(game.icon);
        GameInstall.onClick.AddListener(delegate
        {
            
                Application.OpenURL(game.store_link);
        });

    }
    // Update is called once per frame
    void Update()
    {

    }
}
