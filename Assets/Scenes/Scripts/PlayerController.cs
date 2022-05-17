using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    public float speed = 2f;
    private Rigidbody rb;
    private Animator animator;
    [SerializeField]
    public float rotationSpeed = 10f;
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 directionVectror = new Vector3(horizontal, 0, vertical);
        
        if(directionVectror.magnitude > Mathf.Abs(0.05f))
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(directionVectror), Time.deltaTime * rotationSpeed);
        }
        
        animator.SetFloat("speed", Vector3.ClampMagnitude(directionVectror, 1).magnitude);
        rb.velocity = Vector3.ClampMagnitude(directionVectror,1) * speed ; 
    }
}
