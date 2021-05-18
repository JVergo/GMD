using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseTower : MonoBehaviour
{
    public Material TowerMaterial;
    public Weapon Weapon;

    public Transform target;
    int layerMask = 1 << 8; //Layermask is a bitmask, bit shift operator

    // Start is called before the first frame update
    void Start()
    {
        Weapon = this.GetComponent<Weapon>();
        Weapon.radius = 5;
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null)
        {
            LocateEnemy();
        }
        else
        {
            var canFire = Weapon.Fire(target);

            if (!canFire)
            {
                target = null;
            }
        }
    }

    void LocateEnemy()
    {
        Collider[] hitColliders = Physics.OverlapSphere(this.transform.position, Weapon.radius, layerMask);
        if (hitColliders.Length > 0)
        {
            target = hitColliders[0].transform;
        }
    }
}
