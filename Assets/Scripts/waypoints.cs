using UnityEngine;

public class waypoints : MonoBehaviour
{
	//static damit ich von anderen Skripten zugreifen kann
	public static Transform[] points;

	void Awake()
	{	
		/**	alle Objekte im Ordner Waypoints sind die Childs von dem Ordner und 
		*	können über childCount und GetChild gezählt werden.
		*/
		points = new Transform[transform.childCount]; // 11 Waypoints also 11 Childs ein Array der Größe 11 wird erstellt
		for (int i = 0; i < points.Length; i++)
		{
			points[i] = transform.GetChild(i);
			Debug.Log(points[i].position.x);
		}
	}
}
