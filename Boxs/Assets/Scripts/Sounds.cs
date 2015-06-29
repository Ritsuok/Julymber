using UnityEngine;
using System.Collections;

public class Sounds : MonoBehaviour {

	public AudioClip cursor;
	static AudioSource cursorAudio;

	public AudioClip decision;
	static AudioSource decisionAudio;

	public AudioClip bomb;
	static AudioSource bombAudio;

	public AudioClip select;
	static AudioSource selectAudio;

	public AudioClip cancel;
	static AudioSource cancelAudio;
	
	public AudioClip error;
	static AudioSource errorAudio;
	
	
	// Use this for initialization
	void Start ()
	{
		//cursor
		cursorAudio = gameObject.AddComponent<AudioSource> ();
		cursorAudio.clip = cursor;
		cursorAudio.loop = false;
		cursorAudio.volume = 1F;
		
		//dicision
		decisionAudio = gameObject.AddComponent<AudioSource> ();
		decisionAudio.clip = decision;
		decisionAudio.loop = false;
		decisionAudio.volume = 1F;
		
		//bomb
		bombAudio = gameObject.AddComponent<AudioSource> ();
		bombAudio.clip = bomb;
		bombAudio.loop = false;
		bombAudio.volume = 1F;
		
		//select
		selectAudio = gameObject.AddComponent<AudioSource> ();
		selectAudio.clip = select;
		selectAudio.loop = false;
		selectAudio.volume = 1F;
		
		//cancel
		cancelAudio = gameObject.AddComponent<AudioSource> ();
		cancelAudio.clip = cancel;
		cancelAudio.loop = false;
		cancelAudio.volume = 1F;
		
		//error
		errorAudio = gameObject.AddComponent<AudioSource> ();
		errorAudio.clip = error;
		errorAudio.loop = false;
		errorAudio.volume = 1F;
	}

	
	public static void SEcursor() { cursorAudio.Play (); }
	public static void SEdecision() { decisionAudio.Play (); }
	public static void SEbomb() { bombAudio.Play (); }
	public static void SEselect() { selectAudio.Play (); }
	public static void SEcancel() { cancelAudio.Play (); }
	public static void SEerror() { errorAudio.Play (); }
}
