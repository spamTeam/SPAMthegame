using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttenteBehavior : MonoBehaviour {

    public Vector2 destination_Right;
    public Vector2 destination_Left;
    public Vector2 destination_Up;
    public Vector2 destination_Down;
    private string Pressed_Direction;

    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        if (Input.anyKeyDown)
        {
            Debug.Log("kew : " + Input.inputString);
            Pressed_Direction = Input.inputString;
        }

    }

    public Vector3 GetNewDestination() // En azerty pour l'instant
    {

        switch (Pressed_Direction)
        {
            case "d":
                Debug.Log("pre : " + Pressed_Direction);
                Pressed_Direction = "None";
                return destination_Right;
            case "q":
                Pressed_Direction = "None";
                return destination_Left;
            case "z":
                Pressed_Direction = "None";
                return destination_Up;
            case "s":
                Pressed_Direction = "None";
                return destination_Down;
            default:
                return Vector2.zero;
        }
    }

   
    private void OnDrawGizmos() // Creation d'un carré visible uniquement dans l'éditeur
    {
        Gizmos.color = Color.red;
        Gizmos.DrawCube(transform.position, new Vector3(0.5f, 0.5f, 0.0f));
    }

}
