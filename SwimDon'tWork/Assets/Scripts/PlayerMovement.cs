using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(CapsuleCollider))]
[RequireComponent(typeof(Animator))]
public class PlayerMovement : MonoBehaviour
{

    [Header("Controls")]
    [SerializeField] float moveSpeed = 6f;
    [SerializeField] float turnspeed = 250;

    Animator anim { get; set; }
    Rigidbody rb { get; set; }

    [SerializeField]
    LayerMask floormask;

    [Header("Input")]
    [SerializeField] string horizontal = "Horizontal";
    [SerializeField] string vertical = "Vertical";

    [Header("Debug Info")]
    [SerializeField] Vector3 movement = Vector3.zero;
    [SerializeField] Vector3 eulerAngleVelocity = Vector3.zero;
    [SerializeField] float camRayLength = 100f;
     

    private void Awake()
    {
        //floorMask = LayerMask.GetMask("Floor");
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        movement = Vector3.zero;
    }

    private void DeltaMove(float h, float v)
    {
        //get input
        movement.Set(h, 0f, v);
        movement.Normalize();

        //apply speed
        movement *= (moveSpeed * Time.deltaTime);

        //apply to char
        rb.MovePosition(transform.position + movement);
    }

    //move legacy-style, forward and backward movements only, left and right turn the character
    private void LegacyDeltaMove(float h, float v)
    {
        //turn the character
        KeyTurning(h);

        //get forward input
        movement = transform.forward * v;
        movement.Normalize();

        //apply speed
        movement *= (moveSpeed * Time.fixedDeltaTime);

        //apply to char
        rb.MovePosition(transform.position + movement);
    }

    private void MouseTurning()
    {
        if (Physics.Raycast(
            Camera.main.ScreenPointToRay(Input.mousePosition),
            out RaycastHit floorhit,
            camRayLength,
            floormask.value))
        {
            Vector3 playerToMouse = floorhit.point - transform.position;
            playerToMouse.y = 0f;
            Quaternion newRotation = Quaternion.LookRotation(playerToMouse);
            rb.MoveRotation(newRotation);
        }
    }

    //Exercise 2: key turning
    private void KeyTurning(float h)
    {
        eulerAngleVelocity.Set(0, h, 0);
        eulerAngleVelocity *= turnspeed;

        Quaternion deltaRotation = Quaternion.Euler(eulerAngleVelocity * Time.fixedDeltaTime);
        rb.MoveRotation(rb.rotation * deltaRotation);
   
    }

    void Animating(float h, float v)
    {
        float magnitude = h + v;
        bool walking = ( h > 0.1f || h < -0.1f) || (v > 0.1f || v < -0.1f);
        anim.SetBool("IsWalking", walking);
    }

    private float h = 0, v = 0;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) ExitApp();
        h = Input.GetAxisRaw(horizontal); v = Input.GetAxisRaw(vertical);        

    }

    private void FixedUpdate()
    {
        LegacyDeltaMove(h, v);
        Animating(h, v);
    }

    private void ExitApp ()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
         Application.Quit();
#endif
    }
}
