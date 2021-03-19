using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bucket : MonoBehaviour
{
    enum BucketColor {
        Red,
        Green,
        Blue
    }

    [SerializeField] BucketColor bucketColor=0;
    [SerializeField] int maxBlocks=3;
    public List<Blocks> collidingBlocks;
    public ParticleSystem VFX;

    bool bucketFull = false;

    static int completedBucket = 0;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Blocks>().color.ToString()==bucketColor.ToString()) // to see if the color of block is same as bucket
        {
            collidingBlocks.Add(other.GetComponent<Blocks>());
            CheckBucketFull();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<Blocks>().color.ToString() == bucketColor.ToString()) 
        {
            collidingBlocks.Remove(other.GetComponent<Blocks>());
            CheckBucketFull();
        }
    }

    private void CheckBucketFull()
    {
        if (collidingBlocks.Count == maxBlocks)
        {
            bucketFull = true;
            completedBucket++;
            if (completedBucket == 3)
            {
                transform.parent.GetComponent<Buckets>().DestroyBuckets();
            }
        }
        else
        {
            if (bucketFull == true)
            {
                completedBucket--;
                bucketFull = false;
            }    
        }
    }

    public void DestroyBucket()
    {
        PlayVfx();
        DestroyBlocks();
        Destroy(this.gameObject);
    }

    private void PlayVfx()
    {
        var vfx = Instantiate(VFX, transform.position, Quaternion.identity); ;
        vfx.Play();
        Destroy(vfx.gameObject, vfx.main.duration);
    }

    private void DestroyBlocks()
    {
        foreach(Blocks block in collidingBlocks)
        {
            block.DestroyBlock();
        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
