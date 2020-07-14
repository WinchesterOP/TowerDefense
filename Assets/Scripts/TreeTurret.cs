using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeTurret : MonoBehaviour
{
    [Header("Attributes")]
    public float range = 30f; // Reichweite des Towers
    public float fireRate = 1f;
    private float fireCountDown = 0f;

    [Header("Unity Setup Fields")]
    public Transform target; // aktuelles Ziel
    public Transform firePoint;
    public GameObject bulletPrefab;
    public string enemyTag = "Enemy";



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
        } else
        {
            target = null;
        }
    }

    void Shoot()
    {
        GameObject bulletGo = (GameObject)Instantiate(bulletPrefab, firePoint.position, firePoint.rotation); // erstelltest Objekt wird als GameObject gespeichert
        Bullet bullet = bulletGo.GetComponent<Bullet>();

        if (bullet != null)
        {
            bullet.Seek(target);
        }
    }


    // Update is called once per frame
    void Update()
    {
        if (target == null) 
            return;

        if (fireCountDown <= 0f)
        {
            Shoot();
            fireCountDown = 1f / fireRate;
        }

        fireCountDown -= Time.deltaTime;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.magenta;
        // DrawWired zeigt nur Linien als Begrenzung. Werte sind Position und Reichweite der Linien
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
