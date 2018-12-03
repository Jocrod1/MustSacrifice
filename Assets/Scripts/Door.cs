using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour {

    public bool Open = true;

    public bool NeedPuzzle;
    public List<Activable> BoolsToOpen;

    public List<bool> Bools { get; private set; }

    Animator Anim;
    BoxCollider2D ClosedCollider;
    GameObject A;


	// Use this for initialization
	void Start () {
        Anim = GetComponent<Animator>();
        A = transform.GetChild(0).gameObject;

	}
	
	// Update is called once per frame
	void Update () {
        if (NeedPuzzle) {
            bool isOpen = true;
            for (int i = 0; i < BoolsToOpen.Count; i++)
            {
                isOpen = isOpen && BoolsToOpen[i].Active;
            }
            Open = isOpen;
        }
        A.SetActive(!Open);
        Anim.SetBool("Open", Open);
	}
}
