using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    RaycastHit hit;
    private Rigidbody playerRigidBody;
    private PlayerCollision playerCollision;
    private Animator animator;

    [SerializeField] private bool isFacingRight = true;
    [SerializeField] private LayerMask layerMask;
    [SerializeField] private float moveSpeed = 4f;
    [SerializeField] private float currentSpeed;
    [SerializeField] private float currentSpeedY;
    [SerializeField] private bool isGrounded = false;


    [Header("Jump")]
    [SerializeField] private float jumpForce = 3f;
    [SerializeField] private float doubleJumpForce = 3f;
    [SerializeField] private bool doubleJumpActive = false;

    public bool IsGrounded
    {
        get => isGrounded;
    }
    //[SerializeField] private bool isRunning = false;

    // Es llamado cuando se carga el script
    private void Awake()
    {
        // Accedemos al componente del Rigidbody
        playerRigidBody = GetComponent<Rigidbody>();
        // Accedemos al componente del PlayerCollision
        playerCollision = GetComponent<PlayerCollision>();
        // Accedemos al componente del Animator
        animator = GetComponent<Animator>();
    }

    //Detecta cuando dos objetos rígidos colisionan
    //private void OnCollisionEnter(Collision collision)
    //{
    //    isOnGround = true;
    //}

    //Detecta cuando dos objetos rígidos salen de la colisión
    //private void OnCollisionExit(Collision collision)
    //{
    //    isOnGround = false;
    //}    

    // Es la función que se ejecuta fotograma por fotograma
    void Update()
    {
        MoveRight();
        MoveLeft();

        //currentSpeed = Input.GetAxis("Horizontal");
        //animator.SetFloat("Speed", currentSpeed);
        currentSpeedY = playerRigidBody.velocity.y;
        animator.SetFloat("SpeedY", currentSpeedY);
        isGrounded = playerCollision.IsHittingBottom;
        animator.SetBool("isGrounded", isGrounded);

        Jump();
        //if (Input.GetKeyDown(KeyCode.A))
        //{
        //    Debug.Log("La tecla A fue presionada");
        //}

        //if (Input.GetKeyUp(KeyCode.A))
        //{
        //    Debug.Log("Se dejó de presionar la tecla A");
        //}
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.LeftArrow))
        {
            //isRunning = true;
            animator.SetBool("isRunning", true);
        }
        else
        {
            //isRunning = false;
            animator.SetBool("isRunning", false);
        }
    }

    private void MoveRight()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(-transform.right * moveSpeed * Time.deltaTime);

            if (!isFacingRight)
            {
                FlipRight();
            }
        }
    }

    private void MoveLeft()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(transform.right * moveSpeed * Time.deltaTime);

            if (isFacingRight)
            {
                FlipLeft();
            }
        }
    }

    private void FlipRight()
    {
        isFacingRight = true;
        transform.rotation = Quaternion.Euler(0, 90, 0);
    }

    private void FlipLeft()
    {
        isFacingRight = false;
        transform.rotation = Quaternion.Euler(0, 270, 0);
    }

    private void Jump()
    {
        if (doubleJumpActive)
        {
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow))
            {
                playerRigidBody.velocity = Vector3.zero;
                playerRigidBody.AddForce(transform.up * doubleJumpForce, ForceMode.Impulse);
                doubleJumpActive = false;
            }
        }
        if (isGrounded)
        {
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow))
            {
                playerRigidBody.AddForce(transform.up * jumpForce, ForceMode.Impulse);
                doubleJumpActive = true;
            }
        }
    }
}
