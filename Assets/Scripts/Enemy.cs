using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    float timer = 0;
    float timeToMove = 0.5f;
    int numOfMovements = 0;
    float speed = 5f;

    public GameObject enemy;
    public GameObject enemyProjectile;
    public GameObject enemyProjectileClone;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer > timeToMove && numOfMovements < 8)
        {
            transform.Translate(new Vector3(speed, 0, 0));
            timer = 0;
            numOfMovements++;
        }
        if(numOfMovements == 8)
        {
            transform.Translate(new Vector3(0, -20f, 0));
            numOfMovements = -1;
            speed = -speed;
        }

        fireEnemyProjectile();
    }

    void fireEnemyProjectile()
    {
        if (Random.Range(0f, 750f) < 1)
        {
            enemyProjectileClone = Instantiate(enemyProjectile, new Vector3(enemy.transform.position.x, enemy.transform.position.y + -0.10f, 751), enemy.transform.rotation) as GameObject;
        }
    }
}
