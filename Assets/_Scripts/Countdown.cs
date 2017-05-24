using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class Countdown : MonoBehaviour {

	float timeLeft = 60.0f;

	public CanvasGroup canvasGroup;

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

		if(timeLeft < 30.5) {

			// yellow
			float r=1.0f,g=1.0f,b=0.0f,a=1.0f;

			textObject.color = new Color(r,g,b,a);

		}

		if(timeLeft < 10.5) {

			// red
			float r=1.0f,g=0.0f,b=0.0f,a=1.0f;

			textObject.color = new Color(r,g,b,a);

		}

		if(timeLeft < 0.5) {

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
