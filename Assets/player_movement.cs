using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_movement : MonoBehaviour
{
    public float speed = 0.2f;
    public float stop = 0.0f;
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {

    }
    [SerializeField] int angleOffset;
    // Update is called once per frame
    void Update()
    {
        animator.SetFloat("speed", stop);
        if (Time.timeScale == 1)
        { 
            if (Input.GetKey("a"))  
            {
                transform.position += Vector3.left * speed;
                animator.SetFloat("speed", speed);
            }
            if (Input.GetKey("d"))
            {
                transform.position += Vector3.right* speed;
                animator.SetFloat("speed", speed);
            }
            if (Input.GetKey("w"))
            {
                transform.position += Vector3.up* speed;
                animator.SetFloat("speed", speed);
            }
            if (Input.GetKey("s"))
            {
                transform.position += Vector3.down* speed;
                animator.SetFloat("speed", speed);
            } 
            //Mouse look source.
            //https://nickhwang.com/2020/04/16/unity-tutorial-quick-tip-2d-look-at-mouse/
            var dir = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
            var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg + angleOffset;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            //Border to restrict inside camera view.
            //https://www.codegrepper.com/code-examples/csharp/unity+prevent+object+from+leaving+camera+view
            Vector3 pos = Camera.main.WorldToViewportPoint (transform.position);         
            pos.x = Mathf.Clamp01(pos.x);         
            pos.y = Mathf.Clamp01(pos.y);         
            transform.position = Camera.main.ViewportToWorldPoint(pos);
            } 
        if (Input.GetKey("p"))
        {
            if (Time.timeScale == 0)
            {
                Time.timeScale = 1;
            } 
            else
            {
                Time.timeScale = 0;
            }
        } 
    }
}
