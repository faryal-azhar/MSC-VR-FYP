using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static ColorActivity.B_Color;

namespace ColorActivity
{
    public class ColorManager : MonoBehaviour
    {
        List<BlockColor> selectedColors = new List<BlockColor>();
        [SerializeField] Button[] colorButtons;
        [SerializeField] Button startButton;
        Color[] buttonDefaultColors = new Color[9];
        [SerializeField] Bucket[] buckets;
        [SerializeField] GameObject colorBoard;
        [SerializeField] Blocks[] blocksColr1;
        [SerializeField] Blocks[] blocksColr2;
        [SerializeField] Blocks[] blocksColr3;

        private void Start()
        {
            for(int i = 0; i < colorButtons.Length; i++)
            {
                int index = i;
                buttonDefaultColors[i] = colorButtons[index].image.color;
                colorButtons[i].onClick.AddListener(delegate { SetColor(index); });
            }
            startButton.onClick.AddListener(StartColorActivity);
            startButton.image.enabled = false;
        }

        public void SetColor(int colorId)
        {
            BlockColor bColor = (BlockColor)colorId;

            if (selectedColors.Count < 3 && !selectedColors.Contains(bColor))
            {
                selectedColors.Add(bColor);
                colorButtons[colorId].GetComponent<Image>().color = Color.black;
            }
            else if (selectedColors.Contains(bColor))
            {
                selectedColors.Remove(bColor);
                colorButtons[colorId].GetComponent<Image>().color = buttonDefaultColors[colorId];
            }
            else if (selectedColors.Count >= 3)
            {
                Debug.Log("color limit reached");
            }
            if (selectedColors.Count == 3)
            {
                startButton.image.enabled = true;
            }
            else
            {
                startButton.image.enabled = false;
            }

        }

        private void StartColorActivity()
        {
            Destroy(colorBoard);
            for(int i = 0; i < buckets.Length; i++)
            {
                buckets[i].SetBucketColor(selectedColors[i]);
                buckets[i].gameObject.SetActive(true);
                blocksColr1[i].SetBlockColor(selectedColors[0]);
                blocksColr2[i].SetBlockColor(selectedColors[1]);
                blocksColr3[i].SetBlockColor(selectedColors[2]);
                blocksColr1[i].gameObject.SetActive(true);
                blocksColr2[i].gameObject.SetActive(true);
                blocksColr3[i].gameObject.SetActive(true);
            }
            Debug.Log("Start Color Activity");
        }

         public void Destroy()
        {
            Destroy(this.gameObject);
        }
    }
}
