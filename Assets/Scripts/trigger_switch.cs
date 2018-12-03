using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trigger_switch : MonoBehaviour {

	private bool activated_switch=false;
	private bool enter_trigger=false;

	private Animator anim;

	void Start()
	{
		anim = GetComponentInParent<Animator>();
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
				if (activated_switch==true)
				{
					activated_switch=false;
					anim.SetBool("On", false);
				}
				else if (activated_switch==false)
				{
					activated_switch=true;
					anim.SetBool("On",true);
				}
				print(activated_switch);
			}


	}
}
