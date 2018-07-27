using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Porte2_Behavior : MonoBehaviour {

    public Vector2 Horizontal1;
    public Vector2 Vertical1;
    public Vector2 Horizontal2;
    public Vector2 Vertical2;
    public Vector2 Horizontal3;
    public Vector2 Vertical3;
    public Vector2 Horizontal4;
    public Vector2 Vertical4;

    public Button_Behavior ButtonBehavior;
    private double iOnOff;
    public float SensRotation;
    private float startAngle;
    private double modOnOff;
    private double mod2OnOff;

    private bool InCollision;
    private string direction;
    private Vector3 CollisionPos;
    private Vector3 CurrentPos;

    //for animation
    public Animator transitionAnim1;
    private double iOnOffTOT;
    private double iOnOffLast;
    private double countrotation;

    // Use this for initialization
    void Start () {
        startAngle = transform.localRotation.eulerAngles.z * Mathf.PI / 180;
        modOnOff = 0;
        iOnOffLast = 0;
        countrotation = 0;
        InCollision = false;
    }

    // Update is called once per frame
    void Update () {

        if (InCollision)
        {
            if (Mathf.Abs(CollisionPos.x - CurrentPos.x) > Mathf.Abs(CollisionPos.y - CurrentPos.y))
            {
                direction = "Horizontal";
            }
            else if (Mathf.Abs(CollisionPos.x - CurrentPos.x) < Mathf.Abs(CollisionPos.y - CurrentPos.y))
            {
                direction = "Vertical";
            }
            else { Debug.Log("CollisionPos.x - CurrentPos.x = CollisionPos.y - CurrentPos.y"); }
        }

        //// Gesion des animation
        iOnOffTOT = ButtonBehavior.OnOff();
        if (iOnOffTOT != iOnOffLast)//boucle qui sera exécutez uniquement si il y a eu un press
        {
            iOnOffLast = iOnOffTOT;

            if (Horizontal1 == Horizontal3 && Horizontal2 == Horizontal4 && Vertical1 == Vertical3 && Vertical2 == Vertical4) //test si on a un interupteur 2 ou 4 position
            {
                if (countrotation == 0)
                {
                    countrotation = 1;
                    transitionAnim1.SetTrigger("rotation1"); //appel de la fonction 

                }
                else
                {
                    countrotation = 0;
                    transitionAnim1.SetTrigger("rotation2");

                }

            }
            else
            {

                if (countrotation == 0)
                {
                    countrotation = 1;
                    transitionAnim1.SetTrigger("rotation1");
                    //Debug.Log("rotation1");
                }
                else if (countrotation == 1)
                {
                    countrotation = 2;
                    transitionAnim1.SetTrigger("rotation2");
                    //Debug.Log("rotation2");

                }
                else if (countrotation == 2)
                {
                    countrotation = 3;
                    transitionAnim1.SetTrigger("rotation3");
                    //Debug.Log("rotation3");

                }
                else if (countrotation == 3)
                {
                    countrotation = 0;
                    transitionAnim1.SetTrigger("rotation4");
                    //Debug.Log("rotation4");
                }

                //sound

            }



            ////FIN animation ////

            if (ButtonBehavior != null)
            {
                iOnOff = ButtonBehavior.OnOff();
                modOnOff = iOnOff % 4;
                if (Horizontal1 == Horizontal3 && Horizontal2 == Horizontal4 && Vertical1 == Vertical3 && Vertical2 == Vertical4)
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
        Debug.Log(direction);

        if (modOnOff == 0)
        {
            if (direction == "Vertical") { return Vertical1; }
            else if (direction == "Horizontal") { return Horizontal1; }
            else { return Vector2.zero; }
        }
        else if (modOnOff == 1)
        {
            if (direction == "Vertical") { return Vertical2; }
            else if (direction == "Horizontal") { return Horizontal2; }
            else { return Vector2.zero; }
        }
        else if (modOnOff == 2)
        {
            if (direction == "Vertical") { return Vertical3; }
            else if (direction == "Horizontal") { return Horizontal3; }
            else { return Vector2.zero; }
        }
        else if (modOnOff == 3)
        {
            if (direction == "Vertical") { return Vertical4; }
            else if (direction == "Horizontal") { return Horizontal4; }
            else { return Vector2.zero; }
        }
        else { return Vector2.zero; }

    }
}
