using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTile : MonoBehaviour
{
    public GameObject tileToSpawn;
    public GameObject referenceObject;
    public GameObject crossbarX;
    public GameObject crossbarZ;
    public GameObject coin;
    public float timeOffset = 0.4f;
    public float distanceBetweenTiles = 5.0F;
    public float randomValue = 0.8f;
    private Vector3 previousTilePosition;
    private float startTime;
    private Vector3 direction, mainDirection = new Vector3(0, 0, 1), right = new Vector3(1, 0, 0), left = new Vector3(-1, 0, 0);
    private bool isHole = false, isBar = false, straight = true;
    private int count = 0;
    Vector3 coinPos;
    Vector3 spawnPos;
    void Start()
    {
        previousTilePosition = referenceObject.transform.position;
        startTime = Time.time;
        direction = mainDirection;
    }

    void Update()
    {
        if (Time.time - startTime > timeOffset)
        {

            if (Random.value > randomValue && !isBar && !isHole && count >= 3)
            {
                count = 0;
                straight = false;
                if (direction == mainDirection)
                {
                    if (Random.value < 0.5)
                    {
                        direction = right;
                        coinPos = new Vector3(0, 0, 3);
                    }

                    else
                    {
                        direction = left;
                        coinPos = new Vector3(0, 0, 3);
                    }

                }
                else if (direction == right)
                {
                    direction = mainDirection;
                    
                }
                else if (direction == left)
                {
                    direction = mainDirection;
                    
                }
                //Vector3 temp = direction;
                //direction = otherDirection;
                //otherDirection = temp;
                //mainDirection = direction;
                //if (Random.value < 0.5)
                //{
                   
                //}
                //else
                //{
                //    coinPos = new Vector3(-3, 0, 0);
                //}
            }
            else
            {
                straight = true;
                count++;
            }

            startTime = Time.time;
            if (!isHole && !isBar && straight && Random.value > 0.95 && count >= 3)
            {
                //do nothing
                isHole = true;
                count = 0;
            }
            else
            {
                spawnPos = previousTilePosition + distanceBetweenTiles * direction;
                Instantiate(tileToSpawn, spawnPos, Quaternion.Euler(0, 0, 0));
                //GameObject temp = Instantiate(coin, transform);
                //GameObject temp = GameObject.FindGameObjectWithTag("coin");

                Instantiate(coin, spawnPos+coinPos, Quaternion.Euler(0, 0, 0));
                isHole = false;
                if (Random.value < 0.2 && straight && count >= 3)
                {
                    isBar = true;
                    count = 0;
                    if (direction == mainDirection)
                        Instantiate(crossbarX, spawnPos, Quaternion.Euler(0, 0, 0));
                    else
                        Instantiate(crossbarZ, spawnPos, Quaternion.Euler(0, 0, 0));
                }
                else
                    isBar = false;

            }
            previousTilePosition = spawnPos;
        }
    }
}