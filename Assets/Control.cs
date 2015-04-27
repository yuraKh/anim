using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Control : MonoBehaviour
{

	public Text health;
	public GameObject coin, CatAn, gun;
	public Transform Sens;
	public LayerMask Ground;
	bool SensIfGround = false;
	bool IfRight = true;
	Rigidbody2D CatRBody;
	Animator CatAnim;
	//int hp = 3;
	float timer = 0;
	public bool forOne = false;
	Vector3 deltac;
	GameObject Cgun;

	void Start ()
	{
		deltac = Camera.main.transform.position - transform.position;
		CatRBody = GetComponent<Rigidbody2D> ();
		CatAnim = GetComponent<Animator> ();
		GameObject Money = (GameObject)Instantiate (coin);
		coin.transform.position = new Vector3 (gameObject.transform.position.x + Random.Range (1, 10), gameObject.transform.position.y, gameObject.transform.position.z);
	}
	
	void Update ()
	{
		Camera.main.transform.position = transform.position + deltac;
		if (SensIfGround && Input.GetKeyDown (KeyCode.Space)) {
			CatAnim.SetBool ("IfGround", false);
			CatRBody.velocity = new Vector2 (CatRBody.velocity.x, 15f);
		}
	}

	void FixedUpdate ()
	{
		health.text = "Health: " + PatternCat.cat.hp;
		SensIfGround = Physics2D.OverlapCircle (Sens.position, 1f, Ground);
		CatAnim.SetBool ("IfGround", SensIfGround);
		CatAnim.SetFloat ("YSpeed", CatRBody.velocity.y);
		
		float move = Input.GetAxis ("Horizontal");
		CatAnim.SetFloat ("XSpeed", Mathf.Abs (move));
		CatRBody.velocity = new Vector2 (move * 10, CatRBody.velocity.y);
		
		if (move > 0 && !IfRight) {
			IfRight = !IfRight;
			Vector3 size = transform.localScale;
			size.x *= -1;
			transform.localScale = size;

		} else if (move < 0 && IfRight) {
			IfRight = !IfRight;
			Vector3 size = transform.localScale;
			size.x *= -1;
			transform.localScale = size;
		}
	}
	void OnTriggerEnter2D (Collider2D col)
	{
		if (col.tag == "Cat") {
			Destroy (col.gameObject);
			print ("aaaaa");
			PatternCat.cat.hp--;
			if (PatternCat.cat.hp < 0) {
				Color one = GetComponent<SpriteRenderer> ().color;
				GetComponent<SpriteRenderer> ().color = GameObject.Find ("Anemy").GetComponent<SpriteRenderer> ().color;
				//GetComponent<Rigidbody2D> ().gravityScale = -0.2f;
				GameObject CatA = (GameObject)Instantiate (CatAn);
				CatA.transform.position = gameObject.transform.position;
				gameObject.transform.position = new Vector3 (gameObject.transform.position.x + Random.Range (-5, 5), gameObject.transform.position.y + 5, gameObject.transform.position.z);
				GetComponent<SpriteRenderer> ().color = one;
				PatternCat.cat.hp = 10;
			}
		}
		if (col.gameObject.tag == "coin") {
			PatternCat.cat.hp++;
			Destroy (col.gameObject);
			GameObject Money = (GameObject)Instantiate (coin);
			coin.transform.position = new Vector3 (gameObject.transform.position.x + Random.Range (-10, 10), gameObject.transform.position.y, gameObject.transform.position.z);
		}
		if (col.name == "door") {
			Application.LoadLevel (1);
		}
		if (col.name == "door2") {
			Application.LoadLevel (2);
		}
		if (col.name == "door1") {
			Application.LoadLevel (2);
		}
		if (col.name == "door4") {
			Application.LoadLevel (0);
		}
		if (col.name == "gun") {
			Cgun = (GameObject)Instantiate (gun);
			Cgun.transform.parent = gameObject.transform;
			Cgun.transform.position = new Vector3 (gameObject.transform.position.x + 0.5f, gameObject.transform.position.y, 0);
			Destroy (col.gameObject);
		}
	}
}
