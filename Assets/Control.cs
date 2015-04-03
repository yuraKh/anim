using UnityEngine;
using System.Collections;

public class Control : MonoBehaviour {

	public GameObject coin;
	public Transform Sens;
	public LayerMask Ground;
	bool SensIfGround = false;
	bool IfRight = true;
	Rigidbody2D CatRBody;
	Animator CatAnim;
	//float timer = 0;
	bool forOne = true;

	void Start () {
		CatRBody = GetComponent<Rigidbody2D> ();
		CatAnim = GetComponent<Animator> ();
		GameObject Money = (GameObject)Instantiate(coin);
		coin.transform.position = new Vector3(gameObject.transform.position.x + Random.Range(1, 10), gameObject.transform.position.y, gameObject.transform.position.z);
	}
	
	void Update () {
		/*timer += Time.deltaTime;
		if (timer > 1&&forOne) {
			forOne = false;
			GameObject Money = (GameObject)Instantiate(coin);
			coin.transform.position = new Vector3(gameObject.transform.position.x + Random.Range(1, 10), gameObject.transform.position.y, gameObject.transform.position.z);
		}*/

		if (SensIfGround && Input.GetKeyDown (KeyCode.Space)) {
			CatAnim.SetBool ("IfGround", false);
			CatRBody.velocity = new Vector2 (CatRBody.velocity.x, 9f);
		}
	}

	void FixedUpdate () {
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

		} 
		else if (move < 0 && IfRight) {
			IfRight = !IfRight;
			Vector3 size = transform.localScale;
			size.x *= -1;
			transform.localScale = size;
		}

	}

	void OnTriggerStay2D (Collider2D Call) {
		if (Call.name == "coin") {
			Destroy (gameObject);
		}
	}
}
