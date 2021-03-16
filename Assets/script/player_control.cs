using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_control : MonoBehaviour
{
    public Rigidbody2D player_rb;
    private float x;
    private bool is_ground;
    public float speed = 5f;
    public float height = 50f;
    public bool faceright = true;
    public Animator player;
    //private Vector3 scaleChange, positionChange;
    public bool facingRight = true;
    void Update()
    {
        x = Input.GetAxis("Horizontal");
        if (x > 0 && !facingRight)
            Flip();
        else if (x < 0 && facingRight)
            Flip();
        player.SetFloat("Speed", Mathf.Abs(x));
        //scaleChange = new Vector3(-0.2260803f, 0, 0);
        //if (Input.GetKeyDown(KeyCode.A))
        //{
        //    transform.localScale = scaleChange;

        //}
        
        transform.Translate(transform.right * x * speed * Time.deltaTime);
        if (Input.GetKeyDown(KeyCode.Space) && is_ground == true)
        {
            player.SetBool("jump", true);
            player_rb.AddForce(Vector2.up * height);
            is_ground = false;
        }
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {

            player.SetTrigger("attack");
        }
    }
        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.tag == "floor")
            {
                player.SetBool("jump", false);
                is_ground = true;
            }
        }
    void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

}

