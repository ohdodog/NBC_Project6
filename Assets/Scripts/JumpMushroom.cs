using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpMushroom : MonoBehaviour
{
    private int jumpPower = 500;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.layer == 6)
        {
            collision.rigidbody.AddForce(Vector2.up * jumpPower, ForceMode.Impulse);
        }
    }
}
