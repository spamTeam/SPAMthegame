using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ResetlevelTrap : MonoBehaviour {

    bool CollisionTrap = false;
    public AudioSource audioTrap;
    public AudioClip soundTrap;

    // Use this for initialization
    void Start () {
    }

    IEnumerator LoadScene()
    {
        if (!audioTrap.isPlaying)
        {
            audioTrap.PlayOneShot(soundTrap);
        }
        yield return new WaitForSeconds(1.0f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }


    // Update is called once per frame
    void Update () {
        
        if(CollisionTrap)
        {
            StartCoroutine(LoadScene()); //appel de la fonction
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            CollisionTrap = true;
        }
    }

}
