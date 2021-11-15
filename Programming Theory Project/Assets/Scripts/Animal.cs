using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Animal : MonoBehaviour
{
    private float rotationSpeed = 0.2f;
    private int XBoundary = 5;
    private int ZBoundary = 2;
    //protected CharacterController controller { set; get; }
    protected AudioClip voice { set; get; }
    protected AudioSource audioSource { set; get; }
    protected Rigidbody playerRb { set; get; }
    protected float speed { set; get; }
    protected float jumpPower { set; get; }
    protected Color color { set; get; }

    protected float maximumSpeed { set; get; }

    private string playerName { set; get; }

    protected bool isOnGround { set; get; }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround) // when space clicked, jump
        {
            isOnGround = false;
            Jump();
        }
        Move(); // check if keyboard buttons up or down was pushed and move
        checkForMaximumSpeed(); // breaks if object moves too fast
        forceBounds(); // check if inside the board
    }

    protected abstract void Jump(); // different ways of jumping? different mechanics?
    protected abstract void GiveVoice(); // different ways of giving voice? animation and sound

    private void OnMouseDown() // give voice when clicked
    {
        GiveVoice();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
        }
    }

    private bool isInsideBounds()
    {
        bool insideXBounds = transform.position.x <= XBoundary && transform.position.x >= -XBoundary;
        bool insideYBounds = transform.position.z <= ZBoundary && transform.position.z >= -ZBoundary;

        if (insideXBounds)
        {
            if (insideYBounds)
            {
                return true;
            }
        }
        return false;
    }

    private void forceBounds()
    {
        if (transform.position.x > XBoundary)
        {
            transform.position = new Vector3(XBoundary, transform.position.y, transform.position.z);
        }
        else if (transform.position.x < -XBoundary)
        {
            transform.position = new Vector3(-XBoundary, transform.position.y, transform.position.z);
        }
        if (transform.position.z > ZBoundary)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, ZBoundary);
        }
        else if (transform.position.z < -ZBoundary)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -ZBoundary);
        }
    }

    protected void Move()
    {
        if (isOnGround)
        {
            if (isInsideBounds())
            {
                playerRb.AddRelativeForce(Vector3.forward * speed * Input.GetAxis("Vertical")); // they will have different speeds
            }
            transform.Rotate(Vector3.up, Input.GetAxis("Horizontal") * rotationSpeed);
        }
    }

    private void checkForMaximumSpeed()
    {
        float currentSpeed = Vector3.Magnitude(playerRb.velocity); // getting current speed from player
        if (currentSpeed > maximumSpeed)
        {
            float breakSpeed = currentSpeed - maximumSpeed; // calculates how much we need to break
            Vector3 normalizedVelocity = playerRb.velocity.normalized; // direction to break
            Vector3 brakeVelocity = normalizedVelocity * breakSpeed; // creating break vector
            playerRb.AddForce(-brakeVelocity); // Applied breaks on object by using opposite force (why not relativeForce?)
        }
    }



}
