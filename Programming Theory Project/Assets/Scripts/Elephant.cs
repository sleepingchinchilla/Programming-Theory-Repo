using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class Elephant : Animal
{
    const float elephantSpeed = 100.0f;
    const float elephantJumpPower = 150.0f;
    const float elephantMaximumSpeed = 700;
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
        // set the voice to frog voice
    }

    private void FixedUpdate()
    {
        Stomp();
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
