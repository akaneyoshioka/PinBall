using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour {
	private GameObject scoreText;

	public int score = 0;

	// Use this for initialization
	void Start () {
		this.scoreText = GameObject.Find ("ScoreText");
	}

	void OnCollisionEnter(Collision other){
		if (other.gameObject.tag == "LargeStarTag") {
			AddScore (20);
		} else if (other.gameObject.tag == "LargeCloudTag") {
			AddScore (20);
		} else if (other.gameObject.tag == "SmallStarTag") {
			AddScore (10);
		} else if (other.gameObject.tag == "SmallCloudTag") {
			AddScore (10);
		} else {
			AddScore (0);
		}
	}

	void AddScore(int score){
		this.score += score;
		this.scoreText.GetComponent<Text> ().text = "Score:" + this.score;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
