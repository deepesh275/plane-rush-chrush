using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinCounter : MonoBehaviour
{
    public static CoinCounter instance;

    public TMP_Text coinText;
    public int currentCoins = 0;

    void Awake() 
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        if(!PlayerPrefs.HasKey("currentCoins"))
        {
            currentCoins = 0;
        }

        else
        {
            Load();
        }

        coinText.text = currentCoins.ToString();
    }

    // Update is called once per frame
    public void IncreaseCoins(int v) {
        currentCoins += v;
        coinText.text = currentCoins.ToString();
        Save();
    }

    private void Load()
    {
        currentCoins = PlayerPrefs.GetInt("currentCoins");
    }

    private void Save()
    {
        PlayerPrefs.SetInt("currentCoins", currentCoins);
    }
}
