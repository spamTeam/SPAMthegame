using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button_Behavior : MonoBehaviour {

    private bool InInterrupteur;
    private double iOnOff;
    public AudioSource audio;
    public AudioClip sound;

    // Use this for initialization
    void Start () {
        iOnOff = 0;
        InInterrupteur = false;
    }

    // Update is called once per frame
    void Update () {


        if (InInterrupteur)
        { // Si bouton Espace appuyé
            if (Input.GetButtonDown("Interaction"))
            {
                if(!audio.isPlaying)
                {
                    audio.PlayOneShot(sound);
                }
                iOnOff += 1; // 1 ou 0 selon appuie barre espace
                //Debug.Log(iOnOff);
            }
        }
    }

    public double OnOff()
    {
        return iOnOff;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            InInterrupteur = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "Player") { InInterrupteur = false; }
    }
}
