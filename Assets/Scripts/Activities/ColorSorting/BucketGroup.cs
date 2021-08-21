using System.Linq;
using UnityEngine;

namespace KidsVR.Activities.ColorSorting
{
    // When every bucket is full the activity is done and the door opens.
    public class BucketGroup : MonoBehaviour
    {
        [SerializeField] private ColorBucket[] buckets;
        [SerializeField] private Door door;
        [SerializeField] private AudioSource winningAudio;
        [SerializeField] private GameObject infoBoard;
        [SerializeField] private ColorPicker colorPicker;

        private bool isComplete;

        private void OnEnable()
        {
            foreach (ColorBucket bucket in buckets)
            {
                bucket.FillChanged += CheckAllFull;
            }
        }

        private void OnDisable()
        {
            foreach (ColorBucket bucket in buckets)
            {
                bucket.FillChanged -= CheckAllFull;
            }
        }

        private void CheckAllFull()
        {
            if (isComplete || !buckets.All(bucket => bucket.IsFull)) return;

            isComplete = true;
            foreach (ColorBucket bucket in buckets)
            {
                bucket.Complete();
            }

            Destroy(infoBoard);
            Destroy(colorPicker.gameObject);
            door.Unlock();
            winningAudio.Play();
            Destroy(gameObject);
        }
    }
}
