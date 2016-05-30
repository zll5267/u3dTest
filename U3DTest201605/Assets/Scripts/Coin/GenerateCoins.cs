using UnityEngine;
using System.Collections;

public class GenerateCoins : MonoBehaviour {

	public GameObject coinPrefab;

	private int totalGoldCoins = 18;

	// Use this for initialization
	void Start () {
		if (coinPrefab != null) {
			for (int i = 0; i < totalGoldCoins * 2/3 ; i++) {
				if (i < totalGoldCoins *2/9 ) {
					GameObject coin = GameObject.Instantiate (this.coinPrefab,
						                  new Vector3 (Random.Range (-4.5f, 4.5f), 0.25f, Random.Range (3.0f, 4.5f)),
						                  this.coinPrefab.transform.rotation) as GameObject;
					coin.name = "R1AutoGenCoin" + i;
				} else if (i < totalGoldCoins * 4 /9) {
					GameObject coin = GameObject.Instantiate (this.coinPrefab,
						new Vector3 (Random.Range (-4.5f, 4.5f), 0.25f, Random.Range (-4.5f, -3.0f)),
						this.coinPrefab.transform.rotation) as GameObject;
					coin.name = "R1AutoGenCoin" + i;
				} else if (i < totalGoldCoins * 5 /9) {
					GameObject coin = GameObject.Instantiate (this.coinPrefab,
						new Vector3 (Random.Range (-4.5f, -3.0f), 0.25f, Random.Range (-2.0f, 2.0f)),
						this.coinPrefab.transform.rotation) as GameObject;
					coin.name = "R1AutoGenCoin" + i;
				} else {
					GameObject coin = GameObject.Instantiate (this.coinPrefab,
						new Vector3 (Random.Range (3.5f, 4.5f), 0.25f, Random.Range (-2.0f, 2.0f)),
						this.coinPrefab.transform.rotation) as GameObject;
					coin.name = "R1AutoGenCoin" + i;
				}
			}

			for (int i = 0; i < totalGoldCoins / 9; i++) {
				GameObject coin = GameObject.Instantiate (this.coinPrefab,
					new Vector3 (Random.Range (-2.0f, 2.0f), 0.25f, Random.Range (1.5f, 2.0f)),
					this.coinPrefab.transform.rotation) as GameObject;
				coin.name = "R2AutoGenCoin" + i;
			}

			for (int i = 0; i < totalGoldCoins / 9; i++) {
				GameObject coin = GameObject.Instantiate (this.coinPrefab,
					new Vector3 (Random.Range (-2.0f, 2.0f), 0.25f, Random.Range (-0.5f, 0.5f)),
					this.coinPrefab.transform.rotation) as GameObject;
				coin.name = "R3AutoGenCoin" + i;
			}

			for (int i = 0; i < totalGoldCoins / 9; i++) {
				GameObject coin = GameObject.Instantiate (this.coinPrefab,
					new Vector3 (Random.Range (-2.0f, 2.0f), 0.25f, Random.Range (-2.0f, -1.5f)),
					this.coinPrefab.transform.rotation) as GameObject;
				coin.name = "R4AutoGenCoin" + i;
			}


		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
