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
	public SoundManager soundman;
	//Objects for highscore
	public GameObject highScore;
	public Text[] highUserText;
	public Text[] highScoresText;
	public int[] highScores;
	public string[] highUser;
	//private AudioSource audioX;
	//public Text[] SortUser;
	// Use this for initialization
	void Awake(){
		Screen.SetResolution (1028, 769, true);
	}
	void Start () {
		highUser = PlayerPrefsX.GetStringArray ("userArray", "Anonim", 15);
		highScores = PlayerPrefsX.GetIntArray ("scoreArray",0,15);
		insertScore ();
		setupSetting ();
	}
	private void setupSetting(){
		if (PlayerPrefs.GetInt ("SFX",1) == 0) {
			sfxToggle.isOn = false;
		} else {
			sfxToggle.isOn = true;
		}
		if (PlayerPrefs.GetInt ("BGM",1) == 0) {
			bgmToggle.isOn = false;
		} else {
			bgmToggle.isOn = true;
		}

		textSpeedSlider.GetComponent<Slider> ().value = PlayerPrefs.GetFloat ("Speed", 1f);
	}

	// Update is called once per frame
	void Update () {
		//private void startGame(){
		//	gameObject.
	}
	public void clickStart(){
		soundman.playSFX (0);
		sceneman.changeSceneNoLoading (1);
	}
	public void clickHighScore(){
		soundman.playSFX (0);
		highScore.SetActive (true);
		mainButton.SetActive (false);
	}
	public void clickCredit(){
		soundman.playSFX (0);
		mainCredit.SetActive (true);
		mainButton.SetActive (false);
	}
	public void clickSetting(){
		soundman.playSFX (0);
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
		soundman.setupPrefs ();
	}
	public void changeSFX(bool sfx){
		bool temp = sfxToggle.isOn;
		if (!temp) {
			PlayerPrefs.SetInt ("SFX", 0);
		} else {
			PlayerPrefs.SetInt ("SFX", 1);

		}
		soundman.setupPrefs ();
		soundman.playSFX (0);
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
		soundman.playSFX (0);
		highScore.SetActive (false);
		mainButton.SetActive (true);
	}

	public void backCredit(){
		soundman.playSFX (0);
		mainCredit.SetActive (false);
		mainButton.SetActive (true);
	}
	public void backSetting(){
		soundman.playSFX (0);
		mainSetting.SetActive (false);
		mainButton.SetActive (true);
	}
	public void clickOut(){
		//Debug.Log (123);
		soundman.playSFX (0);
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


