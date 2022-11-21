using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bottom : MonoBehaviour
{
    public Text endScreen;
    public Text Restart;
    public GameObject bottom;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            GameManager.playGame = false;
            endScreen.text = "YOU LOSE!";
            Restart.text = "Press R to restart";
            Debug.Log("colisionooo");
        }
    }
}

