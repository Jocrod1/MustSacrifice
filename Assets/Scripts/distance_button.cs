using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class distance_button : Activable {

	private Animator anim;

	void Start()
	{
		anim = GetComponentInParent<Animator>();
	}


	// Use this for initialization
	void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.tag == "Bullet")
		{
            Active = true;
            print(Active);

		anim.SetTrigger("Disk");


		}

	}
}
