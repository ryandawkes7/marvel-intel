//REFERENCES: (Login and register script)
// Firebase - https://www.youtube.com/watch?v=52yUcKLMKX0&t=42s

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Firebase.Auth;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class RegistrationManager : MonoBehaviour
{
    public InputField Email;
    public InputField Password;
    public Button RegistrationButton;

    public Text incorrectRegText;
    public bool isRegCorrect = true;
    public bool isRegistered = false;

    private string userId;
    private string userEmail;

    private FirebaseAuth firebaseAuthInstance;

    public void Start()
    {
        firebaseAuthInstance = FirebaseAuth.DefaultInstance;
        RegistrationButton.onClick.AddListener(OnRegistrationClick);
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
        
        if(isRegistered == true)
        {
            ChangeScene();
        }

        if (isRegCorrect == true)
        {
            incorrectRegText.text = "";
            
        } else if (isRegCorrect == false)
        {
            incorrectRegText.text = "Error Creating Account";
        }
    }

    private void ChangeScene()
    {
        SceneManager.LoadScene("AccountHubScene");
    }

    private void OnRegistrationClick() {
        firebaseAuthInstance.CreateUserWithEmailAndPasswordAsync(Email.text, Password.text).ContinueWith(task => {
            if (task.IsCanceled)
            {
                Debug.LogError("CreateUserWithEmailAndPasswordAsync was canceled.");
                return;
            }
            if (task.IsFaulted)
            {
                isRegCorrect = false;
                Debug.LogError("CreateUserWithEmailAndPasswordAsync encountered an error: " + task.Exception);
                return;
            }
        
            // Firebase user has been created.
            FirebaseUser newUser = task.Result;
            Debug.LogFormat("Firebase user created successfully: {0} ({1})",
                newUser.Email, newUser.UserId);

            userEmail = newUser.Email;
            Debug.Log("User's email is this: " + userEmail);
            userId = newUser.UserId;
            Debug.Log("User's ID is this: " + userId);
            
            isRegCorrect = true;
            isRegistered = true;
        });
    }
}
