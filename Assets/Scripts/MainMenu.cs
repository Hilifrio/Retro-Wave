using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityCore.Audio;
using AudioType = UnityCore.Audio.AudioType;

public class MainMenu : MonoBehaviour
{
    public GameObject CoinText;
    public static MainMenu _mm;
    [SerializeField]
    AudioController audioController = null;
    // Start is called before the first frame update
    void Start()
    {
        audioController.PlayAudio(AudioType.ST_Menu, true);
        CoinText.GetComponent<Text>().text = "Coins : "+GM.playerCoins;
        _mm = GameObject.FindGameObjectWithTag("MainMenu").GetComponent<MainMenu>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void ManageMenu(string action)
    {
        if(action == "EndlessRun")
        {
            _mm.EndlessRun();
        }
        else if(action == "Levels")
        {
            _mm.Levels();
        }
        else if(action == "Shop")
        {
            _mm.Shop();
        }
    }

    public void EndlessRun()
    {
        audioController.PlayAudio(AudioType.ST_Level1, true);
        SceneManager.LoadScene("Level1");
    }

    public void Levels()
    {
        Debug.Log("Levels");
    }

    private void OnApplicationQuit()
    {
        SaveSystem.SavePlayer();
    }

    public void Quit()
    {
        SaveSystem.SavePlayer();
        Application.Quit();
    }
    public void Shop()
    {
        Debug.Log("Shop");
    }
}
