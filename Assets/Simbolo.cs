using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Simbolo : Activable {


    void Start()
    {

    }



    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player" || other.gameObject.tag == "2Player" || other.gameObject.tag == "3Player" || other.gameObject.tag == "Block")
        {
            Active = true;


            print(Active);
        }

    }

    void OnTriggerExit2D(Collider2D other)
    {
        if ((other.gameObject.tag == "Player" || other.gameObject.tag == "2Player" || other.gameObject.tag == "3Player" || other.gameObject.tag == "Block"))
        {
            Active = false;


            print(Active);
        }
    }
}
