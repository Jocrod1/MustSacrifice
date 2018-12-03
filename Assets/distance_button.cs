using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class distance_button : MonoBehaviour {

	private bool distance_activated= false;

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
		distance_activated=true;
		print(distance_activated);

		anim.SetTrigger("Disk");


		}

	}
}
