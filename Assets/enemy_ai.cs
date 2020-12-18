using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class enemy_ai : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Player;
    public GameObject enemyprefab;
    public Transform target; 
    public float speed = 1.0f;
    private Rigidbody2D rb;
    private int health;
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        health = 10;
        Time.timeScale = 1;
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
      if (collision.gameObject.tag == "bullet")
        {
            health -= 1;
            Destroy(collision.gameObject);
        }
      if (collision.gameObject.tag == "Player")
        {
            Destroy(collision.gameObject);
            Time.timeScale = 0;
            SceneManager.LoadScene ("Gameover");
        } 
      if (health == 0)
        {
            GameObject enemy = Instantiate(enemyprefab, new Vector3(Random.Range(-43.0f, -44.0f),Random.Range(-22.0f,20.0f),0.0f), Quaternion.identity);
            GameObject enemy1 = Instantiate(enemyprefab, new Vector3(Random.Range(43.0f, 44.0f),Random.Range(-22.0f,20.0f),0.0f), Quaternion.identity);
            Destroy(gameObject);
            Score.score += 1;
        }
    }
    // Update is called once per frame
    void Update()
    {
        target = GameObject.FindGameObjectWithTag ("Player").transform;
        transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        var dir = target.position - transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        rb.rotation = angle;
        
    }
}