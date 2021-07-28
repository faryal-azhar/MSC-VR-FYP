using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ColorActivity
{
    public class Buckets : MonoBehaviour
    {
        public Bucket[] buckets;
        public Door door;
        public AudioSource winningAudio;
        public GameObject infoBoard;
        public ColorManager colorManager;

        public void DestroyBuckets()
        {
            foreach (Bucket bucket in buckets)
            {
                bucket.DestroyBucket();
            }
            Destroy(infoBoard.gameObject);
            door.UnlockDoor();
            winningAudio.Play();
            colorManager.Destroy();
            Destroy(gameObject);
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
}
