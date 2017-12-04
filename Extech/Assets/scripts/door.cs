using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class door : MonoBehaviour {

    public int doorID = 0;
    Animation doorAnim;
    AudioSource doorAudio;
    public AudioClip doorSound;

    private void Start()
    {
        doorAnim = GetComponent<Animation>();
        doorAudio = GetComponent<AudioSource>();
    }

    public void accessDoor(int cardID)
    {
        if(cardID == doorID)
        {
            openDoor();
            Debug.Log("<color=green>PLAYER HAS VALID KEYCARD - openDoor</color>");
        }
    }

    public void openDoor()
    {
        doorAnim.Play();
        doorAudio.PlayOneShot(doorSound);
    }

}
