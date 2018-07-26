using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class EndLevel : MonoBehaviour {
    public string sceneName;
    private bool EndLevelCollision;


    // Use this for initialization
    void Start () {
        EndLevelCollision = false;
    }
	
	// Update is called once per frame
	void Update () {

        if (EndLevelCollision)
        {
            if (Input.GetButtonDown("NextLevel"))
            {
                SceneManager.LoadScene(sceneName);
            }
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            EndLevelCollision = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            EndLevelCollision = false;
        }
    }
}
