using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

[System.Serializable]
public class PlayerData
{
    public int playerCoins;

    public PlayerData()
    {
        playerCoins = GM.playerCoins;
        //Debug.Log("Trying to save the current Scene :" + activeSceneIndex);
    }
}

