using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiTouch : MonoBehaviour {
	//HingiJointコンポーネントを入れる
	private HingeJoint myHingeJoint;
	//初期の傾き
	private float defaultAngle=20;
	//弾いた時の傾き
	private float flickAngle=-20;

	int rightFingerId;
	int leftFingerId;

	//Use this for initialization
	void Start(){
		this.myHingeJoint = GetComponent<HingeJoint>();
		SetAngle (this.defaultAngle);
	}

	// Update is called once per frame
	void Update () {
		for (int i = 0; i < Input.touchCount; i++) {
			int id = Input.touches [i].fingerId;
			Vector2 pos = Input.touches [i].position;
		
			if (Input.touches [i].phase == TouchPhase.Began) {
				if (pos.x > Screen.width / 2 && tag == "RightFripperTag") {
					rightFingerId=id;
					SetAngle (this.flickAngle);
				} else if (pos.x < Screen.width / 2 && tag == "LeftFripperTag") {
					leftFingerId=id;
					SetAngle (this.flickAngle);
				}
			} else if (Input.touches [i].phase == TouchPhase.Ended) {
				if (id == rightFingerId && tag == "RightFripperTag") {
					SetAngle (this.defaultAngle);
				} else if (id == leftFingerId && tag == "LeftFripperTag") {
					SetAngle (this.defaultAngle);
				}
			}
		}
	}
		
	public void SetAngle(float angle){
		JointSpring jointSpr = this.myHingeJoint.spring;
		jointSpr.targetPosition=angle;
		this.myHingeJoint.spring = jointSpr;
	}
}