using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet_shoot : MonoBehaviour
{
    public float speed = 10f;
    public bool facingRight = true;

    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        if (x > 0 && !facingRight)
            Flip();
        else if (x < 0 && facingRight)
            Flip();
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }
    void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
