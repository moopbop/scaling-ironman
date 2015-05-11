using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {
	public Vector3 direction;
	public float speed = 15;

	private Vector3 nextPos;
	private float step;

	void Update() {

		step = speed * Time.deltaTime;

		nextPos = transform.position;
		nextPos += direction;
		transform.position = Vector3.MoveTowards (transform.position, nextPos, step);

		#region destroy on hit edge
		if (transform.position.x < -8.5) {
			Destroy (this.gameObject);
		}
		if (transform.position.x > 8.5) {
			Destroy (this.gameObject);
		}
		if (transform.position.y < -4.5) {
			Destroy (this.gameObject);
		}
		if (transform.position.y > 4.5) {
			Destroy (this.gameObject);
		}
		#endregion
	}
}
