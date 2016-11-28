using UnityEngine;
using System.Collections;

public class StateManager : MonoBehaviour {

	public static int			state; 
	// 0=choosing, 1=mixing, 2=stocking

	public static bool			customerThere;

	public static StateManager	S;

	public void Awake () {
		state = 0;
	}

	// Update is called once per frame
	void Update () {
		customerThere = ControlScript.S.CustomerThere();

		switch(state){
		case 0:
			if(Input.GetKeyDown(KeyCode.W)) {
				if(customerThere){
					state = 1;
				} 
			} else if(Input.GetKeyDown(KeyCode.S)) state = 2;
			else state = 0;
			break;
		case 2:
			if(Input.GetKeyDown(KeyCode.W)) {
				state = 0;
			}
			break;
		default:
			break;
		}
	}
}
