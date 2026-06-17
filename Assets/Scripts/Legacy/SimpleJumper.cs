using UnityEngine;

public class SimpleJumper : MonoBehaviour
{
    public Rigidbody rigidbody;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rigidbody.AddForce(0, 1000, 0);
    }
}
