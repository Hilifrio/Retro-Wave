using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityCore
{
    namespace Audio
    {
        public class TestAudio : MonoBehaviour
        {
            public AudioController audioController;

            private void Update()
            {
                if (Input.GetKeyUp(KeyCode.T))
                {
                    Debug.Log("Play Audio");
                    audioController.PlayAudio(AudioType.ST_Level1, true);
                } 
                if (Input.GetKeyUp(KeyCode.P))
                {
                    audioController.StopAudio(AudioType.ST_Level1, true, 1f);
                    //audioController.StopAudio(AudioType.ST_Menu, true, 1f);
                } 
                if (Input.GetKeyUp(KeyCode.R))
                {
                    audioController.ReplayAudio(AudioType.ST_Level1);
                }
                if (Input.GetKeyUp(KeyCode.A))
                {
                    audioController.PauseAudio(AudioType.ST_Level1, true);
                }
                if (Input.GetKeyUp(KeyCode.Space))
                {
                    audioController.PlayAudio(AudioType.ST_Menu);
                }
            }
        }

    }
}

