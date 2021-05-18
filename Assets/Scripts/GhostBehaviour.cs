using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GhostBehaviour : MonoBehaviour
{
    private Material TowerMaterial;
    // Start is called before the first frame update
    void Start()
    {
        TowerMaterial = this.GetComponentInChildren<BaseTower>().TowerMaterial;
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit Hit;
        Vector3 targetPos;

        if (Physics.Raycast(ray, out Hit, 100))
        {
            targetPos = Hit.point;

            transform.position = targetPos;
        }

        //Check if tower is nerby and rules for placement

        if (Input.GetMouseButtonUp(0))
        {
            var renderes = this.GetComponentsInChildren<Renderer>();
            foreach (var rendere in renderes)
            {
                rendere.material = TowerMaterial;
            }

            this.GetComponentInChildren<BaseTower>().enabled = true;
            this.GetComponentInChildren<NavMeshObstacle>().enabled = true;

            Destroy(this);
        }
    }
}
