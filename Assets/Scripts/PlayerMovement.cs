using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] private float moveSpeed = 2f;
    private Rigidbody2D rb;
    private bool flipped;

    private Vector2 movementDirection;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        flipped = false;
    }

    // Update is called once per frame
    void Update()
    {
        movementDirection = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        CheckFlip();

        if (flipped)
        {
            this.transform.rotation = Quaternion.Euler(new Vector3(0f, 180f, 0f));
        }
        else
        {
            this.transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, 0f));
        }


    }

    private void FixedUpdate()
    {
        {
            rb.velocity = movementDirection * moveSpeed;
        }
    }

    private void CheckFlip()
    {
        if (movementDirection.x < 0)
        {
            flipped = true;
        }
        else if (movementDirection.x > 0)
        {
            flipped = false;
        }
    }
}
