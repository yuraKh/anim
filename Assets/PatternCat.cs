using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PatternCat : MonoBehaviour
{

	//public GameObject gun;
	public int hp = 5;
	//public Text health;
	//GameObject Cgun;

	private static PatternCat _cat;
	public static PatternCat cat {
		get {
			if (_cat == null) {
				_cat = GameObject.FindObjectOfType<PatternCat> ();
				DontDestroyOnLoad (_cat.gameObject);	
			}
			return _cat;
		}
	}
	void Awake ()
	{
		if (_cat == null) {
			_cat = this;
			DontDestroyOnLoad (_cat.gameObject);
		} else if (this != _cat) {
			Destroy (this.gameObject);
		}
	}
	void Update ()
	{

		//health.text = "Health: " + hp;
	}
	/*void OnTriggerEnter2D (Collider2D col)
	{
		if (col.name == "gun") {
			Cgun = (GameObject)Instantiate (gun);
			Cgun.transform.parent = gameObject.transform;
			Cgun.transform.position = new Vector3 (gameObject.transform.position.x + 0.5f, gameObject.transform.position.y, 0);
			Destroy (col.gameObject);
		}
	}*/
}
