using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class HistoryView : MonoBehaviour
{
    public GameObject GameHistoryPrefab;
    public GameObject HistoryPrefab;
    public GameObject Parent;
    // Start is called before the first frame update
    async void Start()
    {
        //Show Loader
        Loader.GetInstance().Show();
        foreach (string game in User.CurrentUser.games)
        {
            ShowGames(await HistoryViewModel.GetInstance().GetGame(game));
        }
        //Hide Loader
        Loader.GetInstance().Hide();
    }
    async void ShowGames(Game game)
    {
        Debug.Log("ShowGameHistory");
        GameObject GameItem = Instantiate(GameHistoryPrefab, new Vector3(360, 719, 0), Quaternion.identity, Parent.transform);
        
        GameObject DetailsContainer = GameItem.transform.GetChild(0).gameObject;
        GameObject HistoryContainer = GameItem.transform.GetChild(1).gameObject;


        Button ShowHistory = DetailsContainer.transform.GetChild(2).GetComponent<Button>();
        Button HideHistory = DetailsContainer.transform.GetChild(3).GetComponent<Button>();
        Text GameName = DetailsContainer.transform.GetChild(0).GetComponent<Text>();
        Image GameIcon = DetailsContainer.transform.GetChild(1).GetComponent<Image>();
        Animator Loader = DetailsContainer.transform.GetChild(4).GetComponent<Animator>();


        GameName.text = game.name;
        GameIcon.sprite = await HistoryViewModel.GetInstance().GetGameIcon(game.icon);


        ShowHistory.onClick.AddListener(async delegate
        {
            Loader.gameObject.SetActive(true);
            
            ShowHistory.gameObject.SetActive(false);
            await ShowGameHistory(game._id, HistoryContainer, GameItem);
            Loader.gameObject.SetActive(false);
            HistoryContainer.SetActive(true);
            HideHistory.gameObject.SetActive(true);

        });
        HideHistory.onClick.AddListener(delegate
        {
            HideHistory.gameObject.SetActive(false);
            ShowHistory.gameObject.SetActive(true);
            foreach (Transform child in HistoryContainer.transform)
            {   
                if(child.childCount!=0)
                    GameObject.Destroy(child.gameObject);
            }
            HistoryContainer.SetActive(false);
        });

    }
    private async Task ShowGameHistory(string game_id, GameObject Parent,GameObject GameItem)
    {   

        List<Challenge> Challenges = await HistoryViewModel.GetInstance().GetGameFinishedChallenges(game_id);
        if (Challenges.Count > 5) Challenges=Challenges.GetRange(0, 5);
        var ChallegesArray = Challenges.ToArray();
        foreach (Challenge challenge in ChallegesArray)
        {   
            if (!string.IsNullOrEmpty(challenge.CreatedAt)&& !string.IsNullOrEmpty(challenge.winner_user))
            {
                GameObject HistoryItem = Instantiate(HistoryPrefab, new Vector3(360, 719, 0), Quaternion.identity, Parent.transform);
                GameObject DetailsContainer = HistoryItem.transform.GetChild(1).gameObject;
                GameObject ResultContainer = HistoryItem.transform.GetChild(2).gameObject;

                Text ChallengeDate = DetailsContainer.transform.GetChild(0).GetComponent<Text>();
                Text ChallengesID = DetailsContainer.transform.GetChild(1).GetComponent<Text>();
                ChallengeDate.text = challenge.CreatedAt;
                ChallengesID.text = "ID:" + challenge._id;

                //Fill Results
                Text MatchedUser1Score = ResultContainer.transform.GetChild(0).GetComponent<Text>();
                Text MatchedUser2Score = ResultContainer.transform.GetChild(1).GetComponent<Text>();
                Image MatchedUser1Avatar = ResultContainer.transform.GetChild(2).GetComponent<Image>();
                Image MatchedUser2Avatar = ResultContainer.transform.GetChild(3).GetComponent<Image>();
                Text Amount = ResultContainer.transform.GetChild(4).GetComponent<Text>();

                MatchedUser1Score.text = challenge.user_1_score.ToString();
                MatchedUser2Score.text = challenge.user_1_score.ToString();
                MatchedUser1Avatar.sprite= await HistoryViewModel.GetInstance().GetAvatar(challenge.matched_user_1.avatar);
                MatchedUser2Avatar.sprite= await HistoryViewModel.GetInstance().GetAvatar(challenge.matched_user_2.avatar);

                if (challenge.winner_user.Equals(User.CurrentUser._id))
                {   
                    if(challenge.gain_type.Equals("bubble"))
                        Amount.text = "+" + challenge.gain + "BUBBLES";
                    else Amount.text = "+" + float.Parse(challenge.gain).ToString("N2") + "€";
                }
                else
                {
                    if (challenge.gain_type.Equals("bubble"))
                        Amount.text = "-" + challenge.gain + "BUBBLES";
                    else Amount.text = "-" + float.Parse(challenge.gain).ToString("N2") + "€";
                }

            }
            else
            {
                Challenges.Remove(challenge);
            }
        }
        if (Challenges.Count == 0)
        {
            Parent.transform.GetChild(0).gameObject.SetActive(true);
        }

    }

    // Update is called once per frame
    void Update()
    {
        LayoutRebuilder.ForceRebuildLayoutImmediate((RectTransform)Parent.transform);

    }
}
