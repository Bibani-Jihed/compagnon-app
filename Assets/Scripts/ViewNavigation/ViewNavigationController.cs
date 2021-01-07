using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewNavigationController : MonoBehaviour
{
    public List<GameObject> Views;
    public const int GETSTARTED_INDEX = 0;
    public const int LOGIN_INDEX = 1;
    public const int HOME_INDEX = 2;

    
    public List<GameObject> HomePages;
    public const int GAMES_INDEX = 0;
    public const int HISTORY_INDEX = 1;
    public const int PAYMENT_INDEX = 2;

    // Start is called before the first frame update
    private static ViewNavigationController instance;
    void Start()
    {
        instance = this;
    }
    public static ViewNavigationController GetInstance()
    {
        return instance;
    }
    public void Navigate(int index)
    {
        Open(index);

        switch (index)
        {
            case GETSTARTED_INDEX: Close(LOGIN_INDEX); Close(HOME_INDEX); return;
            case LOGIN_INDEX: Close(GETSTARTED_INDEX); Close(HOME_INDEX); return;
            case HOME_INDEX: Close(GETSTARTED_INDEX); Close(LOGIN_INDEX); return;
        }
    }
    private void Open(int index)
    {
        Views[index].SetActive(true);
    }
    private void Close(int index)
    {
        Views[index].SetActive(false);
    }
    public void NavigateInner(int index)
    {
        OpenInner(index);

        switch (index)
        {
            case GAMES_INDEX: CloseInner(HISTORY_INDEX); CloseInner(PAYMENT_INDEX); return;
            case HISTORY_INDEX: CloseInner(GAMES_INDEX); CloseInner(PAYMENT_INDEX); return;
            case PAYMENT_INDEX: CloseInner(GAMES_INDEX); CloseInner(HISTORY_INDEX); return;
        }
    }
    private void OpenInner(int index)
    {
        HomePages[index].SetActive(true);
    }
    private void CloseInner(int index)
    {
        HomePages[index].SetActive(false);
    }

}
