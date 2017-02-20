using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public enum SFXType {DAMAGE,JUMP,ITEM,EXPLOSSION, DEAD, IDLE}
	
public class AudioManager : MonoBehaviour {

	public static AudioManager instance;
	public AudioSource musicAudioSource;
	private AudioSource sfxAudiosourse;
	public float timeToPlay;
	public float endMiusicSpeed;
	public AudioClip[] sfxCollection;
	private float playingTime;
	public AudioMixer gameAudioMixer;

	public Slider volumeSlider;
	public Slider sfxSlider;



	void Start () 
	{
		instance = this;
		sfxAudiosourse = GetComponent<AudioSource>();
		playingTime = timeToPlay;
		InvokeRepeating ("TimeCount",0,1f);
	}

	void Update()
	{
//		if (Input.GetKeyDown (KeyCode.M)) 
//		{
//			gameAudioMixer.SetFloat ("musicVolume", volumeSlider.value);//
//		}	
//
//		if (Input.GetKeyDown (KeyCode.S)) 
//		{			
//			gameAudioMixer.SetFloat ("sfxVolume", -80f,volumeSlider.va);//
//		}	

		gameAudioMixer.SetFloat ("musicVolume", volumeSlider.value);
		gameAudioMixer.SetFloat ("sfxVolume",sfxSlider.value);

	}

	public void PlaySFX(SFXType sfxType)
	{
		switch (sfxType) 
		{
			case SFXType.DAMAGE:
				sfxAudiosourse.PlayOneShot(sfxCollection[0]);
				break;
			case SFXType.JUMP:
				sfxAudiosourse.PlayOneShot(sfxCollection[1]);
				break;
			case SFXType.ITEM:
				sfxAudiosourse.PlayOneShot(sfxCollection[2]);
				break;
			case SFXType.EXPLOSSION:
				sfxAudiosourse.PlayOneShot(sfxCollection[3]);
				break;
			case SFXType.DEAD:
				sfxAudiosourse.PlayOneShot(sfxCollection[4]);
				break;
			case SFXType.IDLE:
				sfxAudiosourse.PlayOneShot(sfxCollection[5]);
				break;			
		}
	}

	public void EnableMusic(bool isEnable)
	{
	}

	public void EnablesFx(bool isEnable)
	{
	}

	public void TimeCount()
	{	
		playingTime--;
		if(playingTime <= 10f)
		{
			musicAudioSource.pitch = endMiusicSpeed;

		}
	}
}
