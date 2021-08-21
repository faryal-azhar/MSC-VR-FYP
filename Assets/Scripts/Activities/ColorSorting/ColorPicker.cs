using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace KidsVR.Activities.ColorSorting
{
    // Board where the kid picks three colors. Then the buckets and blocks get those colors.
    public class ColorPicker : MonoBehaviour
    {
        private const int ColorsToPick = 3;

        [SerializeField] private Button[] colorButtons;
        [SerializeField] private Button startButton;
        [SerializeField] private GameObject colorBoard;
        [SerializeField] private Color selectedButtonColor = Color.black;

        [Header("Objects to color")]
        [SerializeField] private ColorBucket[] buckets;
        [SerializeField] private ColorBlock[] firstColorBlocks;
        [SerializeField] private ColorBlock[] secondColorBlocks;
        [SerializeField] private ColorBlock[] thirdColorBlocks;

        private readonly List<BlockColor> selectedColors = new List<BlockColor>();
        private Color[] defaultButtonColors;

        private void Start()
        {
            defaultButtonColors = new Color[colorButtons.Length];
            for (int i = 0; i < colorButtons.Length; i++)
            {
                int index = i;
                defaultButtonColors[i] = colorButtons[i].image.color;
                colorButtons[i].onClick.AddListener(() => ToggleColor(index));
            }

            startButton.onClick.AddListener(StartSorting);
            UpdateStartButton();
            SetObjectsActive(false);
        }

        private void ToggleColor(int index)
        {
            var color = (BlockColor)index;

            if (selectedColors.Remove(color))
            {
                colorButtons[index].image.color = defaultButtonColors[index];
            }
            else if (selectedColors.Count < ColorsToPick)
            {
                selectedColors.Add(color);
                colorButtons[index].image.color = selectedButtonColor;
            }

            UpdateStartButton();
        }

        private void UpdateStartButton()
        {
            startButton.image.enabled = selectedColors.Count == ColorsToPick;
        }

        private void StartSorting()
        {
            Destroy(colorBoard);

            for (int i = 0; i < buckets.Length; i++)
            {
                buckets[i].SetColor(selectedColors[i]);
            }

            ColorBlock[][] blockGroups = { firstColorBlocks, secondColorBlocks, thirdColorBlocks };
            for (int i = 0; i < blockGroups.Length; i++)
            {
                foreach (ColorBlock block in blockGroups[i])
                {
                    block.SetColor(selectedColors[i]);
                }
            }

            SetObjectsActive(true);
        }

        private void SetObjectsActive(bool isActive)
        {
            foreach (ColorBucket bucket in buckets)
            {
                bucket.gameObject.SetActive(isActive);
            }

            IEnumerable<ColorBlock> allBlocks = firstColorBlocks.Concat(secondColorBlocks).Concat(thirdColorBlocks);
            foreach (ColorBlock block in allBlocks)
            {
                block.gameObject.SetActive(isActive);
            }
        }
    }
}
