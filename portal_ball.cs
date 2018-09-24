using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class portal_ball : MonoBehaviour {
	private GameObject portal;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnTriggerEnter2D(Collider2D collider)
	{
		if (collider.gameObject.tag == "floor") {
			Vector3 final_pos = transform.position;
			if (this.tag == "blue_goo") {
				print ("sss");
				portal = GameObject.Find ("BluePortal");
			}
			if (this.tag == "orange_goo") {
				portal = GameObject.Find ("OrangePortal");
			}
			if (portal) {
				portal.transform.position = final_pos;
				portal.transform.rotation = collider.gameObject.transform.rotation;	//we give the portal the orientation of the wall
			}
			PortalS portal_script = portal.GetComponent<PortalS> ();
			if (collider.gameObject.name == "top") {
				portal_script.top = true;
			}
			if (collider.gameObject.name == "bottom") {
				portal_script.top = false;
			}
			Destroy (gameObject);
		}

	}
}
