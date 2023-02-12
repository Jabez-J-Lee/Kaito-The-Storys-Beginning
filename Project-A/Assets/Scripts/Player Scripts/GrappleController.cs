using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrappleController : MonoBehaviour
{
    [Header("Grapple Components")]
    [SerializeField] private Camera mainCamera;
    [SerializeField] private Transform centerPoint;
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject grapplePrefab;
    [SerializeField] private GameObject grapple;
    //[SerializeField] private DistanceJoint2D ropeJoint;
    //[SerializeField] private SpringJoint2D springJoint;
    //[SerializeField] private LineRenderer ropeLR;
    [SerializeField] private float reelSpeed = 0.01f;
    [SerializeField] private bool isArmored = false;

    private Vector2 mousePos;
    private Vector2 direction;
    private Vector2 playerPos;

    public bool isGrappled = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        playerPos = centerPoint.GetComponentInParent<Transform>().position;
        mousePos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        PivotFirePoint(mousePos);

        direction = firePoint.rotation * Vector2.right;

        if (isArmored)
        {
            ShootGrapple();
        }
        else
        {
            ThrowGrapple();
        }

        //if (isGrappled)
        //{
        //    ropeJoint.distance -= reelSpeed;
        //    ropeLR.SetPosition(0, playerPos);
        //    ropeLR.SetPosition(1, grapple.transform.position);
        //}
    }
    private void FixedUpdate()
    {

    }

    private void PivotFirePoint(Vector2 mouse)
    {
        Vector3 distanceVector = mouse - (Vector2)centerPoint.position;
        float angle = Mathf.Atan2(distanceVector.y, distanceVector.x) * Mathf.Rad2Deg;

        centerPoint.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }

    public void ThrowGrapple()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            grapple = Instantiate(grapplePrefab, firePoint.position, firePoint.rotation);
        }
    }

    public void ShootGrapple()
    {
        if (Input.GetButtonDown("Fire1") && isArmored)
        {
            RaycastHit2D hit = Physics2D.Raycast(firePoint.position, direction,
                Mathf.Infinity, LayerMask.GetMask("Ground"));
            Debug.Log(hit.transform);

            if (hit.collider != null)
            {
                grapple = Instantiate(grapplePrefab, hit.point, Quaternion.identity);
                isGrappled = true;

                //ropeJoint = grapple.GetComponent<DistanceJoint2D>();
                //ropeJoint.connectedBody = GetComponentInParent<Rigidbody2D>();

                //springJoint = grapple.GetComponent<SpringJoint2D>();
                //springJoint.connectedBody = GetComponentInParent<Rigidbody2D>();

                //ropeLR = grapple.GetComponent<LineRenderer>();
            }
        }
        else if (Input.GetButtonUp("Fire1") && isArmored)
        {
            if (isGrappled)
            {
                Destroy(grapple.gameObject);
                isGrappled = false;
            }
        }
    }
}
