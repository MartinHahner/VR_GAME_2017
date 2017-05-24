using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class Countdown : MonoBehaviour {

	float timeLeft = 60.0f;

	bool beep5 = true;
	bool beep4 = true;
	bool beep3 = true;
	bool beep2 = true;
	bool beep1 = true;
	bool beep0 = true;

	private Rigidbody rb;

	private CanvasGroup canvasGroup;

	void Start() {

		// hide GameOver Screen
		canvasGroup.alpha = 0;
		canvasGroup.interactable = false;
		canvasGroup.blocksRaycasts = false;

	}


	void Update() {

		TextMesh textObject = GameObject.Find("CountdownText").GetComponent<TextMesh>();

		timeLeft -= Time.deltaTime;
		textObject.text = "time left: " + Mathf.Round(timeLeft) + "s";

		if(timeLeft < 10.5) {

			// yellow
			float r=1.0f,g=1.0f,b=0.0f,a=1.0f;

			textObject.color = new Color(r,g,b,a);

		}

		if(timeLeft < 5.5) {

			if (beep5) {
				beep5 = false;
				Debug.Log ("Beep 5s");
			}

			// red
			float r=1.0f,g=0.0f,b=0.0f,a=1.0f;

			textObject.color = new Color(r,g,b,a);

		}

		if(timeLeft < 4.5) {

			if (beep4) {
				beep4 = false;
				Debug.Log ("Beep 4s");

			}

		}

		if(timeLeft < 3.5) {

			if (beep3) {
				beep3 = false;
				Debug.Log ("Beep 3s");

			}

		}

		if(timeLeft < 2.5) {

			if (beep2) {
				beep2 = false;
				Debug.Log ("Beep 2s");

			}

		}

		if(timeLeft < 1.5) {

			if (beep1) {
				beep1 = false;
				Debug.Log ("Beep 1s");

			}

		}

		if(timeLeft < 0.5) {

			if (beep0) {
				beep0 = false;
				Debug.Log ("Beep 0s");
			}

			// white
			float r=1.0f,g=1.0f,b=1.0f,a=1.0f;

			textObject.color = new Color(r,g,b,a);
			textObject.text = "Game Over!";

			// show GameOver Screen
			canvasGroup.alpha = 1;
			canvasGroup.interactable = true;
			canvasGroup.blocksRaycasts = true;

		}
			
	}

}
