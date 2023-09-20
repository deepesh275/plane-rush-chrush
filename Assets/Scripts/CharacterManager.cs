using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CharacterManager : MonoBehaviour
{
    [SerializeField] private GoogleAdMobController gameAds;

    public CharacterDatabase characterDB;

    public Text nameText;
    public SpriteRenderer artworkSprite;

    private int selectedOption = 0;
    public int currentCoins = 0;

    public GameObject backBtn;
    public GameObject nextBtn;
    public GameObject playBtn;
    public GameObject popBtn;

    private int characterDBLength = 0;



   void Start()
   {
 
        
        if(!PlayerPrefs.HasKey("selectedOption"))
        {
            selectedOption = 0;
        }

        else
        {
            Load();
        }
        getCharacterLength();
        getCoinValue();
        UpdateCharacter(selectedOption);
        gameAds.RequestBannerAd();
        gameAds.ShowAppOpenAd();
        gameAds.RequestAndLoadInterstitialAd();
   }
   

   public void  NextOption() 
   {
        

        if((characterDBLength - 1) >= selectedOption){
            selectedOption++;
            // ActiveObject();
            UpdateCharacter(selectedOption);
            Save();
        }
      
    }

    public void  BackOption() 
    {
        selectedOption--;

        if (selectedOption < 0)
        {
            selectedOption = characterDB.CharacterCount - 1;
        }
        UpdateCharacter(selectedOption);
        Save();
    }

    public void ActiveObject(int selectedOption)
    {
        if (selectedOption == 0)
        {
            backBtn.SetActive(false);
            nextBtn.SetActive(true);
        } else if (selectedOption == 4)
        {
            nextBtn.SetActive(false);
            backBtn.SetActive(true);
        } else {
            nextBtn.SetActive(true);
            backBtn.SetActive(true);


        }
      
    }

    public void showPlayButton(int selectedOption, int currentCoins)
    {
        if (selectedOption == 0)
        {
            playBtn.SetActive(true);
            popBtn.SetActive(false);
        } else if (selectedOption == 1 && currentCoins >= 500) {
            playBtn.SetActive(true);
            popBtn.SetActive(false);
        } else if (selectedOption == 2 && currentCoins >= 700) {
            playBtn.SetActive(true);
            popBtn.SetActive(false);
        } else if (selectedOption == 3 && currentCoins >= 3000) {
            playBtn.SetActive(true);
            popBtn.SetActive(false);
        } else if (selectedOption == 4 && currentCoins >= 4000) {
            playBtn.SetActive(true);
            popBtn.SetActive(false);
        } else {
            playBtn.SetActive(false);
            popBtn.SetActive(true);
        }
    }

    private void UpdateCharacter(int selectedOption)
    { 
        
 

        ActiveObject(selectedOption);
        showPlayButton(selectedOption, currentCoins);
        if (selectedOption <= 4)
        {
            Character character = characterDB.GetCharacter(selectedOption);
            artworkSprite.sprite = character.characterSprite;
            nameText.text = character.characterName;
        }
     
    }

    private void Load()
    {
        selectedOption = PlayerPrefs.GetInt("selectedOption");
    }

    private void getCoinValue()
    {
        currentCoins = PlayerPrefs.GetInt("currentCoins");
    }

    private void getCharacterLength()
    {
        characterDBLength = characterDB.CharacterCount;
    }

    private void Save()
    {
        if (selectedOption == 0 )
        {
            PlayerPrefs.SetInt("selectedOption", selectedOption);

        } 
        else if (selectedOption == 1 && currentCoins >= 500  )
        {
         
            PlayerPrefs.SetInt("selectedOption", selectedOption);
            


        }
        else if (selectedOption == 2 && currentCoins >= 700  )
        {
            
            PlayerPrefs.SetInt("selectedOption", selectedOption);

        }
        else if (selectedOption == 3 && currentCoins >= 3000  )
        {
            
            PlayerPrefs.SetInt("selectedOption", selectedOption);

        }
        else if (selectedOption == 4 && currentCoins >= 4000  )
        {
           
            PlayerPrefs.SetInt("selectedOption", selectedOption);

        }
        
    }

    public void ChangeScene(int sceneID)
    {
        SceneManager.LoadScene(sceneID);
        gameAds.DestroyBannerAd();
    }

    public void QuitButton() {
        Application.Quit();
    }
}
