using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Porte2_Behavior : MonoBehaviour {

    public Vector2 destination_Horizontal1;
    public Vector2 destination_Vertical1;
    public Vector2 destination_Horizontal2;
    public Vector2 destination_Vertical2;
    public Vector2 destination_Horizontal3;
    public Vector2 destination_Vertical3;
    public Vector2 destination_Horizontal4;
    public Vector2 destination_Vertical4;
    public Button_Behavior ButtonBehavior;
    private double iOnOff;
    public float SensRotation;
    private float startAngle;
    private double modOnOff;
    private double mod2OnOff;

    private bool InCollision = false;
    private string direction;
    private Vector3 CollisionPos;
    private Vector3 CurrentPos;


    // Use this for initialization
    void Start () {
        startAngle = transform.localRotation.eulerAngles.z * Mathf.PI / 180;
        modOnOff = 0;
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

        if (ButtonBehavior != null)
        {
            iOnOff = ButtonBehavior.OnOff();
            modOnOff = iOnOff % 4;
            if (destination_Horizontal1 == destination_Horizontal3 && destination_Horizontal2 == destination_Horizontal4 && destination_Vertical1 == destination_Vertical3 && destination_Vertical2 == destination_Vertical4)
            {
                mod2OnOff = iOnOff % 2;
                transform.rotation = Quaternion.EulerAngles(new Vector3(0, 0, startAngle - Mathf.PI / 2 * (SensRotation * (float)mod2OnOff)));
            }
            else
            {
                transform.rotation = Quaternion.EulerAngles(new Vector3(0, 0, startAngle - Mathf.PI / 2 * (SensRotation * (float)modOnOff)));
            }
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
        if (modOnOff == 0)
        {
            if (direction == "Horizontal") { return destination_Vertical1; }
            else if (direction == "Vertical") { return destination_Horizontal1; }
            else { return Vector2.zero; }
        }
        else if (modOnOff == 1)
        {
            if (direction == "Horizontal") { return destination_Vertical2; }
            else if (direction == "Vertical") { return destination_Horizontal2; }
            else { return Vector2.zero; }
        }
        else if (modOnOff == 2)
        {
            if (direction == "Horizontal") { return destination_Vertical3; }
            else if (direction == "Vertical") { return destination_Horizontal3; }
            else { return Vector2.zero; }
        }
        else if (modOnOff == 3)
        {
            if (direction == "Horizontal") { return destination_Vertical4; }
            else if (direction == "Vertical") { return destination_Horizontal4; }
            else { return Vector2.zero; }
        }
        else { return Vector2.zero; }

    }
}
