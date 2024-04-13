using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuCamera : MonoBehaviour
{
    public int zScenePos = 0;
    public int randCoin;
    public int randObst;
    int prevObst = 0;
    public Transform coinObj;
    public Transform bonusObj;
    public Transform obstacleObj;
    public Transform road;
    public int buildStep = 4;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 2);
    }

    // Update is called once per frame
    void Update()
    {
        if (zScenePos < transform.position.z + 60)
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
                Instantiate(obstacleObj, new Vector3(-1, 0.8f, zScenePos), coinObj.rotation);
            }
            if (randObst == 3 || randObst == 4)
            {
                Instantiate(obstacleObj, new Vector3(1, 0.8f, zScenePos), coinObj.rotation);
            }
            if (randObst == 5 || randObst == 6)
            {
                Instantiate(obstacleObj, new Vector3(0, 0.8f, zScenePos), coinObj.rotation);
            }

            if (randObst == 7)
            {
                Instantiate(obstacleObj, new Vector3(-1, 0.8f, zScenePos), coinObj.rotation);
                Instantiate(obstacleObj, new Vector3(1, 0.8f, zScenePos), coinObj.rotation);
                Instantiate(coinObj, new Vector3(0, 1.1f, zScenePos - 1), coinObj.rotation);
                Instantiate(coinObj, new Vector3(0, 1.1f, zScenePos), coinObj.rotation);
                Instantiate(coinObj, new Vector3(0, 1.1f, zScenePos + 1), coinObj.rotation);
                Instantiate(coinObj, new Vector3(0, 1.1f, zScenePos + 2), coinObj.rotation);
            }

            if (randObst == 8)
            {
                Instantiate(obstacleObj, new Vector3(-1, 0.8f, zScenePos), coinObj.rotation);
                Instantiate(obstacleObj, new Vector3(0, 0.8f, zScenePos), coinObj.rotation);
                Instantiate(coinObj, new Vector3(1, 1.1f, zScenePos - 1), coinObj.rotation);
                Instantiate(coinObj, new Vector3(1, 1.1f, zScenePos), coinObj.rotation);
                Instantiate(coinObj, new Vector3(1, 1.1f, zScenePos + 1), coinObj.rotation);
                Instantiate(coinObj, new Vector3(1, 1.1f, zScenePos + 2), coinObj.rotation);
            }
            if (randObst == 9)
            {
                Instantiate(obstacleObj, new Vector3(1, 0.8f, zScenePos), coinObj.rotation);
                Instantiate(obstacleObj, new Vector3(0, 0.8f, zScenePos), coinObj.rotation);
                Instantiate(coinObj, new Vector3(-1, 1.1f, zScenePos - 1), coinObj.rotation);
                Instantiate(coinObj, new Vector3(-1, 1.1f, zScenePos), coinObj.rotation);
                Instantiate(coinObj, new Vector3(-1, 1.1f, zScenePos + 1), coinObj.rotation);
                Instantiate(coinObj, new Vector3(-1, 1.1f, zScenePos + 2), coinObj.rotation);
            }

            Instantiate(road, new Vector3(0, 0, zScenePos), road.rotation);

            zScenePos += buildStep;
            prevObst = randObst;
        }
    }
}
