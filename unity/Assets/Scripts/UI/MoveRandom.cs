using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveRandom : MonoBehaviour
{

    private bool move = false;
    private float speed = 10f;
    private float wobble;
    private float spinnUp = 3.7f;
    private Vector3 scaleChange = new Vector3(0.01f, 0.01f, 0);
    public Image particles;


    private void Start()
    {
        wobble = speed / 10f;
        if (particles != null)
        {
            particles.gameObject.SetActive(false);
        }
    }

    public void StartMoving()
    {
        move = true;
        spinnUp = 3.7f;
    }

    void Update()
    {
        if (move)
        {
            if (spinnUp > 0)
            {
                spinnUp -= Time.deltaTime;
                Vector3 translation = Wobble();
                transform.Translate(translation);
            }
            else
            {

                Vector3 translation = GetRandomDirection();
                transform.Translate(translation);
                transform.localScale -= scaleChange;
                if (particles != null)
                {
                    particles.gameObject.SetActive(true);
                }
            }
        }
    }

    private Vector3 Wobble()
    {
        float x = UnityEngine.Random.Range(-wobble, wobble);
        float y = UnityEngine.Random.Range(-wobble, wobble);
        return new Vector3(x, y, 0);
    }

    private Vector3 GetRandomDirection()
    {
        float x = UnityEngine.Random.Range(-speed, 2 * speed);
        float y = UnityEngine.Random.Range(-speed, speed);
        return new Vector3(x, y, 0);
    }
}
