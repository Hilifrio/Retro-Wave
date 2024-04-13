using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverUI : MonoBehaviour
{
	private AudioManager audioManager;
	// Start is called before the first frame update
	void Start()
    {
		audioManager= AudioManager.instance;

	}

    // Update is called once per frame
    void Update()
    {
        
    }

	public void Quit()
	{
		Debug.Log("GO TO MENU");
		//audioManager.PlaySound(pressButtonSound);
		GM.gameOver = false;
		GM.coinTotal = 0;
		SceneManager.LoadScene("Menu");
		//audioManager.PlaySound(pressButtonSound);
		//audioManager.StopSound(gameOverMusic);
	}

	public void Retry()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
		GM.gameOver = false;
		GM.coinTotal = 0;
	}
}
