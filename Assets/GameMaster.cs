using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour
{
    //Creating a singleton pattern to make sure that we only have one instance of a class in any given scene
    //Created a static variable gm and set it to the instance of the gamemaster class if not already set
    public static GameMaster gm;
    void Start()
    {
        if (gm == null)
        {
            gm = GameObject.FindGameObjectWithTag("Gm").GetComponent<GameMaster>();
        }
    }

    //Respawn method 
    //creating 2 public transforms to instatiate the prefab on the needed position with a delay of 2 seconds
    public Transform playerPrefab;
    public Transform spawnPoint;
    public float spawnDelay = 2f;

    public Transform spawnPrefab;

    //Whenever we use yield we need to use IEnumerator and use StartCoroutine whenever we want to call the method
    public IEnumerator RespawnPlayer()
    {   
        //play the audio added in the gamemaster object in unity editor
        GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(spawnDelay);
        Instantiate(playerPrefab, spawnPoint.position, spawnPoint.rotation);
        //make a temporary reference for our spawnprefab and destroy it after 3s
        //cast spawnclone as Transform
        //Destroy spawnclone.gameObject
        Transform spawnclone=(Transform)Instantiate(spawnPrefab, spawnPoint.position, spawnPoint.rotation);
        Destroy(spawnclone.gameObject, 3f);
        
    }
    //public static so we can kill it everywhere and it take the player class as argument
    public static void KillPlayer(Player player)
    {
        Destroy(player.gameObject);
        gm.StartCoroutine(gm.RespawnPlayer());
    }

   
}
