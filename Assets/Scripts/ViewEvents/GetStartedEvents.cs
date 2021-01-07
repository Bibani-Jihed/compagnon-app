using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetStartedEvents : MonoBehaviour
{
    public Button GetStarted;
    // Start is called before the first frame update
    void Start()
    {
        GetStarted.onClick.AddListener(delegate
        {
            ViewNavigationController.GetInstance().Navigate(ViewNavigationController.LOGIN_INDEX);
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
