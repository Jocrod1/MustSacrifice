using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moving : MonoBehaviour {

    private Rigidbody2D rb2d;

	void Start () {

        rb2d = GetComponent<Rigidbody2D>();

    }



		void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.tag == "Player")
		{
			rb2d.isKinematic=false;
		}

		if (other.gameObject.tag == "Bullet")
		{
			print("hola");
		}
	}

	void OnCollisionExit2D(Collision2D other)
	{
		if (other.gameObject.tag == "Player")
		{
			rb2d.isKinematic=true;
		}



	}
}
