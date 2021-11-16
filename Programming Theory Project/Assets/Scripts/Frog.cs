using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// INHERITANCE
class Frog : Animal
{
    const float frogSpeed = 40.0f;
    const float frogJumpPower = 20.0f;
    const float frogMaximumSpeed = 80;
    public AudioClip frogVoice;


    private void Start()
    {
        playerRb = GetComponent<Rigidbody>(); // automatically calls the setter
        speed = frogSpeed;
        jumpPower = frogJumpPower;
        maximumSpeed = frogMaximumSpeed;
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = frogVoice;
        // set the voice to frog voice
    }

    // POLYMORPHISM
    protected override void Jump()
    {
        playerRb.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
        playerRb.AddRelativeForce(Vector3.forward * jumpPower, ForceMode.Impulse); // Pushes frog forward
    }
    protected override void GiveVoice()
    {
        audioSource.Play();
    }


}
