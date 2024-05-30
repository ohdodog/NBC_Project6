using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpMushroom : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.layer == 6)
        {
            collision.rigidbody.AddForce(Vector2.up * 300, ForceMode.Impulse);
        }
    }
}
