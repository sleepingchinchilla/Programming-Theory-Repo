using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class Frog : Animal
{
    const float frogSpeed = 2.0f;
    const float frogJumpPower = 20.0f;
    const float frogMaximumSpeed = 4;
    
    private void Start()
    {
        playerRb = GetComponent<Rigidbody>(); // automatically calls the setter
        speed = frogSpeed;
        jumpPower = frogJumpPower;
        maximumSpeed = frogMaximumSpeed;
        // set the voice to frog voice
    }


    protected override void Jump()
    {
        playerRb.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
        playerRb.AddRelativeForce(Vector3.forward * jumpPower, ForceMode.Impulse); // Pushes frog forward
    }
    protected override void GiveVoice()
    {
        audioSource.PlayOneShot(voice);
    }


}
