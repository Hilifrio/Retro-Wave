using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public List<Material> colors;
    [Range(1f, 10f)]
    public float colorChangingRate;
    float rate;
    int colorInd = 0;
    // Start is called before the first frame update
    void Start()
    {
        rate = colorChangingRate;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if (Time.time * colorChangingRate % 1 == 0)
        {
            int randCol = Random.Range(0, colors.Count);
            if (colorInd >= colors.Count)
            {
                colorInd = 0;
            }
            GetComponent<Renderer>().material = colors[colorInd];
            colorInd++;
            rate = colorChangingRate;
        }
        else
        {
            //rate -= Time.deltaTime;
        }
    }
}
