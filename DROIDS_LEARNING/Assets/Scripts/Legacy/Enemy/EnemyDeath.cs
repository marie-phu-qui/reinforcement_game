using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeath : MonoBehaviour
{
    // [Header("ENEMY DEATH SETTINGS")]
    // public int explosionDamage = 100;

    // public GameObject Player;

    // [Header("DEBUG")]
    // public bool playerWithinBlast = false;



    [Header("PUBLIC REFERENCES")]
    public GameObject explosionEffect;
    public GameObject Player01;


    public void HandleDeath(int pointsValue)
    {
        //  Instantiates the explosion effect
        Instantiate(explosionEffect, transform.position, transform.rotation);

        //  Award the player with points
        Player01.GetComponent<Scoreboard>().addPoints(pointsValue);

        //  Removes the enemy from the game
        Destroy(gameObject);
    }

        //  Award the player some points for destroying the enemy
        //  Player.GetComponent<PlayerControl>().updateScore(value);

        //  If the player is whithin the blast radius ..
        //  if (playerWithinBlast == true)
        //  { 
        //      .. tell the PlayerHealth script to take explosion damage
        //      Player.GetComponent<PlayerHealth>().TakeDamage(explosionDamage);
        //  }
    

    //  This determines whether the player should receive blast damage
    //  public void togglePlayerWithinBlast()
    //  {
    //	    playerWithinBlast = !playerWithinBlast;
    //  }

}
