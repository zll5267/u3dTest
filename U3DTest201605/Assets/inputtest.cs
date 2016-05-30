using UnityEngine;
using System.Collections;

public class inputtest : MonoBehaviour {

	private GameObject cube1;
	private GameObject cube2;
	private GameObject cube3;

	private bool CREATED;
	// Use this for initialization
	void Start () {
		this.CREATED = false;
	}
	
	// Update is called once per frame
	void Update () {

		if (CREATED) {
			if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.LeftShift))
				this.cube1.transform.localPosition += new Vector3(0, 0.01f, 0);
			else if (Input.GetKey (KeyCode.A) && Input.GetKey (KeyCode.UpArrow))
				this.cube1.transform.Rotate (new Vector3 (1, 0, 0), 1);
			else if (Input.GetKey(KeyCode.A))
				//this.cube1.transform.localPosition += new Vector3(0, -0.01f, 0);
				this.cube1.transform.Translate(Vector3.down * Time.deltaTime);

			if (Input.GetKey(KeyCode.B) && Input.GetKey(KeyCode.LeftShift))
				//this.cube2.transform.localPosition += new Vector3(0, 0, 0.01f);
				this.cube2.transform.Translate(Vector3.forward * Time.deltaTime);
			else if (Input.GetKey (KeyCode.B) && Input.GetKey (KeyCode.RightArrow))
				this.cube2.transform.Rotate (new Vector3 (0, 1, 0), 1);
			else if (Input.GetKey(KeyCode.B))
				this.cube2.transform.localPosition += new Vector3(0, 0, -0.01f);

			if (Input.GetKey(KeyCode.C) && Input.GetKey(KeyCode.LeftShift))
				this.cube3.transform.localPosition += new Vector3(0.01f, 0, 0);
			else if (Input.GetKey (KeyCode.C) && Input.GetKey (KeyCode.Z))
				this.cube3.transform.Rotate (new Vector3 (0, 0, 1), 1);
			else if (Input.GetKey(KeyCode.C))
				//this.cube3.transform.localPosition += new Vector3(-0.01f, 0, 0);
				this.cube3.transform.Translate(Vector3.left * Time.deltaTime);

		} else {
			if (Input.GetKey(KeyCode.Space))
				CreateMyPrimitives ();
		}
	}

	void CreateMyPrimitives() {
		if (!CREATED) {
			if (this.cube1 == null) {
				this.cube1 = GameObject.CreatePrimitive (PrimitiveType.Cube);
				this.cube1.transform.localPosition = new Vector3 (0, 2, 0);
			}
			if (this.cube2 == null) {
				this.cube2 = GameObject.CreatePrimitive (PrimitiveType.Cube);
				this.cube2.transform.localPosition = new Vector3 (3, 2, 0);
			}

			if (this.cube3 == null) {
				this.cube3 = GameObject.CreatePrimitive (PrimitiveType.Cube);
				this.cube3.transform.localPosition = new Vector3 (-3, 2, 0);
			}

			this.CREATED = true;
		}
	}
}
