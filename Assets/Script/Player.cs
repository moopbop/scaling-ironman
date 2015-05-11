using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public float speed;			// Player's movement speed
	public GameObject bullet;	// Bullet prefab
	public float bulletSpeed;	// Allows for speed powerups

	private Vector3 updatePos;	// Temp Vector3 
	private Rigidbody rb;

	void Start() {
		rb = this.GetComponent<Rigidbody> ();
	}

	void Update() {

		#region shooting
		if (Input.GetKeyDown (KeyCode.LeftArrow)) {
			GameObject o = Instantiate (bullet, this.rb.transform.position, Quaternion.identity) as GameObject;
			o.GetComponent<Projectile>().direction = new Vector3(-1, 0, 0);
			o.GetComponent<Projectile>().speed = this.bulletSpeed;
		}
		else if (Input.GetKeyDown (KeyCode.RightArrow)) {
			GameObject o = Instantiate (bullet, this.rb.transform.position, Quaternion.identity) as GameObject;
			o.GetComponent<Projectile>().direction = new Vector3(1, 0, 0);
			o.GetComponent<Projectile>().speed = this.bulletSpeed;
		}
		else if (Input.GetKeyDown (KeyCode.UpArrow)) {
			GameObject o = Instantiate (bullet, this.rb.transform.position, Quaternion.identity) as GameObject;
			o.GetComponent<Projectile>().direction = new Vector3(0, 1, 0);
			o.GetComponent<Projectile>().speed = this.bulletSpeed;
		}
		else if (Input.GetKeyDown (KeyCode.DownArrow)) {
			GameObject o = Instantiate (bullet, this.rb.transform.position, Quaternion.identity) as GameObject;
			o.GetComponent<Projectile>().direction = new Vector3(0, -1, 0);
			o.GetComponent<Projectile>().speed = this.bulletSpeed;
		}
		#endregion

		#region position clamping
		if (rb.transform.position.x < -8.5) {
			transform.position = new Vector2(-8.5f, transform.position.y);
		}
		if (rb.transform.position.x > 8.5) {
			transform.position = new Vector2(8.5f, transform.position.y);
		}
		if (rb.transform.position.y < -4.5) {
			transform.position = new Vector2(transform.position.x, -4.5f);
		}
		if (rb.transform.position.y > 4.5) {
			transform.position = new Vector2(transform.position.x, 4.5f);
		}
		#endregion
	}

	void FixedUpdate() {

		#region movement
		if (Input.GetKey (KeyCode.W)) {
			rb.AddForce (new Vector3 (0, speed, 0));
		}
		if (Input.GetKey (KeyCode.A)) {
			rb.AddForce (new Vector3 (-speed, 0, 0));
		}
		if (Input.GetKey (KeyCode.S)) {
			rb.AddForce (new Vector3 (0, -speed, 0));
		}
		if (Input.GetKey (KeyCode.D)) {
			rb.AddForce (new Vector3 (speed, 0, 0));
		}
		#endregion
	}

	void OnTriggerEnter(Collider c) {
		string colTag = c.gameObject.tag;
		Debug.Log ("I HIT THE THING");

		if (colTag == "pwp_speed_up") {
			this.bulletSpeed += 100;
			Destroy (c.gameObject);
		}
	}

	void OnCollisionEnter(Collision c) {
		Debug.Log ("Collide?");
	}
}
