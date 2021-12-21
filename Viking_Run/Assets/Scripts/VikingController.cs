using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

//[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Collider))]
public class VikingController : MonoBehaviour
{
    public Vector3 MovingDirection;
    public float JumpingForce;

    //MeshRenderer mr;
    Rigidbody rb;
    Animator animator;
    NavMeshAgent agent;
    RaycastHit raycastHit;
    [SerializeField] float movingSpeed = 10f;
    bool onGround = false, run = false;
    void Awake()
    {
        //Debug.Log("Awake");
    }
    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log("Start");
        // Transform t = GetComponent<Transform>();
        //t.position = Vector3.one;
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        transform.position = Vector3.one;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("Update");
        //transform.localPosition += movingSpeed * Time.deltaTime * MovingDirection;
        //mr.material.color = new Color((int)Time.time % 2 * 255f, 255f, 255f);
        run = false;
        if (Input.GetKey(KeyCode.W))
        {
            transform.localPosition += movingSpeed * Time.deltaTime * Vector3.forward;
            run = true;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            transform.localPosition += movingSpeed * Time.deltaTime * Vector3.back;
            run = true;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            transform.localPosition += movingSpeed * Time.deltaTime * Vector3.left;
            run = true;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.localPosition += movingSpeed * Time.deltaTime * Vector3.right;
            run = true;
        }
        animator.SetBool("Run", run);
        if (onGround && Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(JumpingForce * Vector3.up); //Time.deltaTime *
        }
        if (Input.GetMouseButtonDown(0))//0 left click
        {
            //2D to 3D
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out raycastHit))
            {
                if(raycastHit.transform.name.Contains("Viking_Shield"))
                    Destroy(raycastHit.transform.gameObject);
                //agent.SetDestination(raycastHit.point);
            }
        }
        /*if (Input.GetMouseButtonDown(1))//1 right click
        {
            //2D to 3D
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out raycastHit))
            {
                //if (raycastHit.transform.name.Contains("Viking_Shield"))
                //    Destroy(raycastHit.transform.gameObject);
                agent.SetDestination(raycastHit.point);
            }
        }*/
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.name == "big_module_01_floor")
        {
            onGround = true;
        }
    }
    //void OnCollisionStay()
    void OnCollisionExit(Collision collision)
    {
        if (collision.transform.name == "big_module_01_floor")
        {
            onGround = false;
        }
    }
}
