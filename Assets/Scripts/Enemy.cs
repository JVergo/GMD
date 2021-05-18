using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public Transform goal;

    public EnemySpawner spawner;

    public int hitPoints = 10;

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Finish")
        {
            this.gameObject.SetActive(false);
            this.transform.position = Vector3.zero;
            spawner.AddToInactivePool(this.gameObject);

            GameController.instance.AdjustHelath(-5);
        }
        else if(other.tag == "Projectile")
        {
            hitPoints--;

            if (hitPoints <= 0)
            {
                this.gameObject.SetActive(false);
                spawner.AddToInactivePool(this.gameObject);
            }
            other.gameObject.SetActive(false);
            ProjectilePool.instance.AddToInactivePool(other.gameObject);
        }
    }
}
