using System.Collections;
using System.Collections.Generic;
using UnityCore.Audio;
using UnityEngine;
using AudioType = UnityCore.Audio.AudioType;

public class moveplayer : MonoBehaviour
{

    private CharacterController controller;

    public Animator m_Animator;
    bool idle = false;
    public float forwardSpeed = 4;

    float speedIncreaseRate = 5f;

    //public float horizVel = 0;
    public int actualLane = 2; //1:left 2:middle 3:right
    public int targetLane = 2;
    public int health = 2;
    public bool damageCd = false;
    [SerializeField]
    float horizontalSpeed;
    [SerializeField]
    AudioController audioController;
    [SerializeField]
    AudioManager audioManager;
    [SerializeField]
    string turningSound;
    [SerializeField]
    string idleSound;
    Vector3 moveVector;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        m_Animator = GetComponent<Animator>();
        audioManager.PlaySound("Music");
    }

    // Update is called once per frame
    void Update()
    {
        GM.health = health;
        horizontalSpeed = forwardSpeed / 2;
        if (GM.gameOver != true)
        {
            moveVector = new Vector3(0, 0, forwardSpeed);
            GM.playerPos = (int)transform.position.z;
            moveVector.y = 0;
            moveVector.x = Input.GetAxisRaw("Horizontal") * horizontalSpeed;

            if (Input.GetKeyDown(KeyCode.Q) || Input.GetKeyDown(KeyCode.D))
            {
                idle = false;
                audioManager.PlaySound(turningSound);
            }

            else if(idle == false && !(Input.GetKey(KeyCode.Q) || Input.GetKey(KeyCode.D)))
            {
                idle = true;
                audioManager.PlaySound(idleSound);
            }

            if (Input.GetAxisRaw("Horizontal")<0)
            {
                m_Animator.SetBool("movingLeft", true);
                m_Animator.SetBool("movingRight", false);
            }
            
            else if (Input.GetAxisRaw("Horizontal")>0)
            {
                m_Animator.SetBool("movingRight", true);
                m_Animator.SetBool("movingLeft", false);
            }
            else
            {
                m_Animator.SetBool("movingRight", false);
                m_Animator.SetBool("movingLeft", false);
                //audioController.PlayAudio(AudioType.SFX_DeloreanMotor);
            }
        }
        else
        {
            moveVector = new Vector3(0, 0, 0);
        }

        speedIncreaseRate -= Time.deltaTime;

        if (speedIncreaseRate <= 0)
        {
            speedIncreaseRate = 5f;
            forwardSpeed += 0.05f;
        }
    }

    private void FixedUpdate()
    {
        controller.Move(moveVector * Time.fixedDeltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Lethal" && !damageCd)
        {
            GM.damagePlayer(this);
            StartCoroutine(damaged());
        }

        if (other.gameObject.tag == "Coin")
        {
            GM.coinTotal += 1;
            Destroy(other.gameObject);
            audioManager.PlaySound("Coin");
        }

        if (other.gameObject.tag == "Bonus")
        {
            Destroy(other.gameObject);
        }
    }

    private IEnumerator damaged()
    {
        yield return new WaitForSeconds(3f);
        damageCd = false;
    }
}
