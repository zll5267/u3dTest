using UnityEngine;
using System.Collections;

public class LaunchCannon : MonoBehaviour {

	public float canonBallSpeed = 0.005f;
	// spped of our cannon ball
	public float rateOfFire = 5.5f;
	// cannon blast rate in seconds
	public float fireDelay;

	public GameObject cannonBall;
	// used to store our cannon ball prefab
	public GameObject cannonBase;
	// used to store our cannon base
	public GameObject cannonStart;
	// used to store our cannon nozle starting point

	// Use this for initialization
	void Start ()
	{

		this.canonBallSpeed = 0.005f;//Random.Range (0.3, 1); // randomize cannon ball speed between 3 and 4
		this.rateOfFire = Random.Range (3, 6.5f); // randomize rate of fire between 3 and 6.5 seconds

		// set a fire delay time for the cannon
		this.fireDelay = Time.time + this.rateOfFire;
	}
 
	// Update is called once per frame
	void Update ()
	{

		// if the current game running time is larger then our fire delay time, then fire!
		if (Time.time > this.fireDelay) {

			// cannon ball speed and rate of fire will be randomly generated based
			// on the defined boundaries ...
			this.canonBallSpeed = 1.5f;//Random.Range (3, 4);
			this.rateOfFire = Random.Range (3, 6.5f);

			// re-set our fire delay
			this.fireDelay = Time.time + this.rateOfFire;
   
			// instantiate our cannon ball at the specified location
			GameObject fire = GameObject.Instantiate (this.cannonBall,
				                  this.cannonStart.transform.position,
				                  this.cannonStart.transform.rotation) as GameObject;

			// self-destruct our cannon ball after 10 seconds
			Destroy (fire, 10.0f);

			// use the physics engine to push/give velocity to our cannon ball
			fire.GetComponent<Rigidbody> ().velocity = this.cannonStart.transform.TransformDirection (
				new Vector3 (0, this.canonBallSpeed, 0));
		} 

		// rotate the cannon base around its Y-Axis continiously
		this.cannonBase.transform.Rotate (Vector3.up, 10 * Time.deltaTime);
	}
 }
