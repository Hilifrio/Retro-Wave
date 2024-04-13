using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movecam : MonoBehaviour
{
    // Start is called before the first frame update
    public float camSpeed=0;
    private Transform lookAt;
    public Vector3 camOffset;
    float playerOffset;
    Vector3 moveVector;

    [SerializeField]
    float transition = 0.0f;
    float animationDuration = 2.0f;
    Vector3 animationPosOffset = new Vector3 (0,0,20);
    Quaternion animationRotOffset = new Quaternion (0,180,0,5);

    void Start()
    {
        //GetComponent<Rigidbody>().velocity = new Vector3(0, 0, camSpeed);
        lookAt = GameObject.FindGameObjectWithTag("Player").transform;
        playerOffset=lookAt.position.x;
        //startOffset = transform.position.z;
    }

    // Update is called once per frame
    void Update()
    {
        if(lookAt == null)
        {
            //transform.position = Vector3.Lerp(moveVector, new Vector3(moveVector.x, moveVector.y,10000), Time.deltaTime);
            return;
        }
        moveVector = lookAt.position + camOffset;

        //X
        moveVector.x = (lookAt.position.x - playerOffset) / 2;
        //Y
        moveVector.y = transform.position.y;
        //Z

        if(transition > 1.5f)
        {
            transform.position = moveVector;
            GetComponent<Animator>().enabled = false;
        }
            
        else
        {
            //transform.position = Vector3.Lerp(moveVector + animationPosOffset, moveVector,transition);
            //transform.rotation = Quaternion.Lerp(animationRotOffset, Quaternion.identity, transition);
            transition += Time.deltaTime * 1 / animationDuration;
            
        }

    }
}
