using System.Timers;
using UnityEngine;

public class Platform : MonoBehaviour
{
    private float timer;
    private Rigidbody rb;
    [SerializeField] Vector3 movementDirection;
    [SerializeField] private float movementSpeed;
    [SerializeField] float timeComeBack;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
      rb = GetComponent<Rigidbody>(); 
      
      
    }

    // Update is called once per frame
    void Update()
    {
        rb.linearVelocity = movementDirection * movementSpeed;
        timer += Time.deltaTime;
        if (timer >= timeComeBack)
        {
            movementDirection *= -1;
            timer = 0;
        }
    }
    
}
