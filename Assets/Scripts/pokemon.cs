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
        ATTACK
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
        fireProjectile();
    }

    private void FixedUpdate()
    {
        if (isPlayer)
        {
            Move();
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
            projectileClone = Instantiate(projectile, new Vector3(player.transform.position.x, player.transform.position.y + 0.10f, 751), player.transform.rotation) as GameObject;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("ontriggerenter2d");
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("ontriggerexit2D");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("oncollisionenter2d");
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        Debug.Log("oncollisionexit2d");
    }
}
