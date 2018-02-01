using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
public class scriptMenuMain : MonoBehaviour {
	
	public GameObject mainButton;


	public GameObject mainCredit;


	public GameObject mainSetting;
	public Toggle bgmToggle, sfxToggle, fullscreen;
	public GameObject textSpeedSlider;


	public SceneManagerClassv2 sceneman;

	//Objects for highscore
	public GameObject highScore;
	public Text[] highUserText;
	public Text[] highScoresText;
	public int[] highScores;
	public string[] highUser;
	private AudioSource audioX;
	//public Text[] SortUser;
	// Use this for initialization
	void Awake(){
		Screen.SetResolution (1028, 769, true);
	}
	void Start () {
		audioX = gameObject.GetComponent<AudioSource> ();
		highUser = PlayerPrefsX.GetStringArray ("userArray", "Anonim", 15);
		highScores = PlayerPrefsX.GetIntArray ("scoreArray",0,15);
		insertScore ();
	}
	private void setupSetting(){
		
	}

	// Update is called once per frame
	void Update () {
		//private void startGame(){
		//	gameObject.
	}
	public void clickStart(){
		audioX.Play ();
		sceneman.changeSceneNoLoading (1);
	}
	public void clickHighScore(){
		audioX.Play ();
		highScore.SetActive (true);
		mainButton.SetActive (false);
	}
	public void clickCredit(){
		audioX.Play ();
		mainCredit.SetActive (true);
		mainButton.SetActive (false);
	}
	public void clickSetting(){
		audioX.Play ();
		mainSetting.SetActive (true);
		mainButton.SetActive (false);
	}
	public void changeBGM(bool bgm){
		bool temp = bgmToggle.isOn;
		if (!temp) {
			PlayerPrefs.SetInt ("BGM", 0);
		} else {
			PlayerPrefs.SetInt ("BGM", 1);
		}
	}
	public void changeSFX(bool sfx){
		bool temp = sfxToggle.isOn;
		if (!temp) {
			PlayerPrefs.SetInt ("SFX", 0);
			audioX.mute = true;
		} else {
			PlayerPrefs.SetInt ("SFX", 1);
			audioX.mute = false;

		}
		audioX.Play ();

	}
	public void fullScreen(bool full){
		bool temp = fullscreen.isOn;
		if (!temp) {
			Screen.SetResolution (1024, 768, false);
		} else {
			Screen.SetResolution (1024, 768, true);
		}
	}
	public void changeSpeed(){
		PlayerPrefs.SetFloat ("Speed",(float) Math.Round( textSpeedSlider.GetComponent<Slider> ().value,1));

	}


	public void backHighScore(){
		audioX.Play ();
		highScore.SetActive (false);
		mainButton.SetActive (true);
	}

	public void backCredit(){
		audioX.Play ();
		mainCredit.SetActive (false);
		mainButton.SetActive (true);
	}
	public void backSetting(){
		audioX.Play ();
		mainSetting.SetActive (false);
		mainButton.SetActive (true);
	}
	public void clickOut(){
		audioX.Play ();
		//Debug.Log (123);
		Application.Quit ();
	}

	public void insertScore(){

		for (int i = 0; i < highUser.Length; i++) {
			highUserText [i].text = highUser [i];
			highScoresText [i].text = highScores[i].ToString();
		}
	}

	public void addSort(int a){
		int index = 0;
		int temp = 0;

		for (int i = highScores.Length; i > 0; i--) {
			if (a < highScores [i])
				break;
			index = i;
		}
		for (int i = index; i < highScores.Length; i++) {
			temp = highScores [i];

		}
	}

}


