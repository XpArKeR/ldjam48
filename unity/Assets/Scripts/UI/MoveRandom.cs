using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveRandom : MonoBehaviour
{

    private bool move = false;
    private float speed = 2f;
    private Vector3 scaleChange = new Vector3(0.01f, 0.01f, 0);


    public void StartMoving()
    {
        move = true;
    }

    void Update()
    {
        if (move)
        {
            transform.Translate(GetRandomDirection());
            transform.localScale -= scaleChange;
        }
    }

    private Vector3 GetRandomDirection()
    {
        float x = UnityEngine.Random.Range(-speed, 2*speed);
        float y = UnityEngine.Random.Range(-speed, speed);
        return new Vector3(x, y, 0);
    }
}
