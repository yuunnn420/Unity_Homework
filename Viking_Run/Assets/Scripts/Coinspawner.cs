using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coinspawner : MonoBehaviour
{
    public Transform Coin;
    List<Transform> coinList;
    void Start()
    {
        coinList = new List<Transform>();
        for(int i = 0; i < 5; i++)
        {
            Transform t = Instantiate(Coin);
            Transform p = transform.GetChild((int)Random.Range(0,transform.childCount));
            t.parent = p;
            t.localPosition = Vector3.zero;
            //t.localPosition = p.localPosition;
            //t.position = p.position;
            coinList.Add(t);
        }
    }
    void Update()
    {
        
    }
}
