using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour 
{
	float turnSpeed;
	bool keyCollected;
	Renderer keyRenderer;

    //Create a reference to the KeyPoofPrefab and Door
	public GameObject keyPoof;
	public Door door;

	void Start() {
		turnSpeed = 300f;
		keyCollected = false;
		keyRenderer = gameObject.GetComponent<Renderer> ();
	}

	void Update()
	{
		// Make key rotate in place if visible and near it
		if (keyRenderer.isVisible) {
			float distanceFromKey = Mathf.Abs (gameObject.transform.position.x - Camera.main.transform.position.x) +
			                        Mathf.Abs (gameObject.transform.position.z - Camera.main.transform.position.z);

			if (distanceFromKey > 4.1 && distanceFromKey < 4.3) {
				transform.Rotate (Vector3.forward, turnSpeed * Time.deltaTime);
			}
		}
	}

	public void OnKeyClicked()
	{
        // Instatiate the KeyPoof Prefab where this key is located
		Object.Instantiate (keyPoof, gameObject.transform.position, Quaternion.Euler (-90f, 0f, 0f));

        // Call the Unlock() method on the Door
        // Set the Key Collected Variable to true
		door.Unlock ();
		keyCollected = true;

        // Destroy the key. Check the Unity documentation on how to use Destroy
		Destroy(gameObject);
    }
}
