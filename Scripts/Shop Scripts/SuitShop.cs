//REFERENCES:
//Video Tutorials:
//    Unity - Shop UI (https://www.youtube.com/watch?v=TAJCr3_kfEc)
//    N3K EN - Unity Mobile Game Tutorial (https://www.youtube.com/watch?v=cQHF4_YPvsM)
//    Alexander Sotov - How to make a shop or item store in 2D Unity game. Simple Unity 2D tutorial. (https://www.youtube.com/watch?v=G_I6GxGIB_Y&t=148s)
//    

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public enum Suit_Classes
{
    NaSuit,
    StarkTech,
    IronSpider,
    FearItself
}

public static class Economy
{
    //Global variable to know what character the player has selected
    public static Suit_Classes selectedSuit = Suit_Classes.NaSuit;

    //Global "storage" to remember what characters the player has unlocked
    public static bool[] unlockedSuits = new bool[System.Enum.GetNames(typeof(Suit_Classes)).Length];
}

public class SuitShop : MonoBehaviour
{
    // How many coins does the suit cost?
    Dictionary<Suit_Classes, int> suitCosts = new Dictionary<Suit_Classes, int>
    {
        { Suit_Classes.NaSuit, 0 },
        { Suit_Classes.StarkTech, 1 },
        { Suit_Classes.IronSpider, 2 },
        { Suit_Classes.FearItself, 3 },
    };
    
    public Text coinsTxt, confPnlCoinsTxt;
    
    //Current amount of coins
    public int currentCoinsAmount;

    //Image that displays the currently selected suit
    public Image currentSuitDisplay;

    //Suit buttons
    public Button[] suitButtons = new Button[System.Enum.GetNames(typeof(Suit_Classes)).Length];
    Dictionary<Suit_Classes, Button> suitButtonRelation = new Dictionary<Suit_Classes, Button>();

    //Buy or select button
    public Button buySelectButton, purchaseButton;
    //Purchase popup confirmation panel
    public GameObject confirmPanel;
    //Button components
    public Button starkTech, ironSpider, futureFound;

    //Suit description panels
    public GameObject starkTechPanel, starkTitleContainer, starkCoinsObject, starkLockCover;
    public GameObject ironSpiderPanel, ironTitleContainer, ironCoinsObject, ironSpiderLockCover;
    public GameObject fearItselfPanel, fearTitleContainer, fearCoinsObject, fearLockCover;
    public Text starkCost, ironCost, fearCost;

    //Close button for description panels
    public Button cancelStarkButton;

    //To know what suit is currently selected
    Suit_Classes selectedSuit;
    Suit_Classes suitCoinsValue;
    Button selectedButton;

    private void OnEnable()
    {
        starkTech.onClick.AddListener(StarkTechScene);
        ironSpider.onClick.AddListener(IronSpiderScene);
        futureFound.onClick.AddListener(FutureFoundScene);
    }
    void StarkTechScene()
    {
        SceneManager.LoadScene("starkTechSuit");
        Economy.selectedSuit = Suit_Classes.NaSuit;
    }
    void IronSpiderScene()
    {
        SceneManager.LoadScene("ironSpiderSuit");
        Economy.selectedSuit = Suit_Classes.NaSuit;
    }
    void FutureFoundScene()
    {
        SceneManager.LoadScene("futureFoundationSuit");
        Economy.selectedSuit = Suit_Classes.NaSuit;
    }
    private void Start()
    {
        //Sets text on buttons to show the cost to unlock button
        starkCost.text = suitCosts[Suit_Classes.StarkTech].ToString();
        ironCost.text = suitCosts[Suit_Classes.IronSpider].ToString();
        fearCost.text = suitCosts[Suit_Classes.FearItself].ToString();

        //Hides confirmation panel on start up
        confirmPanel.transform.gameObject.SetActive(false);
        starkTechPanel.transform.gameObject.SetActive(false);

        //Retrieve user's coins amount
        currentCoinsAmount = CoinsManager.CurrentCoinsTotal;

        Debug.Log("Suit classes cost " + suitCosts);
        Debug.Log("You have " + currentCoinsAmount + " coins.");

        //If price is 0, it is a default suit and therefore, unlocked by default
        for (int c = 0; c < Economy.unlockedSuits.Length; c++) 
        {
            if(suitCosts[(Suit_Classes)c] == 0)
            {
                Economy.unlockedSuits[c] = true;
            }
        }

        //For every button
        for (int b = 0; b < suitButtons.Length; b++)
        {
            //What suit does this button correspond to?
            Suit_Classes suit = (Suit_Classes)System.Enum.Parse(typeof(Suit_Classes), suitButtons[b].gameObject.name);
            //The suit name and this button are now linked
            suitButtonRelation.Add(suit, suitButtons[b]);
            
            //If the player doesn't own the suit
            if(!Economy.unlockedSuits[(int)suit])
            {
            } else if(Economy.unlockedSuits[(int)suit])//But if the player owns this suit
            {
                suitButtons[b].interactable = true;
            }

            //Apply listeners to buttons - make the buttons actually do something
            Button butt = suitButtons[b];
            suitButtons[b].onClick.AddListener(delegate
           {
               SuitSelect(suit, butt);
           });
        }

        //The current suit display shows what is currently selected...
        currentSuitDisplay.sprite = suitButtonRelation[Economy.selectedSuit].image.sprite;

        //...As well as the text
        currentSuitDisplay.gameObject.transform.GetChild(0).gameObject.GetComponent<Text>().text = suitButtonRelation[Economy.selectedSuit].gameObject.name;
    }
    private void Update()
    {
        coinsTxt.text = CoinsManager.CurrentCoinsTotal.ToString();

        //Loads description panel for the suit that is selected
        if (Economy.selectedSuit == Suit_Classes.StarkTech)
            {
                starkTechPanel.transform.gameObject.SetActive(true);
            }
            else if (Economy.selectedSuit == Suit_Classes.IronSpider)
            {
                ironSpiderPanel.transform.gameObject.SetActive(true);
            }
            else if (Economy.selectedSuit == Suit_Classes.FearItself)
            {
                fearItselfPanel.transform.gameObject.SetActive(true);
            }

        //If the suit is locked...
        if (!Economy.unlockedSuits[1]) {
            //...The title of Stark Tech suit is hidden
            starkTitleContainer.transform.gameObject.SetActive(false);
            //The lock cover is visible
            starkLockCover.transform.gameObject.SetActive(true);

            //Else if the suit is unlocked...
        } else if (Economy.unlockedSuits[1])
        {
            //...The title of Stark Tech suit is visible
            starkTitleContainer.transform.gameObject.SetActive(true);
            //The coins image & text are hidden
            starkCoinsObject.transform.gameObject.SetActive(false);
            //The lock cover disappears
            starkLockCover.transform.gameObject.SetActive(false);
          
        }
        if (!Economy.unlockedSuits[2])
        {
            ironTitleContainer.transform.gameObject.SetActive(false);
            ironSpiderLockCover.transform.gameObject.SetActive(true);
        }
        else if (Economy.unlockedSuits[2])
        {
            ironTitleContainer.transform.gameObject.SetActive(true);
            ironCoinsObject.transform.gameObject.SetActive(false);
            ironSpiderLockCover.transform.gameObject.SetActive(false);

        }
        if (!Economy.unlockedSuits[3])
        {
            fearTitleContainer.transform.gameObject.SetActive(false);
            fearLockCover.transform.gameObject.SetActive(true);
        }
        else if (Economy.unlockedSuits[3])
        {
            fearTitleContainer.transform.gameObject.SetActive(true);
            fearCoinsObject.transform.gameObject.SetActive(false);
            fearLockCover.transform.gameObject.SetActive(false);
        }
    }
    public void closeStark()
    {
        //Assigned to back button in suit desc panel - if button is pressed then the panel closes and the selected suit is now the NA Suit
        starkTechPanel.transform.gameObject.SetActive(false);
        ironSpiderPanel.transform.gameObject.SetActive(false);
        fearItselfPanel.transform.gameObject.SetActive(false);

        Economy.selectedSuit = Suit_Classes.NaSuit;
    }
    public void SuitSelect(Suit_Classes suitName, Button pressedButton)
    {
        //Resetting previously selected button
        if(selectedButton != null)  //If user has selected a button...
        {
            if(!Economy.unlockedSuits[(int)selectedSuit])   //If the previous suit isn't unlocked but is unlockable...
            {
            }
        }

        //Knowing what suit was previously selected
        selectedSuit = suitName;
        selectedButton = pressedButton;

        //Making the buy/select button display what is appropriate
        if (Economy.unlockedSuits[(int)selectedSuit])   //If the suit is unlocked...
        {
            //Changes selected suit to the button the user selects
            Economy.selectedSuit = selectedSuit;
        } else //If suit isn't unlocked...
        {
            //If suit isn't unlocked and user taps it, the confirm purchase panel button pops up
            confirmPanel.transform.gameObject.SetActive(true);
            confPnlCoinsTxt.text = suitCosts[selectedSuit].ToString();
        }
    }
    public void purchaseSuit()  //Function applied to Purchase button in Popup panel
    {
        if(CoinsManager.CurrentCoinsTotal >= suitCosts[selectedSuit])
        {
            //If user has enough money to purchase the suit, then the popup panel closes 
            confirmPanel.transform.gameObject.SetActive(false);

            //Subtracting money from player
            CoinsManager.RemoveCurrentCoins(suitCosts[selectedSuit]);
            Debug.Log("You have " + CoinsManager.CurrentCoinsTotal + " coins remaining.");

            //Unlocking suit
            Economy.unlockedSuits[(int)selectedSuit] = true;

            //Suit is selected
            Economy.selectedSuit = selectedSuit;

            //The current suit display shows what is currently selected...
            currentSuitDisplay.sprite = suitButtonRelation[selectedSuit].image.sprite;

            Debug.Log(suitButtonRelation[selectedSuit]);

            //...As well as the text
            currentSuitDisplay.gameObject.transform.GetChild(0).gameObject.GetComponent<Text>().text = "Currently Selected: \n" + suitButtonRelation[selectedSuit].gameObject.name;

            //Tell the player they purchased the suit
            buySelectButton.gameObject.GetComponentInChildren<Text>().text = "Bought " + selectedSuit + "!\n" + "\n You now have " + currentCoinsAmount;
        } else if(currentCoinsAmount <= suitCosts[selectedSuit])
        {
            Debug.Log("Sorry, you don't have enough coins for this suit.");
            purchaseButton.interactable = false;
        }
    }
    public void BackBtn()
    {
        SceneManager.LoadScene("CharacterHubScene");
    }
}
