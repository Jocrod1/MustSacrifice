using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class button : MonoBehaviour {

	private bool activated=false;
	private Animator anim;

	void Start()
	{
		anim = GetComponent<Animator>();
	}



	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == "Player")
		{
		activated=true;

        anim.SetBool("Press", true);


		print(activated);
		}

	}

	void OnTriggerExit2D(Collider2D other)
	{
		if (other.gameObject.tag == "Player")
		{
		activated=false;

		anim.SetBool("Press", false);

		print(activated);
		}
	}
}

