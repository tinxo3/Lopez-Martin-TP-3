using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pokemon : MonoBehaviour
{
    [SerializeField]           
    private string pokemonName;
    [SerializeField]
    private float movementSpeed;
    private Rigidbody2D rd;
    [SerializeField]
    States currentState;
    [SerializeField]
    bool isPlayer = false;
    public GameObject projectile;
    public GameObject projectileClone;
    public GameObject player;
    enum States
    {
        IDLE,
        MOVING,
        ATTACK,
        HIT
    }    

    // Start is called before the first frame update
    void Start()
    {

        rd = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            currentState = States.ATTACK;
        }
        //fireProjectile();
    }

    private void FixedUpdate()
    {
        //if (isPlayer)
        if (GameManager.lives > 0)
        {
            Move();
            fireProjectile();
        }
        if (GameManager.playGame == false)
        {
            movementSpeed = 0;
            //fireProjectile();
        }
    }
    public string GetPokemonName()
    {
        return pokemonName;
    }

    public void SetPokemonName(string newPokemonName)
    {
        pokemonName = newPokemonName;
    }

    public void Move()
    {
        Vector2 velocity = new Vector2();
        if (Input.GetKey(KeyCode.A))
        {
            velocity.x = -movementSpeed;
          
        }
        if (Input.GetKey(KeyCode.D))
        {
            velocity.x = movementSpeed;
      
        }
        if (velocity.magnitude != 0)
        {
            currentState = States.MOVING;
        }
        else
        {
            currentState = States.IDLE;
        }
        rd.velocity = velocity * Time.deltaTime;
    }

    void fireProjectile()
    {
        if (Input.GetKeyDown(KeyCode.Space) && projectileClone == null)
        {
            projectileClone = Instantiate(projectile, new Vector3(player.transform.position.x, player.transform.position.y + 20f, 751), player.transform.rotation) as GameObject;
        }
    }
}
