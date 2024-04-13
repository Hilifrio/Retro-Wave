using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FogMotor : MonoBehaviour
{
    private Transform lookAt;
    public int offset;
    Vector3 moveVector;
    // Start is called before the first frame update
    void Start()
    {
        lookAt = GameObject.FindGameObjectWithTag("Player").transform;
        moveVector.x = transform.position.x;
        moveVector.y = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        if (lookAt == null)
        {
            return;
        }
        moveVector.z = lookAt.position.z + offset;
        transform.position = moveVector;
    }
}
