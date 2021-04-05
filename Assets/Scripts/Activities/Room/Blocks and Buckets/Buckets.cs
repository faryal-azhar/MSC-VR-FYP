using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buckets : MonoBehaviour
{
    public Bucket[] buckets;
    public AudioSource winningAudio;

    public void DestroyBuckets()
    {
        foreach(Bucket bucket in buckets)
        {
            bucket.DestroyBucket();
        }
        winningAudio.Play();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
