using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public GameObject projectile;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(0, 200 * Time.deltaTime, 0));
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            Destroy(collision.gameObject);
            Destroy(projectile);
            GameManager.playGame = true;
           // numOfKills++;
            
        }
        if(collision.gameObject.tag == "Respawn")
        {
            Destroy(projectile);
        }
        if(GameManager.numOfKills >= 24)
        {
            GameManager.Win = true;
            GameManager.playGame = false;
            Debug.Log("Win");
        }
        if (collision.gameObject.tag == "Enemy")
        {
            GameManager.numOfKills++;
            Debug.Log("Kill");
        }    
    }


}
