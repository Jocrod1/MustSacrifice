using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warp : MonoBehaviour {

    public GameObject Target;

    bool start = false;
    bool isfadein = false;
    float alpha = 0;
    public float fadetime = 1f;

    public FollowTarget t;

    float vel;
    void Awake() {
        GetComponent<SpriteRenderer>().enabled = false;
        transform.GetChild(0).GetComponent<SpriteRenderer>().enabled = false;
        t = Camera.main.GetComponent<FollowTarget>();
    }

    IEnumerator OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Player" || other.gameObject.tag == "2Player" || other.gameObject.tag == "3Player")
        {
            FadeIn();


            yield return new WaitForSeconds(fadetime);

            other.transform.position = Target.transform.GetChild(0).transform.position;

            t.Isfade = true;
            
            FadeOut();
        }
    }

    void OnGUI() {
        if (!start)
            return;
        GUI.color = new Color(GUI.color.r, GUI.color.g, GUI.color.b, alpha);

        Texture2D tex;

        tex = new Texture2D(1, 1);
        tex.SetPixel(0, 0, Color.black);
        tex.Apply();

        GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), tex);

        if (isfadein)
        {
            alpha = Mathf.SmoothDamp(alpha, 1.1f, ref vel, fadetime);
        }
        else {
            alpha = Mathf.SmoothDamp(alpha, -0.1f, ref vel, fadetime);
            if (alpha < 0) start = false;
        }
    }

    void FadeIn() {
        start = true;
        isfadein = true;
    }
    void FadeOut() {
        isfadein = false;
    }   
}
