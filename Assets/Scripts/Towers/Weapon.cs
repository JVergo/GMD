using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public float radius;
    public float fireRate;
    public Transform spawnPoint;

    private float fireTimer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (fireTimer >= 0)
        {
            fireTimer -= Time.deltaTime;
        }
    }

    public bool Fire(Transform target)
    {
        bool canHit = false;
        if (Vector3.Distance(this.transform.position, target.position) <= radius && target.gameObject.activeSelf)
        {
            canHit = true;

            this.transform.LookAt(new Vector3(target.position.x, target.position.y, target.position.z));

            if (fireTimer <= 0)
            {
                Shoot();
            }
        }

        return canHit;
    }

    private void Shoot()
    {
        GameObject projectile = ProjectilePool.instance.GetInactiveProjectile();
        projectile.transform.position = spawnPoint.position;
        projectile.transform.rotation = spawnPoint.rotation;
        projectile.SetActive(true);
        fireTimer = fireRate;
    }
}
