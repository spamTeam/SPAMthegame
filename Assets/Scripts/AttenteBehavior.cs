using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttenteBehavior : MonoBehaviour {

    public Vector2 destination_Right;
    public Vector2 destination_Left;
    public Vector2 destination_Up;
    public Vector2 destination_Down;
    private Vector2 destination;
    private string Pressed_Direction;

    public AudioSource audioLance;
    public AudioClip soundLance;


    // Use this for initialization
    void Start() {
    }

    // Update is called once per frame
    void Update()
    {
        Pressed_Direction = "None";
        if (Input.anyKeyDown)
        {

            if (Input.GetButtonDown("Left")) {
                Pressed_Direction = "a" ;
                // sound
                if (!audioLance.isPlaying)
                {
                    audioLance.PlayOneShot(soundLance);
                }
            }
            else if(Input.GetButtonDown("Right")) {
                Pressed_Direction = "d";
                // sound
                if (!audioLance.isPlaying)
                {
                    audioLance.PlayOneShot(soundLance);
                }
            }
            else if (Input.GetButtonDown("Down"))
            {
                Pressed_Direction = "s";
                // sound
                if (!audioLance.isPlaying)
                {
                    audioLance.PlayOneShot(soundLance);
                }
            }
            else if (Input.GetButtonDown("Up"))
            {
                Pressed_Direction = "w";
                // sound
                if (!audioLance.isPlaying)
                {
                    audioLance.PlayOneShot(soundLance);
                }
            }

        }

    }

    public Vector3 GetNewDestination() // En azerty pour l'instant
    {

        switch (Pressed_Direction)
        {
            case "d":
                destination = destination_Right;
                return destination;
            case "a":
                destination = destination_Left;
                return destination;
            case "w":
                destination = destination_Up;
                return destination;
            case "s":
                destination = destination_Down;
                return destination;
            default:
                destination = Vector2.zero ;
                return destination;
        }

    }


    private void OnDrawGizmos() // Creation d'un carré visible uniquement dans l'éditeur
    {
        Gizmos.color = Color.red;
        Gizmos.DrawCube(transform.position, new Vector3(0.5f, 0.5f, 0.0f));
    }

}
