using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(B_Color))]
public class Bucket : MonoBehaviour
{
    [SerializeField] int maxBlocks=3;
    public List<Blocks> collidingBlocks;
    public ParticleSystem VFX;
    bool bucketFull = false;

    static int completedBucket = 0;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<B_Color>().color == GetComponent<B_Color>().color) // to see if the color of block is same as bucket
        {
            collidingBlocks.Add(other.GetComponent<Blocks>());
            CheckBucketFull();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<B_Color>().color == GetComponent<B_Color>().color) // to see if the color of block is same as bucket
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
           Destroy(block.gameObject); //Check
        }
    }

}
