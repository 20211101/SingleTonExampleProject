using UnityEngine;

public class SimpleMovement : MonoBehaviour
{
    public Rigidbody rigidbody;


    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");
        rigidbody.linearVelocity = new Vector3(x, 0, z);
        rigidbody.angularVelocity = new Vector3(0, z, 0);
    }
}

