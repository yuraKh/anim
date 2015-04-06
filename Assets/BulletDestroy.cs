using UnityEngine;
using System.Collections;

public class BulletDestroy : MonoBehaviour {

		void OnBecameInvisible ()
		{
			Destroy (gameObject);
		}
	}