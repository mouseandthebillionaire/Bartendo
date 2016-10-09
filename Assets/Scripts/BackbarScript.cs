using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BackbarScript : MonoBehaviour {

	public Text				directions;
	public GameObject		bg;

	// Use this for initialization
	void Awake () {
		directions.text = "";
		bg.SetActive(false);
	
	}
	
	// Update is called once per frame
	void Update () {
		bool b = ControlScript.stocking;
		Debug.Log(b);
		if(b){
			bg.SetActive(true);
			directions.text ="Press L\nto Wash";
		} else {
			bg.SetActive(false);
			directions.text ="";
		}
			
	
	}

	public void Display() {
	}
		
}
