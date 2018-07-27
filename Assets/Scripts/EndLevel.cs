using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class EndLevel : MonoBehaviour {

    public string sceneName;
    private bool EndLevelCollision;
    public AudioSource audioEnd;
    public AudioClip soundEnd;

    // Use this for initialization
    void Start () {
        EndLevelCollision = false;
    }

    IEnumerator LoadScene()
    {
        if (!audioEnd.isPlaying)
        {
            audioEnd.PlayOneShot(soundEnd);
        }
        yield return new WaitForSeconds(1.2f);
        SceneManager.LoadScene(sceneName);
    }

    // Update is called once per frame
    void Update () {

        if (EndLevelCollision)
        {

            StartCoroutine(LoadScene()); //appel de la fonction

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
