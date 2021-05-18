using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public Material GhostMaterial;
    public Image HelathbarFill;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void CreateGhost(GameObject prefab)
    {
        var instance = GameObject.Instantiate(prefab);

        var renderes = instance.GetComponentsInChildren<Renderer>();
        foreach (var rendere in renderes)
        {
            rendere.material = GhostMaterial;
        }

        instance.AddComponent(typeof(GhostBehaviour));
     }

    public void UpdateHelathbar()
    {
        HelathbarFill.fillAmount = Mathf.Clamp(GameController.instance.health / 100f, 0, 1f);
    }
}
