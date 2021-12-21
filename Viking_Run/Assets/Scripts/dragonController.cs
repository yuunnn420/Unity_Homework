using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dragonController : MonoBehaviour
{
    // Start is called before the first frame update
    private Animator animator;
    private bool iscatch = false;
    void Start()
    {
        //transform.localPosition -= new Vector3(0, 0, 15);
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!iscatch)
        {
            transform.localPosition = new Vector3(0, 0, -20f);
            if (transform.position.y > 0.0f)
            {
                transform.position = new Vector3(transform.position.x, 0, transform.position.z);
            }
        }
    }
    public void catchPlayer()
    {
        iscatch = true;
        transform.localPosition = new Vector3(0,0,-2);
        animator.Play("Claw Attack"); 
    }
}
