using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Firebase.Auth;

public class LoginManager : MonoBehaviour
{
    public InputField Email;
    public InputField Password;
    public Button LoginButton;
    
    public Text incorrectText;
    public bool isLoginCorrect = true;
    public bool isLoggedIn = false;
    
    private string userId;
    private string userEmail;

    private FirebaseAuth firebaseAuthInstance;

    void Start()
    {
        firebaseAuthInstance = FirebaseAuth.DefaultInstance;
        LoginButton.onClick.AddListener(OnLoginClick);
    }

    public void ChangeScene()
    {
        SceneManager.LoadScene("AccountHubScene");
    }

    private void Update()
    {
        if (userId != "")
        {
            PlayerPrefs.SetString("usersId", userId);
        }
        
        if (userEmail != "")
        {
            PlayerPrefs.SetString("usersEmail", userEmail);
        }
        
        if(isLoggedIn == true)
        {
            ChangeScene();
        }

        if (isLoginCorrect == false)
        {
            incorrectText.text = "Incorrect Login Details";
        }
        else if(isLoginCorrect == true)
        {
            incorrectText.text = "";
        }
    }

    public void OnLoginClick() {
        firebaseAuthInstance.SignInWithEmailAndPasswordAsync(Email.text, Password.text).ContinueWith(task => {
            if (task.IsCanceled)
            {
                Debug.LogError("SignInWithEmailAndPasswordAsync was canceled.");
                return;
            }
            if (task.IsFaulted)
            {
                isLoginCorrect = false;
                Debug.LogError("SignInWithEmailAndPasswordAsync encountered an error: " + task.Exception);
                return;
            }
        
            //Firebase user has logged in
            FirebaseUser newUser = task.Result;
            Debug.LogFormat("User signed in successfully: {0} ({1})",
                newUser.DisplayName, newUser.UserId);
            
            userEmail = newUser.Email;
            Debug.Log("User's email is this: " + userEmail);
            userId = newUser.UserId;
            Debug.Log("User's ID is this: " + userId);
        
            isLoggedIn = true;
            Debug.Log("User logged in =" + isLoggedIn);
        });
    }
}
