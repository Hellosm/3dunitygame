using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public float jumpforce;
    private Rigidbody2D rb;
    public bool isgrounded;
    public PhysicsMaterial2D ground;

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
    void Update()
    {
        ground.friction = 0;
        float x = Input.GetAxis("Horizontal");

        Vector2 movevect = new Vector2(x, 0);
        rb.MovePosition(rb.position + movevect * speed * Time.deltaTime);


        if (Input.GetKeyDown(KeyCode.Space) && isgrounded)
        {
            isgrounded = false;
            rb.AddForce(new Vector2(0, jumpforce), ForceMode2D.Impulse);
        }
    }

}