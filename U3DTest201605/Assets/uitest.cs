using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class uitest : MonoBehaviour {

	public Text lblTextPosition;
	public Text lblTextRotation;

	private string position = "";
	private string rotation = "";

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (this.lblTextPosition != null) {
			position = string.Format ("P:<{0:F2}, {1:F2}, {2:F2}>",
				this.transform.localPosition.x,
				this.transform.localPosition.y,
				this.transform.localPosition.z);
			
			this.lblTextPosition.text = position;
		}

		if (this.lblTextRotation != null) {
			rotation = string.Format ("R:< {0:F2}, {1:F2}, {2:F2} >",
				this.transform.localEulerAngles.x,
				this.transform.localEulerAngles.y,
				this.transform.localEulerAngles.z);
			this.lblTextRotation.text = rotation;
		}

		//if (Input.GetButtonDown ("UpButton")) {
		//	this.transform.Translate (Vector3.up * Time.deltaTime);
		//}
	}

	public void UpButtonOnClick() {
		this.transform.Translate (Vector3.up * Time.deltaTime);
	}

	public void DownButtonOnClick() {
		this.transform.Translate (Vector3.down * Time.deltaTime);
	}

	public void LeftButtonOnClick() {
		this.transform.Translate (Vector3.left * Time.deltaTime);
	}

	public void RightButtonOnClick() {
		this.transform.Translate (Vector3.right * Time.deltaTime);
	}

	public void RotateButtonOnClick() {
		this.transform.Rotate(new Vector3(1, 0, 0), 1);
	}
}
