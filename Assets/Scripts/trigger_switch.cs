using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trigger_switch : MonoBehaviour {

	private bool activated_switch=false;
	private bool enter_trigger=false;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == "Player")
		{
				enter_trigger=true;
		}
	}

	void OnTriggerExit2D(Collider2D other)
	{
		if (other.gameObject.tag == "Player")
		{
				enter_trigger=false;
		}
	}


	void Update () {

			if(Input.GetKeyDown(KeyCode.E) && enter_trigger==true)
			{
				activated_switch=!activated_switch;
				print(activated_switch);
			}


	}
}
