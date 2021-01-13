using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProfileView : MonoBehaviour
{
    public Button OpenProfileButton;
    public Button CloseProfileButton;
    private  Animator ProfileAnimator;

    public Image Avatar;
    public Image ProLabel;
    public Text Username;
    public Image Flag;
    public Text BubbleCredit;
    public Text CashCredit;

    public Text Vectories;
    public Text WinStreak;

    public Button Logout;



    // Start is called before the first frame update
    async void Start()
    {
        ProfileAnimator = GetComponent<Animator>();
        OpenProfileButton.onClick.AddListener(delegate {
            ProfileAnimator.SetBool("show", true);
        });
        CloseProfileButton.onClick.AddListener(delegate {
            ProfileAnimator.SetBool("show", false);
        });

        Avatar.sprite = await ProfileViewModel.GetInstance().GetAvatar(User.CurrentUser.avatar);
        Avatar.gameObject.SetActive(true);
        Flag.sprite = await ProfileViewModel.GetInstance().GetFlag(User.CurrentUser.country_code);
        Username.text = User.CurrentUser.username;
        ProLabel.gameObject.SetActive(User.CurrentUser.money_credit>0 ? true : false);
        BubbleCredit.text = User.CurrentUser.bubble_credit.ToString();
        CashCredit.text = User.CurrentUser.money_credit.ToString("N2")+"€";


        Vectories.text = User.CurrentUser.victories_count.ToString();
        WinStreak.text = User.CurrentUser.victories_streak.ToString();


        Logout.onClick.AddListener(delegate {
            ProfileAnimator.SetBool("show", false);
            StartCoroutine(WaitAnimation(ProfileAnimator,(callback) => {
                Debug.Log("Done");
                
            }));
            
        });

    }
    public IEnumerator WaitAnimation(Animator ProfileAnimator, Action<string[]> callback)
    {
        float waitTime = ProfileAnimator.GetCurrentAnimatorStateInfo(0).length;
        //Now, Wait until the current state is done playing
        float counter = 0;
        while (counter < (waitTime))
        {
            counter += Time.deltaTime;
            yield return null;
        }
        Debug.Log("Done Playing");
        ProfileViewModel.GetInstance().Logout();
        NavigationBarController.GetInstance().Navigate(ViewNavigationController.GAMES_INDEX);
        ViewNavigationController.GetInstance().Navigate(ViewNavigationController.GETSTARTED_INDEX);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
