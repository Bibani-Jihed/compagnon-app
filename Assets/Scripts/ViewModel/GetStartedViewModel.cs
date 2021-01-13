using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetStartedViewModel : MonoBehaviour
{
    private static WebRequestHandler WebRequestHandler;
    private static GetStartedViewModel sInstance;
    public static GetStartedViewModel GetInstance()
    {
        if (sInstance == null)
        {
            sInstance = new GetStartedViewModel();
            WebRequestHandler = WebRequestHandler.GetInstance();
        }
        return sInstance;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
