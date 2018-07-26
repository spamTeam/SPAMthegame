using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMouvement : MonoBehaviour {

    [SerializeField] float deltaTime; // secondes
    Transform Pos_currentPoint;
    string Tag_currentPoint;
    float timer;
    Vector3 initPos;
    //Vector3 startPos;
    Vector3 destination;
    Vector3 newDestination;


    void Start () {
        timer = Time.time;
        //startPos = transform.position;
    }


    void Update () {

        // Si mouvement, trigger par collision avec Porte ou input dans Attente
        if (timer > Time.time)
        {
            Vector3 actualPosition = transform.position;
            actualPosition.x = Mathf.Lerp(destination.x, initPos.x, (timer - Time.time) / deltaTime); // Mouvement en x
            actualPosition.y = Mathf.Lerp(destination.y, initPos.y, (timer - Time.time) / deltaTime); // Mouvement en y
            transform.position = actualPosition; // Attribution de la nouvelle position apres mouvement
        }

        // Si pas de mouvement
        else
        {    // Si dans une hitbox
            if (Pos_currentPoint != null)
            {   // Si la hitbox est une porte
                if (Tag_currentPoint == "Porte")
                {
                    newDestination = Pos_currentPoint.GetComponent<PorteBehavior>().GetNewDestination();
                    destination = transform.position + newDestination; // nouvelle destination
                    initPos = transform.position; // position au début du mouvement
                    timer = Time.time + deltaTime; // Le timer est mis à jour, trigger de la highest condition if
                } // Si la hitbox est une Attente
                else if (Tag_currentPoint == "Attente") 
                {
                    newDestination = Pos_currentPoint.GetComponent<AttenteBehavior>().GetNewDestination();
                    destination = transform.position + newDestination;
                    if (destination != transform.position) // si nous ne restons pas immobile
                    {
                        initPos = transform.position;
                        timer = Time.time + deltaTime;
                    }
                }
                
                else if (Tag_currentPoint == "Porte2Corner")
                {
                    newDestination = Pos_currentPoint.GetComponent<Porte2_Behavior>().GetNewDestination();
                    destination = transform.position + newDestination; // nouvelle destination
                    initPos = transform.position; // position au début du mouvement
                    timer = Time.time + deltaTime; // Le timer est mis à jour, trigger de la highest condition if
                }

                else if (Tag_currentPoint == "CornerPorte")
                {
                    newDestination = Pos_currentPoint.GetComponent<Corner_Behavior>().GetNewDestination();
                    destination = transform.position + newDestination; // nouvelle destination
                    initPos = transform.position; // position au début du mouvement
                    timer = Time.time + deltaTime; // Le timer est mis à jour, trigger de la highest condition if
                }
                else if (Tag_currentPoint == "CornerInhib")
                {
                    newDestination = Pos_currentPoint.GetComponent<Porte2Inhib_Behavior>().GetNewDestination();
                    destination = transform.position + newDestination; // nouvelle destination
                    initPos = transform.position; // position au début du mouvement
                    timer = Time.time + deltaTime; // Le timer est mis à jour, trigger de la highest condition if
                }
            }
            else // Si ni mouvement, ni collision avec hitbox
            {
                Debug.LogError("SPAAAAACE !");
            }
        }
    }



    // Si dans une hitbox
    private void OnTriggerEnter2D(Collider2D collision)
    {   // Hitbox est une Porte
        if (collision.tag == "Porte")
        {
            Tag_currentPoint = "Porte";
            Pos_currentPoint = collision.transform;
        } // Hitbox est une Attente
        else if (collision.tag == "Attente")
        {
            Tag_currentPoint = "Attente";
            Pos_currentPoint = collision.transform;
        }
        else if (collision.tag == "CornerPorte")
        {
            Tag_currentPoint = "CornerPorte";
            Pos_currentPoint = collision.transform;
        }
        else if (collision.tag == "Porte2Corner")
        {
            Tag_currentPoint = "Porte2Corner";
            Pos_currentPoint = collision.transform;
        }
        else if (collision.tag == "CornerInhib")
        {
            Tag_currentPoint = "CornerInhib";
            Pos_currentPoint = collision.transform;
        }
    }


    // Lorsqu'on sort d'une Porte ou d'une Attente, plus de position
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Porte" || collision.tag == "Attente" || collision.tag =="CornerPorte")
        {
            Tag_currentPoint = "En Chemin";
            Pos_currentPoint = null;
        }
    }


}
