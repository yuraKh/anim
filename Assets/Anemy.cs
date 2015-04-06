using UnityEngine;
using System.Collections;

public class Anemy : MonoBehaviour {

	public GameObject gun, bullet;
	public Transform Sens, SensM, SensJ, SensDP;
	public LayerMask Ground;
	bool SensIfGround = false;
	bool IfRight = true;
	Rigidbody2D CatRBody;
	Animator CatAnim;
	float move, timer = 0;

	//


	
	void Start ()
	{
		CatRBody = GetComponent<Rigidbody2D> ();
		CatAnim = GetComponent<Animator> ();
		move = 1;
	}
	
	void Update ()
	{
		if (SensIfGround && Physics2D.OverlapCircle (SensJ.position, 0.4f, Ground)) {
			CatAnim.SetBool ("IfGround", false);
			CatRBody.velocity = new Vector2 (CatRBody.velocity.x, 9f);
		}
	}
	
	void Ataka ()
	{
		if (timer > 1) {
			float moveB = move;
			GameObject obj = (GameObject)Instantiate (bullet, gun.transform.position, Quaternion.identity);
			Vector3 bulS = obj.transform.localScale;
            obj.transform.localScale = obj.transform.localScale * moveB;
			obj.GetComponent<Rigidbody2D> ().velocity = new Vector2 (10 * move, 0);
			timer = 0;
			obj.transform.localScale = bulS;
            
        }
	}
	
	void FixedUpdate ()
	{
		timer += Time.deltaTime;
		if (Mathf.Abs (SensDP.position.y - transform.position.y) < 0.1f) {
			if (SensDP.position.x - transform.position.x > 0) {
				move = 1;
				Ataka ();
			} else {
				move = -1;
				Ataka ();
			}
		}
		
		SensIfGround = Physics2D.OverlapCircle (Sens.position, 0.4f, Ground);
		CatAnim.SetBool ("IfGround", SensIfGround);
		CatAnim.SetFloat ("YSpeed", CatRBody.velocity.y);
		if (!SensIfGround) {
			return;
		}
		
		if (!Physics2D.OverlapCircle (SensM.position, 0.3f, Ground)) {
			move *= -1;
		}
		
		CatAnim.SetFloat ("XSpeed", Mathf.Abs (move));
		CatRBody.velocity = new Vector2 (move * 2, CatRBody.velocity.y);
		
		if (move > 0 && !IfRight) {
			IfRight = !IfRight;
			Vector3 size = transform.localScale;
			size.x *= -1;
			transform.localScale = size;
			Vector3 bulS = bullet.transform.localScale;
			bulS *= -1;
			bullet.transform.localScale = bulS;

		} else if (move < 0 && IfRight) {
			IfRight = !IfRight;
			Vector3 size = transform.localScale;
			size.x *= -1;
			transform.localScale = size;
			Vector3 bulS = bullet.transform.localScale;
			bulS *= -1;
			bullet.transform.localScale = bulS;           
        }
	}
}