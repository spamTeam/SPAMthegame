using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicController : MonoBehaviour {

    AudioSource music;

	// Use this for initialization
	void Start () {
        DontDestroyOnLoad(gameObject);
        music = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {
        if (SceneManager.GetActiveScene().name.Equals("Mainmenu") || SceneManager.GetActiveScene().name.Equals("EndWorld1")) { music.Stop(); }
	}
}
