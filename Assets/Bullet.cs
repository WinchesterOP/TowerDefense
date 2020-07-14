using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Transform target;
    public float speed = 70f;

    public void Seek (Transform _target)
    {
        target = _target;
    }

    void HitTarget()
    {
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update ()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 direction = target.position - transform.position;
        float distanceThisframe = speed * Time.deltaTime;

        if (direction.magnitude <= distanceThisframe)
        {
            HitTarget();
            return;
        }

        transform.Translate(direction.normalized * distanceThisframe, Space.World);
    }
}
