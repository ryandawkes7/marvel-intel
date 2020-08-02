//For complete comments, see SuitShop.cs

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public enum Comic_Classes
{
    NaComic,
    AmazingSpiderman,
    UltimateSpiderman,
    SuperiorSpiderman
}

public static class ComicsEconomy
{
    //Global variable to know what character the player has selected
    public static Comic_Classes selectedComic = Comic_Classes.NaComic;

    //Global "storage" to remember what characters the player has unlocked
    public static bool[] unlockedComics = new bool[System.Enum.GetNames(typeof(Comic_Classes)).Length];
}

public class ComicsShop : MonoBehaviour
{

    // How many coins does the comic cost?
    Dictionary<Comic_Classes, int> comicCosts = new Dictionary<Comic_Classes, int>
    {
        { Comic_Classes.NaComic, 0 },
        { Comic_Classes.AmazingSpiderman, 1 },
        { Comic_Classes.UltimateSpiderman, 2 },
        { Comic_Classes.SuperiorSpiderman, 3 },
    };

    public Text coinsAmount, confPnlCoinsTxt;

    //Current amount of coins
    public int currentCoinsAmount;

    //Image that displays the currently selected comic
    public Image currentComicDisplay;

    //Comic buttons
    public Button[] comicButtons = new Button[System.Enum.GetNames(typeof(Comic_Classes)).Length];
    Dictionary<Comic_Classes, Button> comicButtonRelation = new Dictionary<Comic_Classes, Button>();

    //Buy or select button
    public Button buySelectButton;
    public Button purchaseButton;

    //Purchase popup confirmation panel
    public GameObject confirmComicPanel;
    
    //Comic description panels
    public GameObject amazingSpidermanPanel, amazingTitleContainer, amazingCoinsObject, amazingLockCover;
    public Image amazingTitleCont, ultimateTitleCont, superiorTitleCont;
    public GameObject ultimateSpidermanPanel, ultimateTitleContainer, ultimateCoinsObject, ultimateLockCover;
    public GameObject superiorSpidermanPanel, superiorLockCover, superiorTitleContainer, superiorCoinsObject;
    public Text amazingSpidermanCost, ultimateSpidermanCost, superiorSpidermanCost;

    public Text amazingTitleTxt, ultimateTitleTxt, superiorTitleTxt;
    public Text amazingDescTxt, ultimateDescTxt, superiorDescTxt;
    public Text amazingWriterTxt, ultimateWriterTxt, superiorWriterTxt;

    //Close button for description panels
    public Button cancelComicButton;

    //To know what comic is currently selected
    Comic_Classes selectedComic;
    Comic_Classes comicCoincValue;
    Button selectedButton;

    private void Start()
    {
        amazingSpidermanCost.text = comicCosts[Comic_Classes.AmazingSpiderman].ToString();
        ultimateSpidermanCost.text = comicCosts[Comic_Classes.UltimateSpiderman].ToString();
        superiorSpidermanCost.text = comicCosts[Comic_Classes.SuperiorSpiderman].ToString();

        //Hides confirmation panel on start up
        confirmComicPanel.transform.gameObject.SetActive(false);
        amazingSpidermanPanel.transform.gameObject.SetActive(false);

        //Retrieve user's coins amount
        currentCoinsAmount = CoinsManager.CurrentCoinsTotal;

        Debug.Log("Comic classes cost " + comicCosts);
        Debug.Log("You have " + currentCoinsAmount + " coins.");

        //If price is 0, it is a default comic and therefore, unlocked by default
        for (int c = 0; c < ComicsEconomy.unlockedComics.Length; c++) 
        {
            if(comicCosts[(Comic_Classes)c] == 0)
            {
                ComicsEconomy.unlockedComics[c] = true;
            }
        }

        //For every button
        for (int b = 0; b < comicButtons.Length; b++)
        {

            //What comic does this button correspond to?
            Comic_Classes comic = (Comic_Classes)System.Enum.Parse(typeof(Comic_Classes), comicButtons[b].gameObject.name);

            //The comic name and this button are now linked
            comicButtonRelation.Add(comic, comicButtons[b]);

            //If the player doesn't own the comic
            if(!ComicsEconomy.unlockedComics[(int)comic])
            {
            } else if (ComicsEconomy.unlockedComics[(int)comic]) //But if the player owns the suit...
            {
                //The player can select this comic
                comicButtons[b].interactable = true;
            }
            //Apply listeners to buttons - make the buttons actually do something
            Button butt = comicButtons[b];
            comicButtons[b].onClick.AddListener(delegate
            {
                ComicSelect(comic, butt);

            });
        }

        //The current comic display shows what is currently selected...
        currentComicDisplay.sprite = comicButtonRelation[ComicsEconomy.selectedComic].image.sprite;

        //...As well as the text
        currentComicDisplay.gameObject.transform.GetChild(0).gameObject.GetComponent<Text>().text = comicButtonRelation[ComicsEconomy.selectedComic].gameObject.name;
    }

    private void Update()
    {

        coinsAmount.text = CoinsManager.CurrentCoinsTotal.ToString();
        
        //Loads description panel for the suit that is selected
        if (ComicsEconomy.selectedComic == Comic_Classes.AmazingSpiderman)
        {
            amazingSpidermanPanel.transform.gameObject.SetActive(true);

        }
        else if (ComicsEconomy.selectedComic == Comic_Classes.UltimateSpiderman)
        {
            ultimateSpidermanPanel.transform.gameObject.SetActive(true);

        }
        else if (ComicsEconomy.selectedComic == Comic_Classes.SuperiorSpiderman)
        {
            superiorSpidermanPanel.transform.gameObject.SetActive(true);
        }

        //If the comic is locked...
        if (!ComicsEconomy.unlockedComics[1])
        {
            //...The title of Amazing Spiderman is hidden
            amazingTitleTxt.text = "LOCKED";
            amazingWriterTxt.text = "LOCKED";
            amazingDescTxt.text = "";
            amazingTitleCont.color = Color.red;
            amazingLockCover.transform.gameObject.SetActive(true);

            //Else if the comic is unlocked...
        }
        else if (ComicsEconomy.unlockedComics[1])
        {
            //...The title of Amazing Spiderman comic is visible
            amazingTitleTxt.text = "AMAZING SPIDER-MAN";
            amazingWriterTxt.text = "NICK SPENCER";
            amazingDescTxt.text = "36 Issues"; 
            amazingTitleCont.color = Color.white;
            //The coins image & text are hidden
            amazingCoinsObject.transform.gameObject.SetActive(false);
            amazingLockCover.transform.gameObject.SetActive(false);

        }

        if (!ComicsEconomy.unlockedComics[2])
        {
            ultimateTitleTxt.text = "LOCKED";
            ultimateWriterTxt.text = "LOCKED";
            ultimateDescTxt.text = "";
            ultimateTitleCont.color = Color.red;
            ultimateLockCover.transform.gameObject.SetActive(true);
        }
        else if (ComicsEconomy.unlockedComics[2])
        {
            ultimateTitleTxt.text = "ULTIMATE SPIDER-MAN";
            ultimateWriterTxt.text = "BRIAN BENDIS";
            ultimateDescTxt.text = "365 Issues"; 
            ultimateTitleCont.color = Color.white;
            ultimateCoinsObject.transform.gameObject.SetActive(false);
            ultimateLockCover.transform.gameObject.SetActive(false);
        }

        if (!ComicsEconomy.unlockedComics[3])
        {
            superiorTitleTxt.text = "LOCKED";
            superiorWriterTxt.text = "LOCKED";
            superiorDescTxt.text = "";
            superiorTitleCont.color = Color.red;
            superiorLockCover.transform.gameObject.SetActive(true);
        }
        else if (ComicsEconomy.unlockedComics[3])
        {
            superiorTitleTxt.text = "SUPERIOR SPIDER-MAN";
            superiorWriterTxt.text = "DAN SLOTT";
            superiorDescTxt.text = "232 Issues"; 
            superiorTitleCont.color = Color.white;
            superiorSpidermanCost.transform.gameObject.SetActive(false);
            superiorLockCover.transform.gameObject.SetActive(false);
        }
    }

    public void closeDesc()
    {
        //Assigned to back button in comic desc panel - if button is pressed then the panel closes and the selected comic is now the NA Comic
        amazingSpidermanPanel.transform.gameObject.SetActive(false);
        ultimateSpidermanPanel.transform.gameObject.SetActive(false);
        superiorSpidermanPanel.transform.gameObject.SetActive(false);

        ComicsEconomy.selectedComic = Comic_Classes.NaComic;

    }

    public void ComicSelect(Comic_Classes comicName, Button pressedButton)
    {
        //Resetting previously selected button
        if (selectedButton != null)  //If user has selected a button...
        {
            if(!ComicsEconomy.unlockedComics[(int)selectedComic])   //If the previous comic isn't unlocked but is unlockable...
            {
            }
        }

        //Knowing what comic was previously selected
        selectedComic = comicName;
        selectedButton = pressedButton;

        //Making the buy/select button display what is appropriate
        if (ComicsEconomy.unlockedComics[(int)selectedComic])   //If the comic is unlocked...
        {
            //Changes selected comic to the button the user selects
            ComicsEconomy.selectedComic = selectedComic;
        } else //If comic isn't unlocked...
        {
            //If comic isn't unlocked and user taps it, the confirm purchase panel button pops up
            confirmComicPanel.transform.gameObject.SetActive(true);
            confPnlCoinsTxt.text = comicCosts[selectedComic].ToString();

        }
    }

    public void purchaseComic()  //Function applied to Purchase button in Popup panel
    {

        if (currentCoinsAmount >= comicCosts[selectedComic])
        {
            //If user has enough money to purchase the comic, then the popup panel closes 
            confirmComicPanel.transform.gameObject.SetActive(false);


            //Subtracting money from player
           
            CoinsManager.RemoveCurrentCoins(comicCosts[selectedComic]);
            Debug.Log("You have " + CoinsManager.CurrentCoinsTotal + " coins remaining.");

            //Unlocking comic
            ComicsEconomy.unlockedComics[(int)selectedComic] = true;

            //Comic is selected
            ComicsEconomy.selectedComic = selectedComic;

            //The current comic display shows what is currently selected...
            currentComicDisplay.sprite = comicButtonRelation[selectedComic].image.sprite;

            Debug.Log(comicButtonRelation[selectedComic]);

            //...As well as the text
            currentComicDisplay.gameObject.transform.GetChild(0).gameObject.GetComponent<Text>().text = "Currently Selected: \n" + comicButtonRelation[selectedComic].gameObject.name;

            //Tell the player they purchased the comic
            buySelectButton.gameObject.GetComponentInChildren<Text>().text = "Bought " + selectedComic + "!\n" + "\n You now have " + currentCoinsAmount;

        }
        else if (currentCoinsAmount <= comicCosts[selectedComic])
        {
            Debug.Log("Sorry, you don't have enough coins for this comic.");
            purchaseButton.interactable = false;
        }
    }

    public void AmazingUrlBtn()
    {
        Application.OpenURL("https://www.amazon.co.uk/Amazing-Spider-Man-Circle-Nick-Spencer/dp/1846533929/ref=sr_1_6?dchild=1&keywords=amazing+spiderman+spencer&qid=1595699259&sr=8-6");
        Debug.Log("Link to Amazon");
    }
    
    public void UltimateUrlBtn()
    {
        Application.OpenURL(
            "https://www.amazon.co.uk/Ultimate-Spider-Man-Vol-Responsibility-2000-2009-ebook/dp/B00AAJR3M4/ref=sr_1_2?dchild=1&keywords=ultimate+spiderman&qid=1595699417&sr=8-2");
        Debug.Log("Link to Amazon");
    }
    
    public void SuperiorUrlBtn()
    {
        Application.OpenURL("https://www.amazon.co.uk/Superior-Spider-Man-Complete-Collection-Vol/dp/1302909509/ref=sr_1_1?dchild=1&keywords=superior+spiderman&qid=1595699465&sr=8-1");
        Debug.Log("Link to Amazon");
    }
    
}
