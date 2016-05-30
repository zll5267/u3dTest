using UnityEngine;
using System.Collections;

public class CPMove : MonoBehaviour {

	public float angleX = 0f;
	public float angleY = 0f;
	public float angleZ = 0f;
	public float anglespeed = 2f;


	// Use this for initialization
	void Start () {
		angleX = this.transform.eulerAngles.x;
		angleY = this.transform.eulerAngles.y;
		angleZ = this.transform.eulerAngles.z;
	}
	
	// Update is called once per frame
	void Update () {
		OnKeyDown();
		if (Input.GetMouseButton(1))
			OnMouseMove();
	}

	void OnKeyDown() {
		if (Input.GetKey (KeyCode.S)) {
			this.transform.Translate (Vector3.forward * Time.deltaTime);
		}

		if (Input.GetKey (KeyCode.W)) {
			this.transform.Translate (Vector3.back * Time.deltaTime);
		}

		if (Input.GetKey (KeyCode.D)) {
			this.transform.Translate (Vector3.left * Time.deltaTime);
		}

		if (Input.GetKey (KeyCode.A)) {
			this.transform.Translate (Vector3.right * Time.deltaTime);
		}

		if (Input.GetKey (KeyCode.LeftArrow)) {
			this.transform.Rotate (new Vector3 (0, 1, 0), -1);
		}

		if (Input.GetKey (KeyCode.RightArrow)) {
			this.transform.Rotate (new Vector3 (0, 1, 0), 1);
		}
	}
	void OnMouseMove() {
		if (Input.GetMouseButton(1))
        {
            angleY += Input.GetAxis("Mouse X") * anglespeed;
        }
 
        Quaternion rotation = Quaternion.Euler(angleX, angleY, angleZ);
        this.transform.rotation = rotation;
	}
}
