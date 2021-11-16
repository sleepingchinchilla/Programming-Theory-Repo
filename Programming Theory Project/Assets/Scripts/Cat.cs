using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class Cat : Animal
{
    const float catSpeed = 200.0f;
    const float catJumpPower = 40.0f;
    const float catMaximumSpeed = 400;
    const float catJumpWaitTime = 1;
    const float catJumpForwardMultiplier = 3;
    public AudioClip catVoice;


    private void Start()
    {
        playerRb = GetComponent<Rigidbody>(); // automatically calls the setter
        speed = catSpeed;
        jumpPower = catJumpPower;
        maximumSpeed = catMaximumSpeed;
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = catVoice;
        // set the voice 
    }


    protected override void Jump()
    {
        playerRb.velocity = Vector3.zero; // cat prepares for jump
        StartCoroutine(StopAndJump());
    }
    protected override void GiveVoice()
    {
        audioSource.Play();
    }
    IEnumerator StopAndJump()
    {
        yield return new WaitForSeconds(catJumpWaitTime);
        playerRb.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
        playerRb.AddRelativeForce(Vector3.forward * jumpPower * catJumpForwardMultiplier, ForceMode.Impulse); // Pushes frog forward
    }
}
