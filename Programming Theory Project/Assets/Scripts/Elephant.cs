using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class Elephant : Animal
{
    const float elephantSpeed = 2000.0f;
    const float elephantJumpPower = 250.0f;
    const float elephantMaximumSpeed = 14000;
    const float elephantJumpWaitTime = 0.2f;
    float timer = 0;
    //const float elephantJumpForwardMultiplier = 2;
    public AudioClip elephantVoice;


    private void Start()
    {
        playerRb = GetComponent<Rigidbody>(); // automatically calls the setter
        speed = elephantSpeed;
        jumpPower = elephantJumpPower;
        maximumSpeed = elephantMaximumSpeed;
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = elephantVoice;
        // set the voice
        //
    }

    protected override void Move() //overriden to include new stomp functionality while other classes use basic version
    {
        if (isOnGround)
        {
            if (isInsideBounds())
            {
                playerRb.AddRelativeForce(Vector3.forward * speed * verticalInput); // they will have different speeds
            }
            transform.Rotate(Vector3.up, horizontalInput * rotationSpeed);
            Stomp();
        }
    }


    protected override void Jump()
    {
        playerRb.velocity = Vector3.zero; // prepares for jump
        StartCoroutine(StopAndJump());
    }
    protected override void GiveVoice()
    {
        audioSource.Play();
    }
    IEnumerator StopAndJump()
    {
        yield return new WaitForSeconds(elephantJumpWaitTime);
        playerRb.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
        playerRb.AddRelativeForce(Vector3.forward * jumpPower, ForceMode.Impulse); // Pushes frog forward
    }
    private void Stomp()
    {
        timer += Time.deltaTime;
        if (timer > 0.5f && isOnGround) { playerRb.velocity = Vector3.zero; timer = 0; }
    }
}
