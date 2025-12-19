using System;
using Unity.Cinemachine;
using UnityEngine;
using Random = System.Random;

public class Ball : MonoBehaviour
{
    
    public float hInput;
    public float vInput;
    public int ballSize = 1;
    public float impulseForce;
    public bool isDead = false;
    
    private Vector3 InteractionPoint;
    private int jumpSoundSelected;
    private Rigidbody rb;
    private AudioSource audioSource;
    private Vector3 gluttony;
    
    
    [SerializeField] float InteractionRadius;
    [SerializeField] private float movementForce= 5f;
    [SerializeField] private AudioClip [] jumpSound;
    [SerializeField] GameObject Rat;
    [SerializeField] GameObject RatObjective;
    [SerializeField] MeshRenderer ballMesh;
    [SerializeField] Material ballMaterial;
    [SerializeField] Material oilMaterial;
    [SerializeField] Rat ratScript;
    [SerializeField] Timer timerScript;
    [SerializeField] GameObject DeathUI;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb =GetComponent<Rigidbody>();
        //TO SET FRAME RATE: Application.targetFrameRate = 10;
    }

    // Update is called once per frame
    void Update() //Inputs ALWAYS called through the Update Method
    {
        
        Rat.transform.position = 0.04f*Vector3.up + gluttony + transform.position;
        
        //transform.
        //GetComponent<Rigidbody>().AddForce(new Vector3(0,0,1) * 5,ForceMode.Force);
        
        //we put the jump here because it's a MOMENTARY MOVEMENT not CONSTANT
        
        vInput=Input.GetAxisRaw("Vertical");
        hInput=Input.GetAxisRaw("Horizontal");
        if (timerScript.prettyTimer < 0.1 || ballSize < 1)
        {
            vInput=0;
            hInput=0;
            isDead = true;
            ratScript.RatDeath();
            DeathUI.SetActive(true);
        }
        if (Input.GetKeyDown(KeyCode.Space)&&isDead==false)
        {
            if (Physics.Raycast(transform.position, Vector3.down, transform.localScale.y + 0.1f))
            {
                ratScript.RatJump();
                //int jumpSoundSelected = UnityEngine.Random.Range(0,3);
                //AudioManager.instance.PlaySFX(jumpSound[jumpSoundSelected]);
                rb.AddForce(Vector3.up * movementForce,ForceMode.Impulse);
            }

            
        }
        if (Input.GetKeyDown(KeyCode.E)&&isDead==false)
        {
            InteractionPoint = transform.position+ Vector3.forward*0.2f;
            Collider[] results =Physics.OverlapSphere(InteractionPoint, InteractionRadius);
            if (results.Length > 0) // if I detect at least one collider
            {
                //read one by one
                foreach (Collider result in results)
                {
                    //asking for the tag "Button"
                    /*
                     * if (result.gameObject.CompareTag("Button")
                     * {
                     * result.gameObject.GetComponent<Button>().OpenDoor();
                     * }
                     */
                    //ask if it has the right component
                    if (result.gameObject.TryGetComponent(out Button button))
                    {
                        result.gameObject.GetComponent<Button>().OpenDoor();
                    }
                }
            }
        }
        if (Input.GetKeyDown(KeyCode.Q)&&isDead==false)
        {
            VolumeLoss();
            ratScript.RatRoll();
            rb.AddForce(RatObjective.gameObject.transform.forward * impulseForce,ForceMode.Impulse);
            
        }
    }
    
    //Every 0.02 Seconds, It's meant to work with constant forces
    private void FixedUpdate()
    {
        if (isDead == false)
        {
            rb.AddForce(new Vector3(hInput, 0, vInput).normalized * movementForce);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Coin"))
        {
            transform.localScale += new Vector3(0.05f,0.05f,0.05f);
            gluttony+=new Vector3(0,0.025f,0);
            rb.mass += 0.3f;
            Destroy(other.gameObject);
            ratScript.RatFlip();
            ballSize++;
        }
        if (other.gameObject.CompareTag("oil"))
        {
            ratScript.oiledRat();
        }
        if (other.gameObject.CompareTag("saw"))
        {
            VolumeLoss();
        }
        
    }
    //its executed automatically
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.aquamarine;
        Gizmos.DrawWireSphere(InteractionPoint,InteractionRadius);
    }

    private void OnCollisionEnter(Collision collision)
    {
            int jumpSoundSelected = UnityEngine.Random.Range(0,3);
            AudioManager.instance.PlaySFX(jumpSound[jumpSoundSelected]);
            if (gameObject.CompareTag("oil"))
            {
                ballMesh.material = oilMaterial;
                ratScript.oiledRat();
            }
            

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("oil"))
        {
            ballMesh.material = ballMaterial;
            ratScript.cleanRat();
        } 
    }

    private void VolumeLoss()
    {
        transform.localScale -= new Vector3(0.05f, 0.05f, 0.05f);
        gluttony -= new Vector3(0, 0.025f, 0);
        rb.mass -= 0.3f;
        ratScript.RatHurt();
        ballSize--;
    }
}
