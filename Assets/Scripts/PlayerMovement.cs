using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public float jumpforce;
    private Rigidbody2D rb;
    public bool isgrounded;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D> ();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "ground")
        {
            isgrounded = true;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.collider.tag == "ground")
        {
            isgrounded = false;
        }
    }
    void FixedUpdate()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        Vector2 movevect = new Vector2(x, y);
        rb.AddForce(movevect * speed, ForceMode2D.Impulse);

        if (Input.GetKeyDown(KeyCode.Space) && isgrounded)
        {
            rb.AddForce(new Vector2(0, jumpforce), ForceMode2D.Impulse);
        }
    }

}