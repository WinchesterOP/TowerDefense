using UnityEngine;

public class enemy : MonoBehaviour
{
	public float speed = 10f; //Geschwindigkeitsvariable
	public float deltaDistance = 0.2f; // Abstand zu den Waypoints

	private Transform target; //Variable um das nächste Ziel anzuwählen
	private int waypointIndex = 0; //Temp-Zähler

	void Start ()
	{
		target = waypoints.points[waypointIndex];
	}

	void Update ()
	{
		Vector3 direction = target.position - transform.position; // Ziel Position - aktuelle Position um einen Vektor zu bekommen
		/**
		 * Translate wird gentzt um eine Objekt zu bewegen mit einem Vektor
		 * normalized ist dafür da eine gleichmäßige Bewegung durchzuführen
		 * Space.World = die Welt in der sich das Objekt bewegt. Unsere Spielewelt
		 */
		transform.Translate(direction.normalized * speed * Time.deltaTime, Space.World);

		if (Vector3.Distance(target.position,transform.position) <= deltaDistance)
        {
			GetNextWaypoint();
        }
	}

	void GetNextWaypoint()
    {
		if (waypointIndex > waypoints.points.Length - 1)
        {
			Destroy(gameObject);
			return;
        }

		waypointIndex++;
		target = waypoints.points[waypointIndex];
    }
}
