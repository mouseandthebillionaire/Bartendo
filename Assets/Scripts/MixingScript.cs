using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class MixingScript : MonoBehaviour {

	public TextAsset			comboList;
	public string[]				lines;
	public List<string>			combos;
	public string				currCombo;
	public static string[]		combo;

	public bool					mixing;

	private int 		currentPos = 0;
	private bool		mixed = false;

	// Use this for initialization
	void Start () {
		lines = comboList.text.Split ('\n');
	}

	void Update() {
		mixing = ControlScript.state;
		if(mixing){
			int thisCombo = OrderScript.drinkNum;
			combo = GetCombo(thisCombo);
			if(Input.anyKeyDown) Mix();
		}
	}

	public string[] GetCombo (int p){
		string currCombo = lines[p];
		string[] keys = new string[currCombo.Length];
		for(int i=0; i<currCombo.Length; i++){
			keys[i] = currCombo[i].ToString();
		}
		OrderScript.S.DisplayOrder(keys);
		return keys;
	}

	public void Mix(){
		if(Input.GetKeyDown(KeyCode.E)) Debug.Log("ding");
		else if(Input.GetKeyDown(combo[currentPos])){
			currentPos++;
			AudioScript.S.Mix();
			if((currentPos+1)>combo.Length){
				ControlScript.state = false;
				ControlScript.S.Served();
				GlassScript.S.DirtyGlass();
				currentPos = 0;
			}
		} else {
			currentPos = 0;
			ControlScript.state = false;
			AudioScript.S.Wrong();
		}
	}
		
}
	