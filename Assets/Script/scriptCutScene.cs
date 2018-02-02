using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scriptCutScene : MonoBehaviour {
	public GameObject leftPortrait;
	public GameObject rightPortrait;
	public GameObject dialougeBox;
	public Text dialouge;
	public Text charaName;

	public string[] dialougeArray;
	public string[] charaArray;
	public Sprite[] sprites;
	public SceneManagerClassv2 sceneMan;
	public SoundManager soundMan;
	//private AudioSource audioX;
	// Use this for initialization
	private int currentLine;
	private bool lineIsMoving,dialougeEnd;
	private float textSpeed;
	void Start () {
		currentLine = 0;
		nextMessage ();
		dialougeEnd = false;
		soundMan.playBGM (0);
		textSpeed = PlayerPrefs.GetFloat ("Speed", 1f);
	}
	public void nextMessage(){



		if (!lineIsMoving && currentLine == dialougeArray.Length&&!dialougeEnd) {
			dialougeEnd = true;
			sceneMan.changeSceneWithLoadingPC (3);
		}else if(!lineIsMoving) {
			if (currentLine == 5 || currentLine == 9 || currentLine == 12 || currentLine == 15) {
				leftPortrait.GetComponent<Image> ().sprite = sprites [1];
			} else {
				leftPortrait.GetComponent<Image> ().sprite = sprites [0];
			}
			charaName.text = charaArray [currentLine];
			dialouge.text = "";
			string dialougeTemp=dialougeArray[currentLine];
			char[] dialougeChar = dialougeTemp.ToCharArray ();
			lineIsMoving = true;
			StartCoroutine (lineMove (dialougeChar));
			currentLine++;
		} else {
			string dialougeTemp=dialougeArray[currentLine-1];
			StopAllCoroutines ();
			dialouge.text = dialougeTemp;
			lineIsMoving = false;
		}

	}
	private IEnumerator lineMove(char[]charDial) {
		
		for (int i = 0; i < charDial.Length; i++) {
			yield return new WaitForSeconds(0.05f/textSpeed);
			soundMan.playSFX (3);
			dialouge.text += charDial [i];
		}
		lineIsMoving = false;
	}
}
