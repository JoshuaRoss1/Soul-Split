using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleLink : MonoBehaviour
{
    private ParticleSystem particles;
    public float moveSpeed = 5f;
    public float interval = 3f;
    public GameObject source;
    public GameObject target;
    private Vector2 start;
    private Vector2 end;
    private float currentTime = 0;
    //private float speedTime = 0;

    // Start is called before the first frame update
    void Start()
    {
        particles = gameObject.GetComponent<ParticleSystem>();
        start = source.transform.position;
        end = target.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentTime < interval)
        {
            currentTime += Time.deltaTime;
        }
        else
        {
            if (!particles.isPlaying)
            {
                particles.Play();
                start = source.transform.position;
                end = target.transform.position;
            }          
            if ((Vector2)transform.position != end)
            {
                transform.position = Vector2.MoveTowards(transform.position, end, moveSpeed * Time.deltaTime);
            }
            else
            {
                currentTime = 0;
                particles.Stop(true, ParticleSystemStopBehavior.StopEmittingAndClear);
                transform.position = start;
            }
        }
    }
}
