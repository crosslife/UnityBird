using UnityEngine;
using System.Collections;

public class FadeMgr : MonoBehaviour {

    SpriteRenderer renderer ;
	// Use this for initialization
	void Start () {
        //gameObject.renderer.enabled = false;
        renderer = gameObject.GetComponent<SpriteRenderer>();
        Color nowColor = renderer.color;
        renderer.color =  new Color(nowColor.r, nowColor.g, nowColor.b, 0);
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Fire1"))
        {
            Color nowColor = renderer.color;
            renderer.color = new Color(nowColor.r, nowColor.g, nowColor.b, 0.5f);
        }
	}
}
