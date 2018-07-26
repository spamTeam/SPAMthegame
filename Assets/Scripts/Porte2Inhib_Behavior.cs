using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Porte2Inhib_Behavior : MonoBehaviour {

    public Vector2 Left1, Right1, Down1, Up1;

    public Vector2 Left2, Right2, Down2, Up2;

    public Vector2 Left3, Right3, Down3, Up3;

    public Vector2 Left4, Right4, Down4, Up4;

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
            if (Mathf.Abs(CollisionPos.x - CurrentPos.x) > Mathf.Abs(CollisionPos.y - CurrentPos.y))
            {
                if (CollisionPos.x > CurrentPos.x)
                {
                    direction = "Left";
                }
                else if (CollisionPos.x < CurrentPos.x)
                {
                    direction = "Right";
                }
            }
            else if (Mathf.Abs(CollisionPos.x - CurrentPos.x) < Mathf.Abs(CollisionPos.y - CurrentPos.y))
            {
                if (CollisionPos.y > CurrentPos.y)
                {
                    direction = "Down";
                }
                else if (CollisionPos.y < CurrentPos.y)
                {
                    direction = "Up";
                }
            }
            else { Debug.Log("CollisionPos.x - CurrentPos.x = CollisionPos.y - CurrentPos.y"); }
        }

        if (ButtonBehavior != null)
        {
            iOnOff = ButtonBehavior.OnOff();
            modOnOff = iOnOff % 4;
            if (Left1 == Left3 && Left2 == Left4)
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
            if (direction == "Left") { return Left1; }
            else if (direction == "Right") { return Right1; }
            else if (direction == "Down") { return Down1; }
            else if (direction == "Up") { return Up1; }
            else { return Vector2.zero; }
        }
        else if (modOnOff == 1)
        {
            if (direction == "Left") { return Left2; }
            else if (direction == "Right") { return Right2; }
            else if (direction == "Down") { return Down2; }
            else if (direction == "Up") { return Up2; }
            else { return Vector2.zero; }
        }
        else if (modOnOff == 2)
        {
            if (direction == "Left") { return Left3; }
            else if (direction == "Right") { return Right3; }
            else if (direction == "Down") { return Down3; }
            else if (direction == "Up") { return Up3; }
            else { return Vector2.zero; }
        }
        else if (modOnOff == 3)
        {
            if (direction == "Left") { return Left4; }
            else if (direction == "Right") { return Right4; }
            else if (direction == "Down") { return Down4; }
            else if (direction == "Up") { return Up4; }
            else { return Vector2.zero; }
        }
        else { return Vector2.zero; }

    }
}
