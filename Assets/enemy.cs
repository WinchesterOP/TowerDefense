using UnityEngine;

public class enemy : MonoBehaviour
{
	public float speed = 10f;

	private Transform target;
	private int wavepointIndex = 0;

	void Start()
	{
		target = WayPoints.points[0];
	}

	void Update()
	{
		Vector3 direction = target.position - transform.position;
		transform.Translate(direction.normalized);
	}
}
