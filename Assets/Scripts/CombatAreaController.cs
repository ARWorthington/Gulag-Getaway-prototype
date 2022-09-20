using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatAreaController : MonoBehaviour
{
    public float timeToFight;

    public GameObject[] enemies;

    public bool areWeFighting;

   public bool weFighting;

    public int enemyAmount;

    // Update is called once per frame
    private void Start()
    {
        enemyAmount = enemies.Length;
    }

    void Update()
    {
     if(areWeFighting == true)
        {
            
            for(int x = 0; x < enemies.Length; x++)
            {
                if (enemies[x] != null)
                {
                    enemyAmount = enemyAmount - 1;
                }
            }

        }
        
    

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            areWeFighting = true;
        }
    }

}
