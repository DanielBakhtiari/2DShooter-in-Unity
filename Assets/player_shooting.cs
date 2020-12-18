using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_shooting : MonoBehaviour
{
    public Transform firepoint;
    public GameObject bulletprefab;
    public float bulletforce = 20f;
    public float cooldown = 0.0f;
    // Update is called once per frame
    void Update(){
        if (Time.timeScale == 1)
        {
            if (Input.GetMouseButtonDown(0)){
            shoot();
            }  
            //Burst shot
            if (cooldown < 0.1f)
            {
                if (Input.GetMouseButtonDown(1)){
                    shoot();
                    Invoke("shoot",0.10f);
                    Invoke("shoot",0.20f);
                    cooldown = 20.0f;
                }  
            }
            else
            {
                cooldown -= 0.25f;
            }
        }
        
    }
    void shoot(){
        GameObject bullet = Instantiate(bulletprefab, firepoint.position, firepoint.rotation);       
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firepoint.up * bulletforce, ForceMode2D.Impulse);
    }
}
