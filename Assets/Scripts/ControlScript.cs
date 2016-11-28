using UnityEngine;
using System.Collections;

public class ControlScript : MonoBehaviour {

	public static bool			stocking;

	public static int			customer;
	public static float			cChance;

	public GameObject			selector;
	public GameObject[]			customers;
	public float[]				sX;

	public float 				t;
	private float				startTime;
	private float				customerFreq;
	public static float			annoyanceSpeed;

	public static int			customersFailed;

	public static ControlScript	S;


	// Use this for initialization
	void Awake () {
		S = this;
		customer = 0;
		customersFailed = 0;
		customerFreq = 10f;
		cChance = 0.25f;
		stocking = false;
		annoyanceSpeed = 100f;
	
	}
	
	// Update is called once per frame
	void Update () {
		int state = StateManager.state;

		t = Time.time - startTime;

		if(t > customerFreq){
			for(int i=0; i < customers.Length; i++){
				customers[i].GetComponent<CustomerScript>().SaddleUp();
			}
			if(customerFreq > 1) customerFreq -= 0.5f;
			else customerFreq = 1;
			startTime = Time.time;
		}

		if(state == 0){
			Choose();
			OrderScript.S.Reset();
		}

		if(state == 1){
			OrderScript.S.Order(customer);
		} 
		
		if(state == 2){
			GlassScript.S.Clean();
		}


		selector.transform.position = new Vector3(
			sX[customer], 
			selector.transform.position.y, 
			selector.transform.position.z);
	}

	void Choose() {
		
		if ( Input.GetKeyDown(KeyCode.D) ){
			if (customer < 3) {
				customer++;
				AudioScript.S.Select();
			} else customer = 3;
		}
		if (Input.GetKeyDown(KeyCode.A) ){
			if (customer > 0) {
				customer--;
				AudioScript.S.Select();
			} else customer = 0;
		}
	}

	public bool CustomerThere(){
		if(customers[customer].active){
			return true;
		} else {
			return false;
		}
	}
			
			
		

	public void Served(){
		customers[customer].GetComponent<CustomerScript>().Served();
		AudioScript.S.Served();
		if(annoyanceSpeed >= 5) annoyanceSpeed -= 5;
		else annoyanceSpeed = 5;
	}



}
