using UnityEngine;

public class Rock : MonoBehaviour
{
	/// <summary>
	/// Use this for initialization
	/// </summary>
	void Start()
	{
		// Apply impulse force to get rock moving
		const float MinImpulseForce = 1f;
		const float MaxImpulseForce = 7f;
		float angle = Random.Range(0, 2 * Mathf.PI);
		Vector2 direction = new Vector2(
			Mathf.Cos(angle), Mathf.Sin(angle));
		float magnitude = Random.Range(MinImpulseForce, MaxImpulseForce);
		GetComponent<Rigidbody2D>().AddForce(
			direction * magnitude,
			ForceMode2D.Impulse);
	}

	void OnBecameInvisible()
	{
		Destroy(gameObject);
	}
}
