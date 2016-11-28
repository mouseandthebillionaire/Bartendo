using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class OrderScript : MonoBehaviour {

	public static			OrderScript S;
	public TextAsset		drinkList;
	public string[]			drinks;
	public TextAsset		orderList;
	public string[]			orders;

	public GameObject[]		arrows;
	public GameObject		bg;

	public static int		drinkNum;
	private string[]		drinkCombo;
	public	string			drinkComboString;
	public Text				drink;
	public Text				combo;

	// Use this for initialization
	void Awake () {
		S = this;
		bg.SetActive(false);
		drinks = drinkList.text.Split('\n');
		orders = orderList.text.Split('\n');
		drinkNum = 0;
		drink.text = "";
		combo.text = "";
	}

	public void Order(int c){
		bg.SetActive(true);
		//arrows[c].SetActive(true);
		drinkNum = Random.Range(0, drinks.Length);
	}

	public void DisplayOrder(string[] drinkCombo){
		if(!GlassScript.noGlasses){
			for(int i=0; i<drinkCombo.Length; i++){
				drinkComboString = drinkComboString + drinkCombo[i].ToUpper() + " ";
			}
			int orderNum = Random.Range(0, orders.Length);
			string orderTemp = orders[orderNum];
			drink.text = orderTemp.Replace("XXX", drinks[drinkNum]);
			//drink.text = "Hey bub, can I get a " + drinks[drinkNum] + "?";
			combo.text = drinkComboString.ToUpper();
			drinkComboString = "";
		} else {
			drink.text = "Clean Some Glasses!\n(Press Down)";
		}
	}
		
	public void Reset(){
		bg.SetActive(false);
		//int c = ControlScript.customer;
		//arrows[c].SetActive(false);
		drink.text = "";
		drinkComboString = "";
		combo.text = "";

	}
}
