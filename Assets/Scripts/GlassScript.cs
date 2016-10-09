using UnityEngine;
using System.Collections;

public class GlassScript : MonoBehaviour {

	public GameObject[]				glasses;
	public int						gNum;
	public static GlassScript		S;
	public static bool				noGlasses;

	// Use this for initialization
	void Start () {
		S = this;
		Clean();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void DirtyGlass (){
		if(gNum < glasses.Length-1) {
			glasses[gNum].SetActive(true);
		 	gNum+=1;
		} else {
			noGlasses = true;
		}
	
	}

	public void Clean(){
		for(int i=0; i<glasses.Length; i++){
			glasses[i].SetActive(false);
		}
		gNum = 0;
		noGlasses = false;
	}
}
