using UnityEngine;

public class Rat : MonoBehaviour
{
    
   [SerializeField] Animator ratAnimator;
    [SerializeField] Ball ball;
    [SerializeField] SkinnedMeshRenderer ratMesh;
    [SerializeField] Material ratMaterial;
    [SerializeField] Material oilMaterial;
    private bool isMoving = false;
    private Vector3 movementRatDirection ;
    private Timer timer;
   
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
     timer = FindObjectOfType<Timer>();
    }

    // Update is called once per frame
    void Update()
    {
        RotateRat();

        AnimationRat();
        
    }

    private void AnimationRat()
    {
        if (ball.hInput != 0 || ball.vInput != 0)
        {
            ratAnimator.SetBool("isMoving", true);
        }
        else
        {
            ratAnimator.SetBool("isMoving", false);
        }
    }
    private void RotateRat()
    {
        //sets the direction where the rat is moving so he can know where to look
        Vector3 movementRatDirection = new Vector3(ball.hInput, 0, ball.vInput).normalized;
        //this is to make the rat stay looking at the side i want
        if (movementRatDirection.magnitude > 0)
        {
            Quaternion targetRotation = Quaternion.LookRotation(movementRatDirection);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 10f);
        }
    }

    public void RatFlip()
    {
        ratAnimator.Play("Spin");
    }
    public void RatDeath()
    {
        ratAnimator.Play("Death");
    }

    public void RatJump()
    {
        ratAnimator.Play("Jump");
    }
    public void RatHurt()
    {
        ratAnimator.Play("Hit");
    }
    public void RatRoll()
    {
        ratAnimator.Play("Roll");
    }
    public void oiledRat()
    {
        ratMesh.material = oilMaterial;
    }

    public void cleanRat()
    {
        ratMesh.material = ratMaterial;
    }
    
}
