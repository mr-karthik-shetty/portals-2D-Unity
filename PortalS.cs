using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalS : MonoBehaviour {

	public GameObject Portal;
	private float theta;	//angle of the portal 
	public bool top;
	private float vx,vy,vxf,vyf;
	// Use this for initialization
	void Start ()
	{
		
	}
	
	// Update is called once per frame
	void Update () {
	}

	void OnCollisionEnter2D(Collision2D collider)
	{
		
		if (collider.gameObject.tag == "Player") {
			
			if (Portal.GetComponent<PortalS>().top== false)	//different math if portal is on top wall
			{
				theta = transform.eulerAngles.z - Portal.transform.eulerAngles.z;//euler angles is used to find rotation in degrees
				theta = theta * Mathf.Deg2Rad;	//convert degrees to radians
				Vector2 rel_velocity= collider.relativeVelocity;	//this will give the relative velocity of ball with respect to portal
				vx = rel_velocity.x;
				vy = rel_velocity.y;
				vxf = vx * Mathf.Cos (theta) + vy * Mathf.Sin (theta);		//linear angle transformation
				vyf = -vx * Mathf.Sin (theta) + vy * Mathf.Cos (theta);

				Vector2 final_velocity = new Vector2 (vxf, vyf);
				Vector2 unit_velocity = 3 * final_velocity.normalized;

				Vector3 final_pos = Portal.transform.TransformPoint (0f, -4f, 0f);	//we create new object away from player to prevent it from re-entering the portal
				collider.gameObject.transform.position = final_pos;
			}

			if (Portal.GetComponent<PortalS>().top == true) 
			{
				
				theta = transform.eulerAngles.z + Portal.transform.eulerAngles.z;
				theta = theta * Mathf.Deg2Rad;
				Vector2 rel_velocity= collider.relativeVelocity;
				vx = rel_velocity.x;
				vy = rel_velocity.y;
				vxf = vx * Mathf.Cos (theta) + vy * Mathf.Sin (theta);
				vyf = vx * Mathf.Sin (theta) - vy * Mathf.Cos (theta);

				Vector2 final_velocity = new Vector2 (vxf, vyf);
				Vector2 unit_velocity = 3 * final_velocity.normalized;

				Vector3 final_pos = Portal.transform.TransformPoint (0f, 4f, 0f);
				collider.gameObject.transform.position = final_pos;
			}
			collider.gameObject.GetComponent<Rigidbody2D> ().velocity = new Vector2 (vxf,vyf);
		}
	}
}
