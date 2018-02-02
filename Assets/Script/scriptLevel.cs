using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scriptLevel : MonoBehaviour {
	public SceneManagerClassv2 sceneMan;
	public SoundManager soundMan;
	//private AudioSource audioX;
	// Use this for initialization
	void Start () {
		//GameObject[] temp = this.GetComponentsInChildren<GameObject> ();

		//audioX = gameObject.GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void backButton(){
		soundMan.playSFX (0);
		sceneMan.changeSceneNoLoading (0);
	}
	public void levelSelect(){
		soundMan.playSFX (1);
		sceneMan.changeSceneNoLoading (2);
	}
}
