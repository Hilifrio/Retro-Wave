using System.Collections;
using System.Collections.Generic;
using UnityCore.Audio;
using UnityEngine;
using AudioType = UnityCore.Audio.AudioType;

public class ArcadeMachine : MonoBehaviour
{
    [SerializeField]
    GameObject text = null;
    [SerializeField]
    AudioController audioController = null;
    [SerializeField]
    string action;

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseOver()
    {
        GetComponent<Renderer>().material.color = Color.grey;
        
        text.SetActive(true);
    }
    private void OnMouseEnter()
    {
        audioController.PlayAudio(AudioType.SFX_ArcadeMachine);
    }
    private void OnMouseExit()
    {
        GetComponent<Renderer>().material.color = Color.white;
        //audioController.StopAudio(AudioType.ST_Menu);
        text.SetActive(false);
    }

    private void OnMouseDown()
    {
        StartCoroutine(LoadScene());
    }
    
    IEnumerator LoadScene()
    {
        audioController.PlayAudio(AudioType.SFX_CassettePlay);

        yield return new WaitForSeconds(0.5f);
        MainMenu.ManageMenu(action);
    }
}
