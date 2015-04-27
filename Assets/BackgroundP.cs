using UnityEngine;
using System.Collections;


public class BackgroundP : MonoBehaviour
{

	public Transform[] background;

	float move;
	float catM;

	void Update ()
	{
		background [0].localPosition -= new Vector3 (0.01f, 0, 0);
		background [1].localPosition -= new Vector3 (0.01f, 0, 0);
		for (int i=0; i<2; i++) {
			if (background [i].localPosition.x < -13.61f) {
				background [i].localPosition += new Vector3 (27.22f, 0, 0);
			}
			if (background [i].localPosition.x > 13.61f) {
				background [i].localPosition -= new Vector3 (27.22f, 0, 0);
			}
		}
		move = Input.GetAxis ("Horizontal");
		if (Mathf.Abs (move) > 0.1) {
			background [0].localPosition -= new Vector3 (0.01f * move, 0, 0);
			background [1].localPosition -= new Vector3 (0.01f * move, 0, 0);
			background [2].localPosition -= new Vector3 (0.02f * move, 0, 0);
			background [3].localPosition -= new Vector3 (0.02f * move, 0, 0);
			background [4].localPosition -= new Vector3 (0.04f * move, 0, 0);
			background [5].localPosition -= new Vector3 (0.04f * move, 0, 0);
			
			for (int i=0; i<6; i++) {
				if (background [i].localPosition.x < -13.61f) {
					background [i].localPosition += new Vector3 (27.22f, 0, 0);
				}
				if (background [i].localPosition.x > 13.61f) {
					background [i].localPosition -= new Vector3 (27.22f, 0, 0);
				}
			}
		}
		//catM = GameObject.Find("Cat").GetComponent<Rigidbody2D>().velocity.y;

		if (catM > 0) {
			background [0].localPosition -= new Vector3 (0, 0.01f, 0);
			background [1].localPosition -= new Vector3 (0, 0.01f, 0);
			background [2].localPosition -= new Vector3 (0, 0.01f, 0);
			background [3].localPosition -= new Vector3 (0, 0.01f, 0);
			background [4].localPosition -= new Vector3 (0, 0.01f, 0);
			background [5].localPosition -= new Vector3 (0, 0.01f, 0);
		} else if (catM == 0) {
			return;
		} else {
			background [0].localPosition += new Vector3 (0, 0.01f, 0);
			background [1].localPosition += new Vector3 (0, 0.01f, 0);
			background [2].localPosition += new Vector3 (0, 0.01f, 0);
			background [3].localPosition += new Vector3 (0, 0.01f, 0);
			background [4].localPosition += new Vector3 (0, 0.01f, 0);
			background [5].localPosition += new Vector3 (0, 0.01f, 0);
		}
	}
}
