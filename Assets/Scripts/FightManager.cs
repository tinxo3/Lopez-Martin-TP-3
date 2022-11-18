using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightManager : MonoBehaviour
{
    [SerializeField]
    private pokemon Pikachu;
    [SerializeField]
    private pokemon Squirtle;
    void Start()
    {
        Debug.Log("Vida squirtle antes:" + Squirtle.GetHealth());
        Pikachu.Attack(Squirtle);
        Debug.Log("Vida squirtle despues:" + Squirtle.GetHealth());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
