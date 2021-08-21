using System;
using System.Collections.Generic;
using UnityEngine;

namespace KidsVR.Activities.ColorSorting
{
    public class ColorBucket : ColoredObject
    {
        [SerializeField] private int blocksToFill = 3;
        [SerializeField] private ParticleSystem completeVfx;

        private readonly List<ColorBlock> blocksInside = new List<ColorBlock>();

        public event Action FillChanged;

        public bool IsFull => blocksInside.Count >= blocksToFill;

        private void OnTriggerEnter(Collider other)
        {
            var block = other.GetComponent<ColorBlock>();
            if (block == null || block.ColorType != ColorType || blocksInside.Contains(block)) return;

            blocksInside.Add(block);
            FillChanged?.Invoke();
        }

        private void OnTriggerExit(Collider other)
        {
            var block = other.GetComponent<ColorBlock>();
            if (block == null || !blocksInside.Remove(block)) return;

            FillChanged?.Invoke();
        }

        public void Complete()
        {
            ParticleSystem vfx = Instantiate(completeVfx, transform.position, Quaternion.identity);
            vfx.Play();
            Destroy(vfx.gameObject, vfx.main.duration);

            foreach (ColorBlock block in blocksInside)
            {
                Destroy(block.gameObject);
            }
            Destroy(gameObject);
        }
    }
}
