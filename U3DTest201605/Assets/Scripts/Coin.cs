using UnityEngine;
using System.Collections;

public class Coin : MonoBehaviour {

	private int value;

	public int VALUE
	{
		get { return this.value; }
	}
	// Use this for initialization
	void Start () {
		this.value = Random.Range (1, 9);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
