using UnityEngine;

public class PushingCylinder : MonoBehaviour

{
// Start is called once before the first execution of Update after the MonoBehaviour is createds
     [SerializeField] private float impulseForce = 500f;
     private Rigidbody rb;
    void Start()
    {
        rb=GetComponent<Rigidbody>();
        rb.AddTorque(Vector3.up*impulseForce,ForceMode.VelocityChange);
    }

    // Update is called once per frame
    void Update()
    {
        //transform.Rotate(Vector3.up * 180 *Time.deltaTime,Space.World);
    }
}
