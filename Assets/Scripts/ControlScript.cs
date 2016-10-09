using UnityEngine;
using System.Collections;

public class ControlScript : MonoBehaviour {

	public static bool			state; // false=choosing, true=mixing
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
		state = false;
		stocking = false;
		annoyanceSpeed = 100f;
	
	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log(customer);

		t = Time.time - startTime;

		if(t > customerFreq){
			for(int i=0; i < customers.Length; i++){
				customers[i].GetComponent<CustomerScript>().SaddleUp();
			}
			if(customerFreq > 1) customerFreq -= 0.5f;
			else customerFreq = 1;
			startTime = Time.time;
		}

		if(!stocking){
			if(Input.GetKeyDown(KeyCode.E)) {
				if(customers[customer].active){
					state = !state;
					Debug.Log("State: "+state);
					OrderScript.S.Order(customer);
				} 
			}
		} else {
			if(Input.GetKeyDown(KeyCode.L)) {
				GlassScript.S.Clean();
			}
		}

		if(!state) {
			Choose();
			OrderScript.S.Reset();
			if(Input.GetKeyDown(KeyCode.S)) stocking = !stocking;
			if(stocking && Input.GetKeyDown(KeyCode.W)) stocking = !stocking;
		}


		Debug.Log("Stocking: "+stocking);


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

	public void Served(){
		customers[customer].GetComponent<CustomerScript>().Served();
		AudioScript.S.Served();
		if(annoyanceSpeed >= 5) annoyanceSpeed -= 5;
		else annoyanceSpeed = 5;
	}



}
