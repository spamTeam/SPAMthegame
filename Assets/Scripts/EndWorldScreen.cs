using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndWorldScreen : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
       
       
       if (Input.GetButtonDown("SelectionLevel"))
        {
            SceneManager.LoadScene("Mainmenu");
            Debug.Log("test");
        }
    }

}

