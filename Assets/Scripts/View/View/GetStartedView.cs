using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetStartedView : MonoBehaviour
{
    public Button GetStarted;


    // Start is called before the first frame update
    void Start()
    {
        GetStarted.onClick.AddListener(delegate
        {
            var saved_user = PlayerPrefs.GetString("CurrentUser");
            if (!string.IsNullOrEmpty(saved_user)){
                User.CurrentUser = JsonConvert.DeserializeObject<User>(saved_user);
                ViewNavigationController.GetInstance().Navigate(ViewNavigationController.HOME_INDEX);
            }
            else
            ViewNavigationController.GetInstance().Navigate(ViewNavigationController.LOGIN_INDEX);
        });
    }

    // Update is called once per frame
    void Update()
    {

    }
}
