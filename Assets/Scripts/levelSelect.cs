using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class levelSelect : MonoBehaviour {

    public Animator transitionAnim;
    public string sceneName;
    public KeyCode keypress;

    //Fonction pour géré l'animation et le passage à la scène suivante
    IEnumerator LoadScene()
    {
        transitionAnim.SetTrigger("level1trig");
        yield return new WaitForSeconds(1.0f);
        SceneManager.LoadScene("level1");
    }


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        
        if(Input.GetKeyDown(keypress))
        {
            StartCoroutine(LoadScene());
        }

        
    }


}
