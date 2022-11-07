using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pokemon : MonoBehaviour
{
    [SerializeField]           
    private string pokemonName;
    [SerializeField]
    private int experience;
    [SerializeField]
    private int level;
    [SerializeField]
    private int damage;
    [SerializeField]
    private int health;
    [SerializeField]
    private float movementSpeed;
    private Rigidbody2D rd;
    [SerializeField]
    States currentState;
    [SerializeField]
    bool isPlayer = false;

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
        if (Input.GetKey(KeyCode.E))
        {
            currentState = States.ATTACK;
        }
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

    public int GetExperience()
    {
        return experience;
    }

    public void SetPokemonExperience(int newExperience)
    {
        experience = newExperience;
    }

    public int GetLevel()
    {
        return level;
    }    

    public void SetLevel(int newLevel)
    {
        level = newLevel;
    }

    public int GetDamage()
    {
        return damage;
    }

    public void SetDamage(int newDamage)
    {
        damage = newDamage;
    }

    public int GetHealth()
    {
        return health;
    }

    public void SetHealth(int newHealth)
    {
        health = newHealth;
    }

    public void Attack(pokemon otherPokemon)
    {
        otherPokemon.TakeDamage(damage);
    }   

    public void TakeDamage(int pokemonDamage)
    {
        health -= pokemonDamage;
    }

    public void LevelUp()
    {
        experience = 0;
        level++;
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
