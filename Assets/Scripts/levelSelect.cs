using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class levelSelect : MonoBehaviour {

    public Animator transitionAnim1;
    public Animator transitionAnim2;
    public Animator transitionAnim3;
    public Animator transitionAnim4;
    public string sceneName1;
    public string sceneName2;
    public string sceneName3;
    public string sceneName4;
    public KeyCode keypresslevel1;
    public KeyCode keypresslevel2;
    public KeyCode keypresslevel3;
    public KeyCode keypresslevel4;

    public AudioSource audioLevel;
    public AudioClip soundLevel;

    //Fonction pour géré l'animation et le passage à la scène suivante
    IEnumerator LoadScene1()
    {
        if (!audioLevel.isPlaying)
        {
            transitionAnim1.SetTrigger("level1trig");
            audioLevel.PlayOneShot(soundLevel);
        }
        
        yield return new WaitForSeconds(1.0f);
        SceneManager.LoadScene(sceneName1);
    }

    IEnumerator LoadScene2()
    {
        if (!audioLevel.isPlaying)
        {
            transitionAnim2.SetTrigger("level1trig");
            audioLevel.PlayOneShot(soundLevel);
        }
        
        yield return new WaitForSeconds(1.0f);
        SceneManager.LoadScene(sceneName2);
    }

    IEnumerator LoadScene3()
    {
        if (!audioLevel.isPlaying)
        {
            transitionAnim3.SetTrigger("level1trig");
            audioLevel.PlayOneShot(soundLevel);
        }
        
        yield return new WaitForSeconds(1.0f);
        SceneManager.LoadScene(sceneName3);
    }

    IEnumerator LoadScene4()
    {
        if (!audioLevel.isPlaying)
        {
            transitionAnim4.SetTrigger("level1trig");
            audioLevel.PlayOneShot(soundLevel);
        }
        
        yield return new WaitForSeconds(1.0f);
        SceneManager.LoadScene(sceneName4);
    }



    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        
        if(Input.GetKeyDown(keypresslevel1))
        {
            StartCoroutine(LoadScene1()); //appel de la fonction
        }
        else if (Input.GetKeyDown(keypresslevel2))
        {
            StartCoroutine(LoadScene2()); //appel de la fonction
        }
        else if (Input.GetKeyDown(keypresslevel3))
        {
            StartCoroutine(LoadScene3()); //appel de la fonction
        }
        else if (Input.GetKeyDown(keypresslevel4))
        {
            StartCoroutine(LoadScene4()); //appel de la fonction
        }


    }


}
