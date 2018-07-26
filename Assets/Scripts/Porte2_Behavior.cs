using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Porte2_Behavior : MonoBehaviour {

    public Vector2 destination_Horizontal;
    public Vector2 destination_Vertical;
    private bool InCollision = false;
    private string direction;
    private Vector3 CollisionPos;
    private Vector3 CurrentPos;


    // Use this for initialization
    void Start () {
    }
	
	// Update is called once per frame
	void Update () {

        if (InCollision) {
            if (Mathf.Abs(CollisionPos.x-CurrentPos.x) > Mathf.Abs(CollisionPos.y - CurrentPos.y))
            {
                direction = "Horizontal";
            }
            else if(Mathf.Abs(CollisionPos.x - CurrentPos.x) < Mathf.Abs(CollisionPos.y - CurrentPos.y))
            {
                direction = "Vertical";
            }
            else { Debug.Log("CollisionPos.x - CurrentPos.x = CollisionPos.y - CurrentPos.y"); }
        }


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {   // Hitbox est une Porte
        if (collision.tag == "Player")
        {
            InCollision = true;
            CollisionPos = collision.transform.position;
            CurrentPos = transform.position;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            InCollision = false;
        }
    }

    public Vector3 GetNewDestination()
    {
        if (direction == "Horizontal") { return destination_Horizontal; }
        else if (direction == "Vertical") { return destination_Vertical; }
        else { return Vector2.zero; }

    }
}
