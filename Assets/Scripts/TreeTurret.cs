using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeTurret : MonoBehaviour
{
    public Transform target; // aktuelles Ziel
    public string enemyTag = "Enemy";

    public float range = 30f; // Reichweite des Towers

    // Start is called before the first frame update
    void Start()
    {
        // macht das UpdateTarget FUnktion zu einer FUnktion die o.5 mal Pro Sekunde aufgerufen wird
        // 0f ab der nullten Sekunde
        // 0.5f wie oft er das wiederholen soll in der Sekunde
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }

    private void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag); // erstellen eines Array aller Enemies mit dem Enemy Tag

        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null; 

        foreach( GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            
            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }

        if ((nearestEnemy != null) && (shortestDistance <= range))
        {
            target = nearestEnemy.transform;
            Debug.Log("ich bin in der IF");
        } else
        {
            target = null;
            Debug.Log("Kein IF");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null) 
            return;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.magenta;
        // DrawWired zeigt nur Linien als Begrenzung. Werte sind Position und Reichweite der Linien
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
