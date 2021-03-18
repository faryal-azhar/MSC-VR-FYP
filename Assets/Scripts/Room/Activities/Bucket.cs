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

    bool bucketFull = false;

   public int blocksContain = 0; //remove public later

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Blocks>().color.ToString()==bucketColor.ToString()) // to see if the color of block is same as bucket
        {
            blocksContain++;
            CheckBucketFull();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<Blocks>().color.ToString() == bucketColor.ToString()) 
        {
            blocksContain--;
            CheckBucketFull();
        }
    }

    private void CheckBucketFull()
    {
        if (blocksContain == maxBlocks)
        {
            bucketFull = true;
            Debug.Log(name + "bucket is full");
        }
        else
        {
            bucketFull = false;
        }
    }



    // Update is called once per frame
    void Update()
    {
        
    }
}
