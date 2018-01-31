using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class scriptMainGame : MonoBehaviour {
	//UI in canvas
	public Text code;
	public Text answerField;
	public Text time;
	public Text score;
	public Image bookSprite;
	public Sprite cover;
	public Sprite bookInside;
	public SceneManagerClassv2 sceneMan;
	public GameObject[] ciperPage;
	public GameObject endMenu;
	public Text lastScore;
	public InputField nameInput;
	//public Sprite[] scoreRadioSprites;
	//public Sprite[] codeRadioSprites;
	public AudioClip[] soundClip;
	public GameObject sfxSource;
	private AudioSource[] audioSource;//0 bgm, 1 sfx
	private List<string> codeList;//List soal
	private string currentCode;//Soal saat ini
	private int round=0;
	private bool gameIsRunning;//true= game jalan, false (baru mau mulai atau gameover)

	public string[] codeArray;
	public int roundTime;
	private int currentScore;
	private float timeLeft;
	private int bookPage;
	public GameObject scoreRadio, codeRadio;

	private string[] userArray;
	private int[] scoreArray;
	// Use this for initialization
	void Start () {
		userArray = PlayerPrefsX.GetStringArray ("userArray", "Anonim", 15);
		scoreArray = PlayerPrefsX.GetIntArray ("scoreArray",0,15);
		//codeRadio.GetComponent<Animator> ().SetBool ("newCode", false);
		audioSource=new AudioSource[2];
		audioSource [0] = GetComponent<AudioSource> ();
		audioSource [1] = sfxSource.GetComponent<AudioSource> ();
		codeList=new List<string>();
		generateCode ();
		StartCoroutine(instantiateCode (0));
		timeLeft = roundTime;
		gameIsRunning = true;
		turnPage (-99);
		gameIsRunning = true;
	}
	
	// Update is called once per frame
	void Update () {
		if (gameIsRunning) {
			//Debug.Log ("Aye");
			if (Input.GetKeyDown (KeyCode.Return)) {
				Debug.Log ("Enter");
				checkAnswer ();
			} else if (Input.GetKeyDown (KeyCode.Backspace)) {
			
				string temp = answerField.text;
				string temp2 = temp.Substring (0, temp.Length - 1);
				Debug.Log (temp2);
				answerField.text = temp2;
			} else if (Input.anyKeyDown) {
				playSFX (2);
				Debug.Log (Input.inputString);
				string temp = Input.inputString.ToUpper ();
				answerField.text += temp;
			}

			//fungsi waktu
			if (timeLeft > 0) {
				timeLeft -= Time.deltaTime;
				time.text = ((int)timeLeft).ToString ();
			} else {
				StartCoroutine(gameOver ());
			}
			if (timeLeft < 30) {
				scoreRadio.GetComponent<Animator> ().SetBool ("last30", true);
			}

			if (Input.GetKeyDown (KeyCode.LeftArrow)) {
				turnPage (-1);
			} else if (Input.GetKeyDown (KeyCode.RightArrow)) {
				turnPage (1);
			}
		}
	}
	public void turnPage(int turn){
		playSFX (0);
		resetBookSprite ();
		bookPage += turn;
		Debug.Log (bookPage);
		if (bookPage < 0) {
			bookPage = 0;
		} else if (bookPage > ciperPage.Length) {
			bookPage = ciperPage.Length;
		}

		if (bookPage == 0) {
			bookSprite.sprite = cover;
		} else {
			bookSprite.sprite = bookInside;
			ciperPage [bookPage - 1].SetActive (true);
		}
	}
	private void resetBookSprite(){
		for (int i = 0; i < ciperPage.Length; i++) {
			ciperPage [i].SetActive (false);
		}
	}
	private void generateCode(){
		//Pindahin code dari array ke list dan sudah di random
		List<string>temp=new List<string>();
		for (int i = 0; i < codeArray.Length; i++) {
			temp.Add (codeArray [i].ToUpper());
		}

		//randomize to add in codeList
		int random=0;
		while (temp.Count > 0) {
			random = Random.Range(0,temp.Count);
			codeList.Add (temp [random]);
			Debug.Log (codeList [codeList.Count - 1]);
			temp.RemoveAt (random);

		}
		
	}
	private string cyper(string source){
		string upper = source.ToUpper ();
		string answer = "";
		char[] arrayChar = upper.ToCharArray ();
		for (int i = 0; i < arrayChar.Length; i++) {
			switch (arrayChar [i]) {
			case 'A':
				arrayChar [i] = 'Q';
				break;
			case 'B':
				arrayChar [i] = 'W';
				break;
			case 'C':
				arrayChar [i] = 'E';
				break;
			case 'D':
				arrayChar [i] = 'R';
				break;
			case 'E':
				arrayChar [i] = 'T';
				break;
			case 'F':
				arrayChar [i] = 'Z';
				break;
			case 'G':
				arrayChar [i] = 'U';
				break;
			case 'H':
				arrayChar [i] = 'I';
				break;
			case 'I':
				arrayChar [i] = 'O';
				break;
			case 'J':
				arrayChar [i] = 'P';
				break;
			case 'K':
				arrayChar [i] = 'A';
				break;
			case 'L':
				arrayChar [i] = 'S';
				break;
			case 'M':
				arrayChar [i] = 'D';
				break;
			case 'N':
				arrayChar [i] = 'F';
				break;
			case 'O':
				arrayChar [i] = 'G';
				break;
			case 'P':
				arrayChar [i] = 'H';
				break;
			case 'Q':
				arrayChar [i] = 'J';
				break;
			case 'R':
				arrayChar [i] = 'K';
				break;
			case 'S':
				arrayChar [i] = 'L';
				break;
			case 'T':
				arrayChar [i] = 'Y';
				break;
			case 'U':
				arrayChar [i] = 'X';
				break;
			case 'V':
				arrayChar [i] = 'C';
				break;
			case 'W':
				arrayChar [i] = 'V';
				break;
			case 'X':
				arrayChar [i] = 'B';
				break;
			case 'Y':
				arrayChar [i] = 'N';
				break;
			case 'Z':
				arrayChar [i] = 'M';
				break;
			
			}
			answer += arrayChar [i];
		}
		return answer;
		
	}
	private bool checkAnswer(){
		Debug.Log (answerField.text==currentCode);

		if (answerField.text == currentCode) {
			playSFX (3);
			addScore (100);
			addTime (5f);
			StartCoroutine(instantiateCode (round));
		} else {
			StartCoroutine(gameOver ());
		}
		return answerField.text==currentCode;
	}
	private IEnumerator instantiateCode(int round){
		int nextRound = round;
		if (nextRound >= 20) {
			this.round = 0;
			nextRound = 0;
		}
		yield return null;
		code.text = "";
		codeRadio.GetComponent<Animator> ().SetBool ("newCode", true);
		yield return new WaitForSeconds (0.5f);
		codeRadio.GetComponent<Animator> ().SetBool ("newCode", false);
		answerField.text = "";
		code.text = cyper (codeList [nextRound]);
		currentCode = codeList [nextRound];
		this.round++;
		//Debug.Log (round.ToString ());

	}
	private void playSFX(int index){
		audioSource [1].clip = soundClip [index];
		audioSource [1].Play();
	}
	private void addScore(int addPoint){
		currentScore += addPoint;
		score.text = currentScore.ToString();
	}
	private void addTime(float addTime){
		timeLeft += addTime;
	}
	private IEnumerator gameOver(){
		audioSource [0].Stop ();
		timeLeft = 0;
		gameIsRunning = false;
		yield return new WaitForSeconds (0.5f);
		sceneMan.fadeToBlack ();
		yield return new WaitForSeconds (0.5f);
		playSFX (4);
		yield return new WaitForSeconds (3.0f);
		endMenu.SetActive (true);
		lastScore.text = currentScore.ToString ();
		//sceneMan.changeSceneNoLoading (0);
	}
	private void addSort(){
		int index = 0;
		int temp = 0;
		int temp2 = currentScore;
		string tempS1 = "";
		string tempS2 = nameInput.text;
		for (int i = userArray.Length-1; i >= 0; i--) {
			if (temp2 < scoreArray [i]) {
				break;
			}
			index = i;
		}
		for (int i = index; i < userArray.Length; i++) {
			temp = scoreArray [i];
			tempS1 = userArray [i];
			scoreArray [i] = temp2;
			userArray [i] = tempS2;
			temp2 = temp;
			tempS2 = tempS1;
		}
		PlayerPrefsX.SetStringArray ("userArray", userArray);
		PlayerPrefsX.SetIntArray ("scoreArray", scoreArray);

	}
	public void endGame(bool b){
		addSort ();
		playSFX (5);
		if (b) {//if true, restart
			sceneMan.changeSceneNoLoading(3);
		} else {//if false, back to main menu
			sceneMan.changeSceneNoLoading(0);
		}
	}

}
