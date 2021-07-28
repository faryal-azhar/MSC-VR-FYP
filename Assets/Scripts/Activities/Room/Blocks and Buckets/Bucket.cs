using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static ColorActivity.B_Color;

namespace ColorActivity
{
    [RequireComponent(typeof(B_Color))]
    public class Bucket : MonoBehaviour
    {
        [SerializeField] int maxBlocks = 3;
        public List<Blocks> collidingBlocks;
        public ParticleSystem VFX;
        bool bucketFull = false;
        Color32 bucketColor;

        static int completedBucket = 0;

        private void Start()
        {
            gameObject.SetActive(false);
        }
        BlockColor bColor;
        public void SetBucketColor(BlockColor clr)
        {
            GetComponent<B_Color>().blockColor = clr;
            switch (clr)
            {
                case BlockColor.Blue://1
                    bucketColor = Color.blue;
                    break;
                case BlockColor.Red://2
                    bucketColor = Color.red;
                    break;
                case BlockColor.Pink://3
                    bucketColor = new Color32(255, 105, 180,255);
                    break;
                case BlockColor.Brown://4
                    bucketColor = new Color32(139, 69, 19,255);
                    break;
                case BlockColor.Purple://5
                    bucketColor = new Color32(128, 0, 128,255);
                    break;
                case BlockColor.Green://6
                    bucketColor = Color.green;
                    break;
                case BlockColor.Yellow://7
                    bucketColor = Color.yellow;
                    break;
                case BlockColor.Grey://8
                    bucketColor = Color.grey;
                    break;
                case BlockColor.Orange://9
                    bucketColor = new Color32(255, 165, 0,255);
                    break;

            }
            GetComponent<MeshRenderer>().material.color = bucketColor ;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.GetComponent<B_Color>().blockColor == GetComponent<B_Color>().blockColor) // to see if the color of block is same as bucket
            {
                collidingBlocks.Add(other.GetComponent<Blocks>());
                CheckBucketFull();
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.GetComponent<B_Color>().blockColor == GetComponent<B_Color>().blockColor) // to see if the color of block is same as bucket
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
            foreach (Blocks block in collidingBlocks)
            {
                Destroy(block.gameObject); //Check
            }
        }

    }

}