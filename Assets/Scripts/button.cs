using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class button : Activable {

	private Animator anim;

    public bool IsForever;

	void Start()
	{
		anim = GetComponent<Animator>();
	}



	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == "Player")
		{
		Active=true;

        anim.SetBool("Press", true);


        print(Active);
		}

	}

	void OnTriggerExit2D(Collider2D other)
	{
		if (other.gameObject.tag == "Player" && !IsForever)
		{
            Active = false;

		anim.SetBool("Press", false);

        print(Active);
		}
	}
}

