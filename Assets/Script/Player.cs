using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public float speed;			// Player's movement speed
	public GameObject bullet;	// Bullet prefab
	public float bulletSpeed;	// Allows for speed powerups

	private Vector3 updatePos;	// Temp Vector3 

	void Update() {

		float increment = speed * Time.deltaTime;

		#region movement
		if (Input.GetKey (KeyCode.W)) {
//			updatePos = transform.position;
//			updatePos.y += speed * increment;
//			transform.position = Vector3.MoveTowards(transform.position, updatePos, increment);
			transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, transform.position.y + increment, transform.position.z), increment);
		}

		if (Input.GetKey (KeyCode.A)) {
//			updatePos = transform.position;
//			updatePos.x -= speed * increment;
//			transform.position = Vector3.MoveTowards(transform.position, updatePos, increment);
			transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x - increment, transform.position.y, transform.position.z), increment);
		}

		if (Input.GetKey (KeyCode.S)) {
//			updatePos = transform.position;
//			updatePos.y -= speed * increment;
//			transform.position = Vector3.MoveTowards(transform.position, updatePos, increment);
			transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, transform.position.y - increment, transform.position.z), increment);
		}

		if (Input.GetKey (KeyCode.D)) {
//			updatePos = transform.position;
//			updatePos.x += speed * increment;
//			transform.position = Vector3.MoveTowards(transform.position, updatePos, increment);
			transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x + increment, transform.position.y, transform.position.z), increment);
		}
		#endregion

		#region shooting
		if (Input.GetKeyDown (KeyCode.LeftArrow)) {
			GameObject o = Instantiate (bullet, this.transform.position, Quaternion.identity) as GameObject;
			o.GetComponent<Projectile>().direction = new Vector3(-1, 0, 0);
			o.GetComponent<Projectile>().speed = this.bulletSpeed;
		}
		else if (Input.GetKeyDown (KeyCode.RightArrow)) {
			GameObject o = Instantiate (bullet, this.transform.position, Quaternion.identity) as GameObject;
			o.GetComponent<Projectile>().direction = new Vector3(1, 0, 0);
			o.GetComponent<Projectile>().speed = this.bulletSpeed;
		}
		else if (Input.GetKeyDown (KeyCode.UpArrow)) {
			GameObject o = Instantiate (bullet, this.transform.position, Quaternion.identity) as GameObject;
			o.GetComponent<Projectile>().direction = new Vector3(0, 1, 0);
			o.GetComponent<Projectile>().speed = this.bulletSpeed;
		}
		else if (Input.GetKeyDown (KeyCode.DownArrow)) {
			GameObject o = Instantiate (bullet, this.transform.position, Quaternion.identity) as GameObject;
			o.GetComponent<Projectile>().direction = new Vector3(0, -1, 0);
			o.GetComponent<Projectile>().speed = this.bulletSpeed;
		}
		#endregion

		#region position clamping
		if (transform.position.x < -8.5) {
			transform.position = new Vector2(-8.5f, transform.position.y);
		}
		if (transform.position.x > 8.5) {
			transform.position = new Vector2(8.5f, transform.position.y);
		}
		if (transform.position.y < -4.5) {
			transform.position = new Vector2(transform.position.x, -4.5f);
		}
		if (transform.position.y > 4.5) {
			transform.position = new Vector2(transform.position.x, 4.5f);
		}
		#endregion
	}
}
