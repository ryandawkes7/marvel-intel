//For complete comments, see SuitShop.cs

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public enum Movie_Classes
{
    NaMovie,
    Spiderman,
    Homecoming,
    AmazingSpiderman
}

public static class MoviesEconomy
{
    //Global variable to know what character the player has selected
    public static Movie_Classes selectedMovie = Movie_Classes.NaMovie;

    //Global "storage" to remember what characters the player has unlocked
    public static bool[] unlockedMovies = new bool[System.Enum.GetNames(typeof(Movie_Classes)).Length];
}

public class MoviesShop : MonoBehaviour
{

    // How many coins does the movie cost?
    Dictionary<Movie_Classes, int> movieCosts = new Dictionary<Movie_Classes, int>
    {
        { Movie_Classes.NaMovie, 0 },
        { Movie_Classes.Spiderman, 1 },
        { Movie_Classes.Homecoming, 2 },
        { Movie_Classes.AmazingSpiderman, 3 },
    };

    public Text coinsAmount, confPnlCoinsTxt;

    //Current amount of coins
    public int currentCoinsAmount;

    //Image that displays the currently selected movie
    public Image currentMovieDisplay;

    //Movie buttons
    public Button[] movieButtons = new Button[System.Enum.GetNames(typeof(Movie_Classes)).Length];
    Dictionary<Movie_Classes, Button> movieButtonRelation = new Dictionary<Movie_Classes, Button>();

    //Buy or select button
    public Button buySelectButton, purchaseButton;

    //Purchase popup confirmation panel
    public GameObject confirmMoviePanel;


    //Movie description panels
    public GameObject spidermanPanel, spidermanCoinsObject, spidermanLockCover;
    public Text spidermanCost;
    public Button spiderBackBtn;
    
    public GameObject homecomingPanel, homecomingCoinsObject, homecomingLockCover;
    public Text homecomingCost;
    public Button homecomingBackBtn;

    public GameObject amazingSpiderPanel, amazingSpiderCoinsObject, amazingLockCover;
    public Text amazingSpiderCost;
    public Button amazingBackBtn;


    //Close button for description panels
    public Button cancelMovieButton;

    //To know what movie is currently selected
    Movie_Classes selectedMovie;
    Movie_Classes movieCoinsValue;
    Button selectedButton;

    void OnEnable()
    {
        spiderBackBtn.onClick.AddListener(PnlCloseButton);
        homecomingBackBtn.onClick.AddListener(PnlCloseButton);
        amazingBackBtn.onClick.AddListener(PnlCloseButton);
    }

    void PnlCloseButton()
    {
        MoviesEconomy.selectedMovie = Movie_Classes.NaMovie;
   
        spidermanPanel.transform.gameObject.SetActive(false);
        homecomingCost.transform.gameObject.SetActive(false);
        amazingSpiderPanel.transform.gameObject.SetActive(false);
    }

    private void Start()
    {
        spidermanCost.text = movieCosts[Movie_Classes.Spiderman].ToString();
        homecomingCost.text = movieCosts[Movie_Classes.Homecoming].ToString();
        amazingSpiderCost.text = movieCosts[Movie_Classes.AmazingSpiderman].ToString();

        //Hides confirmation panel on start up
        confirmMoviePanel.transform.gameObject.SetActive(false);
        spidermanPanel.transform.gameObject.SetActive(false);

        //Retrieve user's coins amount
        currentCoinsAmount = CoinsManager.CurrentCoinsTotal;

        Debug.Log("Movie classes cost " + movieCosts);
        Debug.Log("You have " + currentCoinsAmount + " coins.");

        //If price is 0, it is a default movie and therefore, unlocked by default
        for (int c = 0; c < MoviesEconomy.unlockedMovies.Length; c++) 
        {
            if(movieCosts[(Movie_Classes)c] == 0)
            {
                MoviesEconomy.unlockedMovies[c] = true;
            }
        }

        //For every button
        for (int b = 0; b < movieButtons.Length; b++)
        {

            //What movie does this button correspond to?
            Movie_Classes movie = (Movie_Classes)System.Enum.Parse(typeof(Movie_Classes), movieButtons[b].gameObject.name);

            //The movie name and this button are now linked
            movieButtonRelation.Add(movie, movieButtons[b]);

            //If the player doesn't own the movie
            if(!MoviesEconomy.unlockedMovies[(int)movie])
            {
            } else if (MoviesEconomy.unlockedMovies[(int)movie]) //But if the player owns the movie...
            {
                //The player can select this movie
                movieButtons[b].interactable = true;
            }
            //Apply listeners to buttons - make the buttons actually do something
            Button butt = movieButtons[b];
            movieButtons[b].onClick.AddListener(delegate
            {
                MovieSelect(movie, butt);

            });
        }
        //The current movie display shows what is currently selected...
        currentMovieDisplay.sprite = movieButtonRelation[MoviesEconomy.selectedMovie].image.sprite;
        //...As well as the text
        currentMovieDisplay.gameObject.transform.GetChild(0).gameObject.GetComponent<Text>().text = movieButtonRelation[MoviesEconomy.selectedMovie].gameObject.name;
    }

    private void Update()
    {

        coinsAmount.text = CoinsManager.CurrentCoinsTotal.ToString();
        
        if (MoviesEconomy.selectedMovie == Movie_Classes.NaMovie)
        {
            spidermanPanel.transform.gameObject.SetActive(false);
            homecomingPanel.transform.gameObject.SetActive(false);
            amazingSpiderPanel.transform.gameObject.SetActive(false);
        }
        
        //Loads description panel for the movie that is selected
        if (MoviesEconomy.selectedMovie == Movie_Classes.Spiderman)
        {
            spidermanPanel.transform.gameObject.SetActive(true);

        }
        else if (MoviesEconomy.selectedMovie == Movie_Classes.Homecoming)
        {
            homecomingPanel.transform.gameObject.SetActive(true);

        }
        else if (MoviesEconomy.selectedMovie == Movie_Classes.AmazingSpiderman)
        {
            amazingSpiderPanel.transform.gameObject.SetActive(true);
        }
        else if (MoviesEconomy.selectedMovie == Movie_Classes.NaMovie)
        {
            spidermanPanel.transform.gameObject.SetActive(false);
            homecomingPanel.transform.gameObject.SetActive(false);
            amazingSpiderPanel.transform.gameObject.SetActive(false);
        }

        //If the movie is locked...
        if (!MoviesEconomy.unlockedMovies[1])
        {
            spidermanLockCover.transform.gameObject.SetActive(true);
            //Else if the movie is unlocked...
        }
        else if (MoviesEconomy.unlockedMovies[1])
        {
            spidermanCoinsObject.transform.gameObject.SetActive(false);
            spidermanLockCover.transform.gameObject.SetActive(false);
        }

        if (!MoviesEconomy.unlockedMovies[2])
        {
            homecomingLockCover.transform.gameObject.SetActive(true);

        }
        else if (MoviesEconomy.unlockedMovies[2])
        {
            homecomingCoinsObject.transform.gameObject.SetActive(false);
            homecomingLockCover.transform.gameObject.SetActive(false);
        }

        if (!MoviesEconomy.unlockedMovies[3])
        {
            amazingLockCover.transform.gameObject.SetActive(true);
        }
        else if (MoviesEconomy.unlockedMovies[3])
        {
            amazingSpiderCost.transform.gameObject.SetActive(false);
            amazingLockCover.transform.gameObject.SetActive(false);
        }
    }

    public void closeDesc()
    {
        //Assigned to back button in movie desc panel - if button is pressed then the panel closes and the selected movie is now the NA Movie
        spidermanPanel.transform.gameObject.SetActive(false);
        homecomingPanel.transform.gameObject.SetActive(false);
        amazingSpiderPanel.transform.gameObject.SetActive(false);
        
        MoviesEconomy.selectedMovie = Movie_Classes.NaMovie;
        Debug.Log("Selected movie: " + MoviesEconomy.selectedMovie);
    }

    public void MovieSelect(Movie_Classes movieName, Button pressedButton)
    {
        //Resetting previously selected button
        if (selectedButton != null)  //If user has selected a button...
        {
            if(!MoviesEconomy.unlockedMovies[(int)selectedMovie])   //If the previous movie isn't unlocked but is unlockable...
            {
            }
        }

        //Knowing what movie was previously selected
        selectedMovie = movieName;
        selectedButton = pressedButton;

        //Making the buy/select button display what is appropriate
        if (MoviesEconomy.unlockedMovies[(int)selectedMovie])   //If the movie is unlocked...
        {
            //Changes selected movie to the button the user selects
            MoviesEconomy.selectedMovie = selectedMovie;
        } else //If movie isn't unlocked...
        {
            //If movie isn't unlocked and user taps it, the confirm purchase panel button pops up
            confirmMoviePanel.transform.gameObject.SetActive(true);
            confPnlCoinsTxt.text = movieCosts[selectedMovie].ToString();

        }
    }

    public void purchaseMovie()  //Function applied to Purchase button in Popup panel
    {

        if (currentCoinsAmount >= movieCosts[selectedMovie])
        {
            //If user has enough money to purchase the movie, then the popup panel closes 
            confirmMoviePanel.transform.gameObject.SetActive(false);
            
            CoinsManager.RemoveCurrentCoins(movieCosts[selectedMovie]);
            Debug.Log("You have " + CoinsManager.CurrentCoinsTotal + " coins remaining.");

            //Unlocking movie
            MoviesEconomy.unlockedMovies[(int)selectedMovie] = true;

            //Movie is selected
            MoviesEconomy.selectedMovie = selectedMovie;

            //The current movie display shows what is currently selected...
            currentMovieDisplay.sprite = movieButtonRelation[selectedMovie].image.sprite;

            Debug.Log(movieButtonRelation[selectedMovie]);

            //...As well as the text
            currentMovieDisplay.gameObject.transform.GetChild(0).gameObject.GetComponent<Text>().text = "Currently Selected: \n" + movieButtonRelation[selectedMovie].gameObject.name;

            //Tell the player they purchased the movie
            buySelectButton.gameObject.GetComponentInChildren<Text>().text = "Bought " + selectedMovie + "!\n" + "\n You now have " + currentCoinsAmount;

        }
        else if (currentCoinsAmount <= movieCosts[selectedMovie])
        {
            Debug.Log("Sorry, you don't have enough coins for this movie.");
            purchaseButton.interactable = false;
        }
    }

    public void backBtn()
    {
        SceneManager.LoadScene("CharacterHubScene");
    }

    public void homeBtn()
    {
        SceneManager.LoadScene("AccountHubScene");
    }
}
