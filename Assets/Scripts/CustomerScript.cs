using UnityEngine;
using System.Collections;

public class CustomerScript : MonoBehaviour {

	public int				cNum;
	public Color[]			sColor;
		
	private float			chance;
	private bool			order;

	public float			annoyance;
	public GameObject		annoyanceBar;
	public float			alphaAnnoyance;
		
	private int				level;

	public CustomerScript	S;


	// Use this for initialization
	void Start () {
		S = this;
		this.GetComponent<SpriteRenderer>().color = sColor[1];
		chance = ControlScript.cChance;
		level = 0;
		alphaAnnoyance = 0;

		// make sure last customer is visible on game start
		if(cNum == 3) gameObject.active = true;
		else gameObject.active = false;
	}
	
	// Update is called once per frame
	void Update () {
		int c = ControlScript.customer;
		chance = ControlScript.cChance;
		int state = StateManager.state;

		if(gameObject.active ){
			annoyance = (Time.time - alphaAnnoyance) / ControlScript.annoyanceSpeed;
			if(annoyance > 0.8f) {
				gameObject.active = false;
				if(c == cNum) StateManager.state = 0;
				ControlScript.customersFailed++;
				alphaAnnoyance = Time.time;
			}
		}

		annoyanceBar.transform.localScale = new Vector3(.05f, annoyance, 1f);

		if(c == cNum){
			if(state == 1){
				this.GetComponent<SpriteRenderer>().color = sColor[0];
			} else {
				this.GetComponent<SpriteRenderer>().color = sColor[1];
			}
		}
	}

	public void SaddleUp(){
		if(gameObject.active == false){
			float f = Random.value;
			if(f < chance){
				alphaAnnoyance = Time.time;
				gameObject.active = true;
			}
		}
		this.GetComponent<SpriteRenderer>().color = sColor[1];
	}

	public void Served(){
		alphaAnnoyance = Time.time;
		float f = Random.value;
		if(f < chance){
			gameObject.active = false;
		}
	}

}
