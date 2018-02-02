using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class SoundManager : MonoBehaviour {
	private AudioSource BGM;
	private AudioSource SFX;

	public AudioClip[] bgmList;
	public AudioClip[] sfxClip;
	// Use this for initialization
	void Awake(){
		AudioSource[]temp = this.GetComponents<AudioSource>();
		BGM = temp[0];
		SFX = temp[1];
	}
	void Start () {
		
		setupPrefs ();
		//BGM.Play ();
		//gameOver ();
		//fadeBGM (0, 10f);
	}
	public void setupPrefs(){
		if (PlayerPrefs.GetInt ("SFX") == 0) {
			SFX.mute = true;
		} else {
			SFX.mute = false;
		}
		if (PlayerPrefs.GetInt ("BGM") == 0) {
			BGM.mute = true;
		} else {
			BGM.mute = false;
		}
	}

	/// <summary>
	/// Plays SFX file
	/// </summary>
	/// <param name="clip">Index from sfxClip</param>
	public void playSFX(int clip){
		SFX.clip = sfxClip [clip];
		SFX.Play ();
	}
	public void playBGM(int bgm){
		BGM.clip = bgmList [bgm];
		BGM.Play ();
	}
	public void playBGM(int bgm,ulong delay){
		BGM.clip = bgmList [bgm];
		BGM.Play(delay);
		BGM.Play ();
	}
	public void stopBGM(){
		BGM.Stop ();
	}
	public void muteBGM(bool mute){
		BGM.mute = mute;
	}
	public void muteSFX(bool mute){
		SFX.mute = mute;
	}
	public void fadeBGM(float endVolume,float duration){
		StartCoroutine(fadeBGMIE(endVolume,duration));

	}
	IEnumerator fadeBGMIE(float endVolume,float duration){
		float startVolume = BGM.volume;
		float range = endVolume - startVolume;
		float currentVolume;
		float time=0;
		while (time < duration) {
			time += Time.deltaTime;
			currentVolume = range * time / duration;
			BGM.volume = startVolume+currentVolume;
			yield return new WaitForSeconds (Time.deltaTime);
		}
	}
	public void gameOver(){
		StartCoroutine (gameOverIE());
	}
	IEnumerator gameOverIE(){
		float startVolume = BGM.volume;
		float startPitch = BGM.pitch;
		float range = 0 - startVolume;
		float currentVolume;
		float currentPitch;
		float time=0;
		while (time < 2f) {
			time += Time.deltaTime;
			currentVolume = range * time / 2f;
			currentPitch = currentVolume;
			BGM.volume = startVolume+currentVolume;
			BGM.pitch = startPitch + currentPitch;
			yield return new WaitForSeconds (Time.deltaTime);
		}
	}
}	
