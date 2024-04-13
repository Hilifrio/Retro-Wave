using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bonus : MonoBehaviour
{
    public float rotateSpeed = 0;
    public GameObject go;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(go != null)
        {
            go.transform.Rotate(rotateSpeed, 0, 0);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
