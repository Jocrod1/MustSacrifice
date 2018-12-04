using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour {

    public GameObject player1, player2, player3;
    bool a, b, c;
    public GameObject Cam;

	// Use this for initialization
	void Start () {
        a = true;
        b = false;
        c = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.C)) {
            if (a) {
                a = false;
                b = true;
                c = false;
                Cam.transform.SetParent(player2.transform);
                player2.transform.position = transform.position;
                Cam.transform.position = player2.transform.position + Vector3.forward * -8.76f;
            }
            else if (b) {
                a = false;
                b = false;
                c = true;
                Cam.transform.SetParent(player3.transform);
                player3.transform.position = transform.position;
                Cam.transform.position = player3.transform.position + Vector3.forward * -8.76f;
            }
            else if (c) {
                a = true;
                b = false;
                c = false;
                Cam.transform.SetParent(player1.transform);
                player1.transform.position = transform.position;
                Cam.transform.position = player1.transform.position + Vector3.forward * -8.76f;
            }

        }
        player1.SetActive(a);
        player2.SetActive(b);
        player3.SetActive(c);
	}
}
