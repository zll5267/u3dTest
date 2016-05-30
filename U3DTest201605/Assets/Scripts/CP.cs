using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CP : MonoBehaviour {
	
	public Text lblTextPosition;
	private string position = "";

	public Text lblTextScore;
	private int score = 0;

	public Text lblTextTime;
	private float timer = 0;

	// Use this for initialization
	void Start () {
		this.score = 0;
		this.timer = 30.00f;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.UpArrow)) {
			this.transform.Translate (Vector3.forward * Time.deltaTime);
		}

		if (Input.GetKey (KeyCode.DownArrow)) {
			this.transform.Translate (Vector3.back * Time.deltaTime);
		}

		if (Input.GetKey (KeyCode.LeftArrow)) {
			//this.transform.Rotate (new Vector3(0, 1, 0), -1);
			this.transform.Translate (Vector3.left * Time.deltaTime);
		}

		if (Input.GetKey (KeyCode.RightArrow)) {
			//this.transform.Rotate (new Vector3(0, 1, 0), 1);
			this.transform.Translate (Vector3.right * Time.deltaTime);
		}

		if (this.lblTextPosition != null) {
			position = string.Format ("P:<{0:F2}, {1:F2}, {2:F2}>",
				this.transform.localPosition.x,
				this.transform.localPosition.y,
				this.transform.localPosition.z);

			this.lblTextPosition.text = position;
		}
		if (this.lblTextScore != null)
			this.lblTextScore.text = "Score: " + score.ToString();
		if (this.lblTextTime != null)
			this.lblTextTime.text = string.Format("Time: <{0:F2}>", this.timer - Time.time);
	}

	void OnTriggerEnter(Collider c) {
		if (c.tag.Equals("coin")) {
			Coin coin = c.GetComponent<Coin> ();
			this.score += coin.VALUE;

			Destroy (c.gameObject);
		}

		if (c.tag.Equals("cannonball")) {
			Debug.Log ("hit by cannon ball");

			Destroy (c.gameObject);
		}
	}
}
