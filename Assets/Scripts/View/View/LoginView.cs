using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoginView : MonoBehaviour
{
    // Start is called before the first frame update
    public Button LoginButton;
    public Button BackButton;
    public Button ShowPasswordButton;
    public InputField EmailUsernameInputField;
    public InputField PasswordInputField;
    public Text LoginErrorText;
    private Color StandardTypeColor = new Color(1f,1f,1f);
    private Color PasswordTypeColor = new Color(82/255f, 82 / 255f, 82 / 255f);


    void Start()
    {
        LoginButton.onClick.AddListener(delegate
        {
            Login();
        });
        BackButton.onClick.AddListener(delegate
        {
            ViewNavigationController.GetInstance().Navigate(ViewNavigationController.GETSTARTED_INDEX);
        });
        EmailUsernameInputField.onValueChange.AddListener(delegate
        {
            LoginErrorText.gameObject.SetActive(false);
        });
        PasswordInputField.onValueChange.AddListener(delegate
        {
            LoginErrorText.gameObject.SetActive(false);
        });
        ShowPasswordButton.onClick.AddListener(delegate
        {
           Image showPasswordImage= ShowPasswordButton.GetComponent<Image>();

            if (PasswordInputField.contentType == InputField.ContentType.Password)
            {
                PasswordInputField.contentType = InputField.ContentType.Standard;
                showPasswordImage.color = StandardTypeColor;
            }
            else
            {
                PasswordInputField.contentType = InputField.ContentType.Password;
                showPasswordImage.color = PasswordTypeColor;

            }

            PasswordInputField.ForceLabelUpdate();
        });
    }
    private void Update()
    {
        if (string.IsNullOrEmpty(EmailUsernameInputField.text) || string.IsNullOrEmpty(PasswordInputField.text))
        {
            LoginButton.interactable = false;
        }
        else LoginButton.interactable = true;
    }

    private async void Login()
    {

        //Show Loader
        Loader.GetInstance().Show();
        User user = await LoginViewModel.GetInstance().Login(EmailUsernameInputField.text, PasswordInputField.text);
        //Hide Loader
        Loader.GetInstance().Hide();
        if (user != null)
        {   
            foreach(string game in user.games)
            {
                Debug.Log(game);
            }
            User.CurrentUser = user;

            ViewNavigationController.GetInstance().Navigate(ViewNavigationController.HOME_INDEX);
        }
        else
        {
            Error();
        }
    }
    private void Error()
    {
        LoginErrorText.gameObject.SetActive(true);
        Debug.Log("Incorrect Username/email or password");
    }

}
