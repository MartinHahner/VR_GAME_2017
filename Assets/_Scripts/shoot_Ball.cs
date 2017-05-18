using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class shoot_Ball : MonoBehaviour {

	public Text countText;
	public Text winText;


	private int count;

	private void Start()
	{
		count = 0;
		countshots();
		winText.text = "";
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag("Monster"))
		{
			Destroy(other.gameObject);
			//other.gameObject.SetActive(false);
			count =count + 1;
			countshots();
		}
	}
	void countshots() //function that counts the points and displays it in game!
	{
		countText.text = "Count: " + count.ToString();

		if (count >= 2)
		{
			winText.text = ("You Win!!");
		}
	}
		
}
	