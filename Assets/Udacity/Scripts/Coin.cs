using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour 
{
	float turnSpeed;
	Renderer coinRenderer;

	static int totalCoinsFound;

    // Create a reference to the CoinPoofPrefab
	public GameObject coinPoof;

	void Start() {
		turnSpeed = 300f;
		totalCoinsFound = 0;
		coinRenderer = gameObject.GetComponent<Renderer> ();
	}

    public void OnCoinClicked() {
        // Instantiate the CoinPoof Prefab where this coin is located
		Object.Instantiate (coinPoof, gameObject.transform.position, Quaternion.Euler (-90f, 0f, 0f));

		totalCoinsFound++;

        // Destroy this coin. Check the Unity documentation on how to use Destroy
		Destroy (gameObject);
    }

	public void Update() {
		// Make coins rotate in place if visible and near them
		if (coinRenderer.isVisible) {
			float distanceFromCoin = Mathf.Abs (gameObject.transform.position.x - Camera.main.transform.position.x) +
			                         Mathf.Abs (gameObject.transform.position.z - Camera.main.transform.position.z);

			if (distanceFromCoin > 4.1 && distanceFromCoin < 4.3) {
				transform.Rotate (Vector3.up, turnSpeed * Time.deltaTime);
			}
		}
	}

	// Used for the Winner Sign at the end of the maze
	public int getTotalCoinsFound() {
		return totalCoinsFound;
	}
}
