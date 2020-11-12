using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public float firerate = 0f;
    public float damage = 10;
    public LayerMask whatToHit;
    public float spawnrate=10;
    float timeToSpawn = 0.0f;
    float timeToFire = 0;
    Transform firePoint;

    public Transform bulletTrailPrefab;
    public Transform MuzzleFlashPrefab;
  void Awake()
    {
        firePoint = transform.Find("FirePoint");
        if(firePoint==null)
        {
            Debug.LogError("No Firepoint?");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (firerate == 0)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                Shoot();
                
            }
        }
        else
        {
            if (Input.GetButton("Fire1") && Time.time > timeToFire)
            {
                timeToFire = Time.time + 1 / firerate;
                Shoot();
            }
        }
        void Shoot()
        {
            //Debug.Log("Shoot");
            //Storing the position of the mouse into a vector2 variable
            Vector2 mousePosition = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
            //Storing the position of the firepoint
            Vector2 firePointPosition = new Vector2(firePoint.position.x, firePoint.position.y);

            RaycastHit2D Hit = Physics2D.Raycast(firePointPosition, mousePosition - firePointPosition,100,whatToHit);
           //spawning a limited number of bullets in time
            if (Time.time >= timeToSpawn)
            {
                Effect();
                timeToSpawn = Time.time + 1 / spawnrate;
            }
            //Enable Gizmos and use the following Debug.Drawline to test the Raycast or the aim
           Debug.DrawLine(firePointPosition, (mousePosition-firePointPosition)*100,Color.cyan);
            if(Hit.collider!=null)
            {
                Debug.DrawLine(firePointPosition, Hit.point, Color.red);
                Debug.Log("We Hit " + Hit.collider.name + "and did" + damage + "damage");
            }

        }

        void Effect()
        {
            //instantiating the bullet trail
            Instantiate(bulletTrailPrefab, firePoint.position, firePoint.rotation);
            //first store the instance of a transform in a clone to modifie gameobject not the wole prefab
            //then parent the clone to the firepoint to move accordingly
            //then create a size variable and use it to scale the clone so it's size wld be random
            //finally destroy the clone gameobject
            Transform clone = (Transform)Instantiate(MuzzleFlashPrefab,firePoint.position, firePoint.rotation);
            clone.parent = firePoint;
            float size = Random.Range(0.6f, 0.9f);
            clone.localScale = new Vector3(size, size, size);
            Destroy(clone.gameObject,0.02f);
        }
    }
}   
