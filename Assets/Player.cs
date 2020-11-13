using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //add [System.Serializable] to show the public class in the unity editor
    [System.Serializable]
    //Creating a class for player stats
    public class PlayerStats
    {
        public int Health = 100;
    }

    //creating an instance for class playerstats
    public PlayerStats playerstats = new PlayerStats();
    // creating a public int for the fall boundary so we dont hardcode it
    public int fallBoundary=-20;

    void Update()
    {//checking the position of the player and applying 99999 damage to kill the player after falling
        if(transform.position.y<=fallBoundary)
        {
            DamagePlayer(99999);
        }
    }

    //Creating a method that takes dmg as argument and kill the player when health reaches 0
    public void DamagePlayer(int damage)
    {
        playerstats.Health -= damage;
        if(playerstats.Health<=0)
        {//calling the killplayer from gamemaster and will be sent as argument
            GameMaster.KillPlayer(this);
        }
    }

}
