using UnityEngine;
using System.Collections;

public class AudioScript : MonoBehaviour {

	public AudioSource				bg;
	public AudioSource 				dinger;

	public AudioClip				wrong;
	public AudioClip				right;
	public AudioClip				mixStep;
	public AudioClip				select;

	public static AudioScript 		S;

	void Awake(){
		S = this;
	}
	
	public void Select(){
		dinger.PlayOneShot(select);
	}

	public void Mix(){
		dinger.PlayOneShot(mixStep);
	}

	public void Wrong(){
		dinger.PlayOneShot(wrong);
	}

	public void Served(){
		dinger.PlayOneShot(right);
	}
}
