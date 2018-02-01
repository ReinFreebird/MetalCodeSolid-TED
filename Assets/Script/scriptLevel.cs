using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scriptLevel : MonoBehaviour {
	public SceneManagerClassv2 sceneMan;
	private AudioSource audioX;
	// Use this for initialization
	void Start () {
		audioX = gameObject.GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void backButton(){
		audioX.Play ();
		sceneMan.changeSceneNoLoading (0);
	}
	public void levelSelect(){
		audioX.Play ();
		sceneMan.changeSceneNoLoading (2);
	}
}
