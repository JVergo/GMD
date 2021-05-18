using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public static GameController instance;
    public UIController uiController;

    public int health = 100;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AdjustHelath(int amount)
    {
        health += amount;

        uiController.UpdateHelathbar();

        if (health <= 0)
        {
            SceneManager.LoadScene(0);
        }
    }
}
