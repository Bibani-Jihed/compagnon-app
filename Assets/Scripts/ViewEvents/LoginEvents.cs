using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoginEvents : MonoBehaviour
{
    // Start is called before the first frame update
    public Button Login;
    public Button Back;
    void Start()
    {
        Login.onClick.AddListener(delegate
        {
            ViewNavigationController.GetInstance().Navigate(ViewNavigationController.HOME_INDEX);
        });
        Back.onClick.AddListener(delegate
        {
            ViewNavigationController.GetInstance().Navigate(ViewNavigationController.GETSTARTED_INDEX);
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
