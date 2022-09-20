using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyController : MonoBehaviour
{


    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player Attack"){

            Destroy(gameObject);
        }
        
    }
}
