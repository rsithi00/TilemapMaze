using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    private float moveSpeed;
    private Rigidbody2D rb;
    private bool flipped;

    public Vector3 home;

    [SerializeField] private GameObject target;

    private Vector2 movementDirection;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        home = rb.position;
        flipped = false;
        moveSpeed = 5f;
    }

    // Update is called once per frame
    void Update()
    {

        if(Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }

        movementDirection = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        if (movementDirection.x > 0)
        {
            movementDirection.x = 1;
        }
        else if (movementDirection.x < 0)
        {
            movementDirection.x = -1;
        }
        else
        {
            movementDirection.x = 0;
        }

        if (movementDirection.y > 0)
        {
            movementDirection.y = 1;
        }
        else if (movementDirection.y < 0)
        {
            movementDirection.y = -1;
        }
        else
        {
            movementDirection.y = 0;
        }

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
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Target"))
        {
            moveSpeed = 0f;
            Invoke("ReturnHome", 2f);
        }
    }

    void ReturnHome()
    {
        
        transform.position = new Vector3(home.x, home.y);
        moveSpeed = 5f;
        this.gameObject.layer = 21;
    }


}
