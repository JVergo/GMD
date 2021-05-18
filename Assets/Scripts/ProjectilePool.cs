using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectilePool : MonoBehaviour
{
    private List<GameObject> InactivePool;
    public GameObject projetilePrefab;
    public static ProjectilePool instance;

    private void Awake()
    {
        instance = this;
        InactivePool = new List<GameObject>();
        CreateProjectiles(10);
    }

    public GameObject GetInactiveProjectile()
    {
        if (InactivePool.Count == 0)
        {
            CreateProjectiles(10);
        }

        GameObject projectile = InactivePool[0];
        InactivePool.Remove(projectile);
        return projectile;
    }

    private void CreateProjectiles(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            GameObject projectile = GameObject.Instantiate(projetilePrefab);
            projectile.SetActive(false);

            InactivePool.Add(projectile);
        }
    }

    public void AddToInactivePool(GameObject go)
    {
        InactivePool.Add(go);
    }
}
