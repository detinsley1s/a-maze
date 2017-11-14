using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Door : MonoBehaviour 
{
	public Coin coin;
	public SignPost signPost;
	public AudioClip doorLocked;
	public AudioClip doorOpening;
	private AudioSource source;

    // Create a boolean value called "locked" that can be checked in OnDoorClicked()
	bool locked = true;

    // Create a boolean value called "opening" that can be checked in Update() 
	bool opening = false;

	void Awake() {
		source = GetComponent<AudioSource> ();
	}

    void Update() {
        // If the door is opening and it is not fully raised
            // Animate the door raising up
		if (opening && gameObject.transform.position.y < 8) {
			transform.Translate (Vector3.up * Time.deltaTime);
		}
    }

    public void OnDoorClicked() {
        // If the door is clicked and unlocked
            // Set the "opening" boolean to true
        // (optionally) Else
            // Play a sound to indicate the door is locked

		// Prevents the door from being clicked if player is not next to it
		// or if the door is opening
		float distanceFromDoor = Mathf.Abs (gameObject.transform.position.x - Camera.main.transform.position.x) +
								 Mathf.Abs (gameObject.transform.position.z - Camera.main.transform.position.z);

		if (distanceFromDoor < 6 && !opening) {
			if (!locked) {
				opening = true;
				source.PlayOneShot (doorOpening); // Play door opening sound effect

				// Place winning text on Sign Post
				Text winnerText = signPost.GetComponent<Text> ();
				winnerText.text = "YOU WON!\n" + coin.getTotalCoinsFound () + "/10\ncoins found";
			} else {
				source.PlayOneShot (doorLocked);  // Play door locked sound effect
			}
		}
    }

    public void Unlock()
    {
        // You'll need to set "locked" to false here
		locked = false;
    }

	public bool isOpening() {
		return opening;
	}
}
