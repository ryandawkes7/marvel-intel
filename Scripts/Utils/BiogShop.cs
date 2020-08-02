using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public enum Biog_Classes
{
    NaBiog,
    PeterParker,
    MilesMorales,
    JessicaDrew
}

public static class BiogEconomy
{
    //Global variable to know what character the player has selected
    public static Biog_Classes selectedBiog = Biog_Classes.NaBiog;

    //Global "storage" to remember what characters the player has unlocked
    public static bool[] unlockedBiogs = new bool[System.Enum.GetNames(typeof(Biog_Classes)).Length];
}

public class BiogShop : MonoBehaviour
{
    // How many coins does the biog cost?
    Dictionary<Biog_Classes, int> biogCosts = new Dictionary<Biog_Classes, int>
    {
        { Biog_Classes.NaBiog, 0 },
        { Biog_Classes.PeterParker, 1 },
        { Biog_Classes.MilesMorales, 2 },
        { Biog_Classes.JessicaDrew, 3 },
    };

    public Text coinsTxt;
    public Text confPnlCoinsTxt;
    
    //Current amount of coins
    public int currentCoinsAmount;

    //Image that displays the currently selected biog
    public Image currentBiogDisplay;

    //Biog buttons
    public Button[] biogButtons = new Button[System.Enum.GetNames(typeof(Biog_Classes)).Length];
    Dictionary<Biog_Classes, Button> biogButtonRelation = new Dictionary<Biog_Classes, Button>();

    //Buy or select button
    public Button buySelectButton;
    public Button purchaseButton;

    //Purchase popup confirmation panel
    public GameObject confirmPanel;


    //Biog description panels
    public GameObject parkerPanel;
    public Text parkerCost;
    public GameObject parkerCoinsObj;
    public GameObject parkerLockCover;

    public GameObject moralesPanel;
    public Text moralesCost;
    public GameObject moralesCoinObj;
    public GameObject moralesLockCover;

    public GameObject drewPanel;
    public Text drewCost;
    public GameObject drewCoinsObj;
    public GameObject drewLockCover;

    //Close button for description panels
    public Button cancelDescBtn;

    //To know what biog is currently selected
    Biog_Classes selectedBiog;
    Biog_Classes biogCoinsValue;
    Button selectedButton;

    private void Start()
    {

        //Sets text on buttons to show the cost to unlock button
        parkerCost.text = biogCosts[Biog_Classes.PeterParker].ToString();
        moralesCost.text = biogCosts[Biog_Classes.MilesMorales].ToString();
        drewCost.text = biogCosts[Biog_Classes.JessicaDrew].ToString();

        //Hides confirmation panel on start up
        confirmPanel.transform.gameObject.SetActive(false);
        parkerPanel.transform.gameObject.SetActive(false);

        //Retrieve user's coins amount
        currentCoinsAmount = CoinsManager.CurrentCoinsTotal;

        Debug.Log("Biog classes cost " + biogCosts);
        Debug.Log("You have " + currentCoinsAmount + " coins.");

        //If price is 0, it is a default biog and therefore, unlocked by default
        for (int c = 0; c < BiogEconomy.unlockedBiogs.Length; c++) 
        {
            if(biogCosts[(Biog_Classes)c] == 0)
            {
                BiogEconomy.unlockedBiogs[c] = true;
            }
        }

        //For every button
        for (int b = 0; b < biogButtons.Length; b++)
        {
            //What biog does this button correspond to?
            Biog_Classes biog = (Biog_Classes)System.Enum.Parse(typeof(Biog_Classes), biogButtons[b].gameObject.name);
            //The biog name and this button are now linked
            biogButtonRelation.Add(biog, biogButtons[b]);
            
            //If the player doesn't own the biog
            if(!BiogEconomy.unlockedBiogs[(int)biog])
            {
            } else if(BiogEconomy.unlockedBiogs[(int)biog])//But if the player owns this biog
            {
                biogButtons[b].interactable = true;
            }

            //Apply listeners to buttons - make the buttons actually do something
            Button butt = biogButtons[b];
            biogButtons[b].onClick.AddListener(delegate
           {
               BiogSelect(biog, butt);
           });
        }

        //The current biog display shows what is currently selected...
        currentBiogDisplay.sprite = biogButtonRelation[BiogEconomy.selectedBiog].image.sprite;

        //...As well as the text
        currentBiogDisplay.gameObject.transform.GetChild(0).gameObject.GetComponent<Text>().text = biogButtonRelation[BiogEconomy.selectedBiog].gameObject.name;
    }

    private void Update()
    {

        coinsTxt.text = CoinsManager.CurrentCoinsTotal.ToString();
        
        //Loads description panel for the biog that is selected
        if (BiogEconomy.selectedBiog == Biog_Classes.PeterParker)
        {
            SceneManager.LoadScene("ParkerBiog");
            BiogEconomy.selectedBiog = Biog_Classes.NaBiog;

            
        }
        else if (BiogEconomy.selectedBiog == Biog_Classes.MilesMorales)
        {
            SceneManager.LoadScene("MoralesBiog");
            BiogEconomy.selectedBiog = Biog_Classes.NaBiog;

        }
        else if (BiogEconomy.selectedBiog == Biog_Classes.JessicaDrew)
        {
            SceneManager.LoadScene("DrewBiog");
            BiogEconomy.selectedBiog = Biog_Classes.NaBiog;

        }

        //If the biog is locked...
        if (!BiogEconomy.unlockedBiogs[1]) {
            //The lock cover is visible
            parkerLockCover.transform.gameObject.SetActive(true);

            //Else if the biog is unlocked...
        } else if (BiogEconomy.unlockedBiogs[1])
        {
            //The coins image & text are hidden
            parkerCoinsObj.transform.gameObject.SetActive(false);
            //The lock cover disappears
            parkerLockCover.transform.gameObject.SetActive(false);
          
        }

        if (!BiogEconomy.unlockedBiogs[2])
        {
            moralesLockCover.transform.gameObject.SetActive(true);
        }
        else if (BiogEconomy.unlockedBiogs[2])
        {
            moralesCoinObj.transform.gameObject.SetActive(false);
            moralesLockCover.transform.gameObject.SetActive(false);

        }

        if (!BiogEconomy.unlockedBiogs[3])
        {
            drewLockCover.transform.gameObject.SetActive(true);
        }
        else if (BiogEconomy.unlockedBiogs[3])
        {
            drewCoinsObj.transform.gameObject.SetActive(false);
            drewLockCover.transform.gameObject.SetActive(false);
        }
    }

    public void closeDesc()
    {
        //Assigned to back button in biog desc panel - if button is pressed then the panel closes and the selected biog is now the NA Biog
        parkerPanel.transform.gameObject.SetActive(false);
        moralesPanel.transform.gameObject.SetActive(false);
        drewPanel.transform.gameObject.SetActive(false);

        BiogEconomy.selectedBiog = Biog_Classes.NaBiog;

    }

    public void BiogSelect(Biog_Classes biogName, Button pressedButton)
    {
        //Resetting previously selected button
        if(selectedButton != null)  //If user has selected a button...
        {
            if(!BiogEconomy.unlockedBiogs[(int)selectedBiog])   //If the previous biog isn't unlocked but is unlockable...
            {
            }

        }

        //Knowing what biog was previously selected
        selectedBiog = biogName;
        selectedButton = pressedButton;

        //Making the buy/select button display what is appropriate
        if (BiogEconomy.unlockedBiogs[(int)selectedBiog])   //If the biog is unlocked...
        {
            //Changes selected biog to the button the user selects
            BiogEconomy.selectedBiog = selectedBiog;
        } else //If biog isn't unlocked...
        {
            //If biog isn't unlocked and user taps it, the confirm purchase panel button pops up
            confirmPanel.transform.gameObject.SetActive(true);
            confPnlCoinsTxt.text = biogCosts[selectedBiog].ToString();
        }
    }

    public void purchaseBiog()  //Function applied to Purchase button in Popup panel
    {

        if(CoinsManager.CurrentCoinsTotal >= biogCosts[selectedBiog])
        {
            //If user has enough money to purchase the biog, then the popup panel closes 
            confirmPanel.transform.gameObject.SetActive(false);

            //Subtracting money from player
            CoinsManager.RemoveCurrentCoins(biogCosts[selectedBiog]);
            Debug.Log("You have " + CoinsManager.CurrentCoinsTotal + " coins remaining.");

            //Unlocking biog
            BiogEconomy.unlockedBiogs[(int)selectedBiog] = true;

            //Biog is selected
            BiogEconomy.selectedBiog = selectedBiog;

            //The current biog display shows what is currently selected...
            currentBiogDisplay.sprite = biogButtonRelation[selectedBiog].image.sprite;

            Debug.Log(biogButtonRelation[selectedBiog]);

            //...As well as the text
            currentBiogDisplay.gameObject.transform.GetChild(0).gameObject.GetComponent<Text>().text = "Currently Selected: \n" + biogButtonRelation[selectedBiog].gameObject.name;

            //Tell the player they purchased the biog
            buySelectButton.gameObject.GetComponentInChildren<Text>().text = "Bought " + selectedBiog + "!\n" + "\n You now have " + currentCoinsAmount;

        } else if(currentCoinsAmount <= biogCosts[selectedBiog])
        {
            Debug.Log("Sorry, you don't have enough coins for this biog.");
            purchaseButton.interactable = false;
        }
    }
}
