using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grapple : MonoBehaviour
{
    [Header("Grapple Components")]
    public Rigidbody2D rb;
    [SerializeField] private float speed = 20f;
    [SerializeField] private GrappleController grappleScript;
    [SerializeField] private LayerMask groundLayer;

    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * speed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == groundLayer)
        {
            Debug.Log(collision.gameObject.name);
            rb.bodyType = RigidbodyType2D.Static;
            grappleScript.isGrappled = true;
        }
    }
}
