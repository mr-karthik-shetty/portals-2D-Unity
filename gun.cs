using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gun : MonoBehaviour {
	public GameObject portal_blue;	//blue portal prefab	
	public GameObject portal_red;	//red portal prefab
	public LayerMask ToHit;
	private GameObject fire_point;	//point from which we fire the portal bal
	private string colour = "blue";	//initial state of portal ball
	// Use this for initialization
	void Awake () {
		fire_point = transform.Find ("FirePoint").gameObject;
	}
	
	// Update is called once per frame
	void Update () {
		
		if(Input.GetKeyDown(KeyCode.Mouse0))	//to shoot the portal ball
		{
			shoot ();
		}

		if (Input.GetKeyDown (KeyCode.E)) 	//to change the colour of portal balls
		{
			if (colour == "blue") {
				colour = "red";
			} else {
				colour = "blue";
			}
			print (colour);
		}
	}

	void shoot()//we use raycasting to shoot portall balls
	{
		
		Vector2 target = new Vector2 (Camera.main.ScreenToWorldPoint (Input.mousePosition).x, Camera.main.ScreenToWorldPoint (Input.mousePosition).y);
		Vector2 originp = new Vector2 (fire_point.transform.position.x, fire_point.transform.position.y);
		Debug.DrawLine (originp,(target-originp)*100);
		RaycastHit2D hit = Physics2D.Raycast (originp, target - originp, 100f, ToHit);
		if (hit.collider != null) {
			Debug.DrawLine (originp,hit.point, Color.red);
		}
		Vector2 direction = (target - originp).normalized;
		if (colour == "blue") {
			GameObject portal = Instantiate (portal_blue, fire_point.transform.position, Quaternion.identity) as GameObject;		
			portal.GetComponent<Rigidbody2D> ().AddForce (direction * 1500f);
		} else {
			GameObject portal = Instantiate (portal_red, fire_point.transform.position, Quaternion.identity) as GameObject;		
			portal.GetComponent<Rigidbody2D> ().AddForce (direction * 1500f);
		}
	}
}
