using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NavigationBarController : MonoBehaviour
{
    public GameObject NavigationBarContainer;
    
    public Button Games;
    public Button History;
    public Button Payment;

    

    private static NavigationBarController instance;
    private Color SelectedColor = new Color(161/255f,59/255f,38/255f);
    private Color UnselectedColor = new Color(255/255f, 255/255f, 255/255f);


   

    void Start()
    {
        instance = this;

        Games.onClick.AddListener(delegate
        {
            Navigate(ViewNavigationController.GAMES_INDEX);
        });
        History.onClick.AddListener(delegate
        {
            Navigate(ViewNavigationController.HISTORY_INDEX);
        });
        Payment.onClick.AddListener(delegate
        {
            Navigate(ViewNavigationController.PAYMENT_INDEX);
        });

    }
    public static NavigationBarController GetInstance()
    {
        return instance;
    }
    public void Navigate(int index)
    {
        ViewNavigationController.GetInstance().NavigateInner(index);

        switch (index)
        {
            case ViewNavigationController.GAMES_INDEX:  Select(index);  return;
            case ViewNavigationController.HISTORY_INDEX: Select(index);  return;
            case ViewNavigationController.PAYMENT_INDEX: Select(index);  return;
        }
    }
    private void Select(int index)
    {
        
        GameObject selectedItem = NavigationBarContainer.transform.GetChild(index).gameObject;
        Text name = selectedItem.transform.GetChild(1).gameObject.GetComponent<Text>();
        Image icon = selectedItem.transform.GetChild(0).gameObject.GetComponent<Image>();
        name.color = SelectedColor;
        icon.color = SelectedColor;

        //Unselect others
        switch (index)
        {
            case ViewNavigationController.GAMES_INDEX:  Unselect(ViewNavigationController.HISTORY_INDEX); Unselect(ViewNavigationController.PAYMENT_INDEX); return;
            case ViewNavigationController.HISTORY_INDEX:  Unselect(ViewNavigationController.GAMES_INDEX); Unselect(ViewNavigationController.PAYMENT_INDEX); return;
            case ViewNavigationController.PAYMENT_INDEX:  Unselect(ViewNavigationController.GAMES_INDEX); Unselect(ViewNavigationController.HISTORY_INDEX); return;
        }

    }
    private void Unselect(int index)
    {
        
        GameObject selectedItem = NavigationBarContainer.transform.GetChild(index).gameObject;
        Text name = selectedItem.transform.GetChild(1).gameObject.GetComponent<Text>();
        Image icon = selectedItem.transform.GetChild(0).gameObject.GetComponent<Image>();
        name.color = UnselectedColor;
        icon.color = UnselectedColor;
    }
   


}
