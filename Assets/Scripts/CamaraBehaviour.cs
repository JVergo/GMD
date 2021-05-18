using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraBehaviour : MonoBehaviour
{
    public float speed = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A) || Input.mousePosition.x < 5)
        {
            this.transform.Translate(Vector3.left * speed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.D) || Input.mousePosition.x > this.GetComponent<Camera>().pixelWidth - 5) 
        {
            this.transform.Translate(Vector3.right * speed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.W) || Input.mousePosition.y > this.GetComponent<Camera>().pixelHeight - 5)
        {
            this.transform.Translate(Vector3.up * speed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.S) || Input.mousePosition.y < 5)
        {
            this.transform.Translate(Vector3.down * speed * Time.deltaTime);
        }
    }
}
