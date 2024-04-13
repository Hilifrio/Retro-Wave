using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityCore.Audio;
using AudioType = UnityCore.Audio.AudioType;

public class GM : MonoBehaviour
{
    public GameObject coinText;
    public GameObject timeText;
    public GameObject livesText;
    public static int coinTotal = 0;
    public static float timeTotal = 0;
    public int buildStep = 60;
    public int zScenePos = 44;
    public static int playerPos;
    public int randCoin;
    public int randObst;
    int prevObst = 0;
    public static int health = 0;
    public static int playerCoins = 0;

    public static bool gameOver = false;

    public static GM gm;

    public Transform coinObj;
    public Transform bonusObj;
    public Transform obstacleObj;
    public List<Transform> road;
    public List<Transform> grounds;

    int groundPos = 0;
    bool gamePaused = false;

    [SerializeField]
    GameObject damageEffect;

    [SerializeField]
    private GameObject gameOverUI;
    [SerializeField]
    private GameObject InGameUI;
    [SerializeField]
    private GameObject pauseUI;

    public AudioController audioController;
    void Start()
    {
        if (gm == null)
        {
            gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GM>();
        }
        timeTotal = 0;
        audioController.PlayAudio(AudioType.ST_Level1);
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameOver)
        {
            timeTotal += Time.deltaTime;
            coinText.GetComponent<Text>().text = "Coins : " + GM.coinTotal;
            timeText.GetComponent<Text>().text = "Time : " + Mathf.Round(GM.timeTotal);
            livesText.GetComponent<Text>().text = " : " + health;
            if (zScenePos < playerPos + 60)
            {
                
                randCoin = Random.Range(1, 3);
                randObst = Random.Range(1, 9);
                if (randObst == prevObst)
                {
                    randObst += 2;
                }
                if (randCoin == 1 && (randObst != 1 && randObst != 2 && randObst != 7 && randObst != 8))
                {
                    Instantiate(coinObj, new Vector3(-1, 1.1f, zScenePos), coinObj.rotation);
                    Instantiate(coinObj, new Vector3(-1, 1.1f, zScenePos + 1), coinObj.rotation);

                }
                else if (randCoin == 2 && (randObst != 3 && randObst != 4 && randObst != 7 && randObst != 9))
                {
                    Instantiate(coinObj, new Vector3(1, 1.1f, zScenePos), coinObj.rotation);
                    Instantiate(coinObj, new Vector3(1, 1.1f, zScenePos + 1), coinObj.rotation);

                }
                else if (randCoin == 3 && (randObst != 5 && randObst != 6 && randObst != 8 && randObst != 9))
                {
                    Instantiate(coinObj, new Vector3(0, 1.1f, zScenePos), coinObj.rotation);
                    Instantiate(coinObj, new Vector3(0, 1.1f, zScenePos + 1), coinObj.rotation);

                }

                if (randObst == 1 || randObst == 2)
                {
                    Instantiate(obstacleObj, new Vector3(-1, obstacleObj.position.y, zScenePos), obstacleObj.rotation);
                }
                if (randObst == 3 || randObst == 4)
                {
                    Instantiate(obstacleObj, new Vector3(1, obstacleObj.position.y, zScenePos), obstacleObj.rotation);
                }
                if (randObst == 5 || randObst == 6)
                {
                    Instantiate(obstacleObj, new Vector3(0, obstacleObj.position.y, zScenePos), obstacleObj.rotation);
                }

                if (randObst == 7)
                {
                    Instantiate(obstacleObj, new Vector3(-1, obstacleObj.position.y, zScenePos), obstacleObj.rotation);
                    Instantiate(obstacleObj, new Vector3(1, obstacleObj.position.y, zScenePos), obstacleObj.rotation);
                    Instantiate(coinObj, new Vector3(0, 1.1f, zScenePos - 1), coinObj.rotation);
                    Instantiate(coinObj, new Vector3(0, 1.1f, zScenePos), coinObj.rotation);
                    Instantiate(coinObj, new Vector3(0, 1.1f, zScenePos + 1), coinObj.rotation);
                    Instantiate(coinObj, new Vector3(0, 1.1f, zScenePos + 2), coinObj.rotation);
                }

                if (randObst == 8)
                {
                    Instantiate(obstacleObj, new Vector3(-1, obstacleObj.position.y, zScenePos), obstacleObj.rotation);
                    Instantiate(obstacleObj, new Vector3(0, obstacleObj.position.y, zScenePos), obstacleObj.rotation);
                    Instantiate(coinObj, new Vector3(1, 1.1f, zScenePos - 1), coinObj.rotation);
                    Instantiate(coinObj, new Vector3(1, 1.1f, zScenePos), coinObj.rotation);
                    Instantiate(coinObj, new Vector3(1, 1.1f, zScenePos + 1), coinObj.rotation);
                    Instantiate(coinObj, new Vector3(1, 1.1f, zScenePos + 2), coinObj.rotation);
                }
                if (randObst == 9)
                {
                    Instantiate(obstacleObj, new Vector3(1, obstacleObj.position.y, zScenePos), obstacleObj.rotation);
                    Instantiate(obstacleObj, new Vector3(0, obstacleObj.position.y, zScenePos), obstacleObj.rotation);
                    Instantiate(coinObj, new Vector3(-1, 1.1f, zScenePos - 1), coinObj.rotation);
                    Instantiate(coinObj, new Vector3(-1, 1.1f, zScenePos), coinObj.rotation);
                    Instantiate(coinObj, new Vector3(-1, 1.1f, zScenePos + 1), coinObj.rotation);
                    Instantiate(coinObj, new Vector3(-1, 1.1f, zScenePos + 2), coinObj.rotation);
                }

                //int randGround = Random.Range(0, road.Count);
                Instantiate(road[0], new Vector3(0, 0, zScenePos), road[0].rotation);

                zScenePos += buildStep;
                prevObst = randObst;
                //Debug.Log(zScenePos);
            }
            if (zScenePos + 200 > groundPos)
            {
                int randGround = Random.Range(0, grounds.Count);
                Instantiate(grounds[randGround], new Vector3(0, 0, groundPos), grounds[randGround].rotation);
                groundPos += 40;
            }
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Debug.Log("is PauseUi active : " + gamePaused);
                Pause();
            }
        }
    }

    private void FixedUpdate()
    {
    }

    public static void damagePlayer(moveplayer Player)
    {
        gm._damagePlayer(Player);
    }

    void EndGame()
    {
        playerCoins += coinTotal;
        gm.gameOverUI.SetActive(true);
    }

    void _damagePlayer(moveplayer Player)
    {
        Player.health--;
        if (Player.health == 0)
        {
            audioController.PlayAudio(AudioType.SFX_Car_Crash);
            audioController.StopAudio(AudioType.SFX_DeloreanMotor);
            Debug.Log("Game Over");
            gameOver = true;
            livesText.GetComponent<Text>().text = " : " + health;
            Player.m_Animator.SetTrigger("death");
            StartCoroutine(slowTime());
            gm.EndGame();
            //playerDeathEffect.SetActive(true)
        }
        else if(Player.health>0)
        {
            audioController.PlayAudio(AudioType.SFX_Car_Damage);
            Player.damageCd = true;
            Player.m_Animator.SetTrigger("damaged");
            StartCoroutine(slowTime());
        }
    }

    private IEnumerator slowTime()
    {
        Time.timeScale = 0.7f;
        damageEffect.SetActive(true);
        yield return new WaitForSeconds(1f);
        damageEffect.SetActive(false);
        Time.timeScale = 1.0f;
    }

    public void Pause()
    {
        gamePaused = !gamePaused;
        if (gamePaused)
        {
            audioController.PauseAudio(AudioType.ST_Level1, true);
            audioController.PauseAudio(AudioType.SFX_DeloreanMotor, true);
            pauseUI.SetActive(true);
            Time.timeScale = 0f;
        }
        else
        {
            audioController.ReplayAudio(AudioType.ST_Level1, true);
            audioController.ReplayAudio(AudioType.SFX_DeloreanMotor, true);
            pauseUI.SetActive(false);
            Time.timeScale = 1f;
        }
        
    }
}
