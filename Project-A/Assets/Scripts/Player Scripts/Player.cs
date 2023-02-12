using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Singleton Instantiation
    private static Player instance;
    public static Player Instance
    {
        get
        {
            if (instance == null)
            {
                instance = GameObject.FindObjectOfType<Player>();
            }
            return instance;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {

    }
}

/*
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Player Components")]
    [SerializeField] private GameObject player;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] public Animator animator;
    [SerializeField] private GrappleController grappleController;

    [Header("Player Attributes")]
    //[SerializeField] private float moveSpeed = 5f;
    //[SerializeField] private float jumpForce = 10f;
    //[SerializeField] private float defaultGravity = 10f;
    //[SerializeField] private float gravityScale = 10f;

    private float inputX;
    //private bool isJumping = false;
    private Vector3 vectorZero = Vector3.zero;

    // Singleton Instantiation
    private static Player instance;
    public static Player Instance
    {
        get
        {
            if (instance == null)
            {
                instance = GameObject.FindObjectOfType<Player>();
            }
            return instance;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        inputX = Input.GetAxisRaw("Horizontal"); //* moveSpeed;
        //animator.SetFloat("velocityX", Mathf.Abs(inputX));
        //animator.SetFloat("velocityY", rb.velocity.y);

        //animator.SetBool("isGrounded", PlayerSensor.Instance.isActive[4]);

        //if (Input.GetButtonDown("Jump") && PlayerSensor.Instance.isActive[4])
        //{
        //    isJumping = true;
        //    animator.SetBool("isJumping", isJumping);
        //}

        //PlayerSpriteController();
    }

    private void FixedUpdate()
    {
        Vector3 targetVelocity = new Vector2(inputX, rb.velocity.y);

        if (!grappleController.isGrappled)
        {
            rb.velocity = Vector3.SmoothDamp(rb.velocity,
                targetVelocity, ref vectorZero, 0.05f);
        }

        //if (isJumping)
        //{
        //    rb.velocity = new Vector2(inputX, jumpForce);
        //    //rb.AddForce(new Vector2(0f, jumpForce));
        //    rb.gravityScale += gravityScale * Time.deltaTime;
        //    isJumping = false;
        //    animator.SetBool("isJumping", isJumping);
        //}
        //else
        //{
        //    rb.gravityScale = defaultGravity;
        //}
    }

    private void PlayerSpriteController()
    {
        if (inputX < 0)
        {
            player.GetComponentInChildren<SpriteRenderer>().flipX = true;
        }
        else if (inputX > 0)
        {
            player.GetComponentInChildren<SpriteRenderer>().flipX = false;
        }
        else
        {
            player.GetComponentInChildren<SpriteRenderer>().flipX = player.GetComponentInChildren<SpriteRenderer>().flipX;
        }
    }
}
*/