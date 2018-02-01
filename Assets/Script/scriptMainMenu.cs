using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScriptMainMenu : MonoBehaviour {
	public GameObject highScore;
	public GameObject mainButton;
	public GameObject mainCredit;
	public SceneManagerClassv2 sceneman;
	//public Text[];
	//public int []HighScore;
	public Text[] highUserText;
	public Text[] highScoresText;
	public int[] highScores;
	public string[] highUser;
	//public Text[] SortUser;
	// Use this for initialization
	void Start () {
		highUser = PlayerPrefsX.GetStringArray ("userArray", "Anonim", 15);
		highScores = PlayerPrefsX.GetIntArray ("scoreArray",0,15);
		insertScore ();
	}
	
	// Update is called once per frame
	void Update () {
		//private void startGame(){
		//	gameObject.
	}
	public void clickStart(){
		sceneman.changeSceneNoLoading (1);
	}
	public void clickSetting(){
		highScore.SetActive (true);
		mainButton.SetActive (false);
	}
	public void clickCredit(){
		mainCredit.SetActive (true);
		mainButton.SetActive (false);
	}

	public void clickMain(){
		highScore.SetActive (false);
		mainButton.SetActive (true);
	}

	public void clickMain2(){
		mainCredit.SetActive (false);
		mainButton.SetActive (true);
	}

	public void clickOut(){
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


