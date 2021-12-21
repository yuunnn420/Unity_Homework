using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Coin : MonoBehaviour
{

    [SerializeField] float turnSpeed = 90f;

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.name == "Player")
        {
            //Destroy(gameObject);
        }
    }

    private void Start()
    {
        //transform.localPosition = new Vector3(0, 1, 0);
        transform.Rotate(-90, 0, 0);
    }

    private void Update()
    {
        transform.Rotate(0, 0,turnSpeed * Time.deltaTime);
    }
}