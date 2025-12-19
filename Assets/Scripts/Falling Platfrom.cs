using Unity.Cinemachine;
using UnityEngine;

public class FallingPlatfrom : MonoBehaviour
{
    private Rigidbody rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision other)
    {
        //have to ask about the other tag
        //if it's the player then i have to put my rigidbody dynamic
        if (other.gameObject.CompareTag("Player"))
        {
            rb.isKinematic = false;
        }
        
    }
}
