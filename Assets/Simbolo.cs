using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Simbolo : Activable {

    public player Player;

    Animator Anim;

    public Text Inform;

    void Start()
    {
        Anim = GetComponent<Animator>();
    }



    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player" || other.gameObject.tag == "2Player" || other.gameObject.tag == "3Player" || other.gameObject.tag == "Block")
        {
            Active = true;
            Player = other.GetComponent<player>();
            Anim.SetBool("Press", true);

            Inform.text = "Press X to Sacrifice";

            print(Active);
        }

    }

    void OnTriggerExit2D(Collider2D other)
    {
        if ((other.gameObject.tag == "Player" || other.gameObject.tag == "2Player" || other.gameObject.tag == "3Player" || other.gameObject.tag == "Block"))
        {
            Active = false;
            Player = null;

            Anim.SetBool("Press", false);
            print(Active);
        }
    }
}
