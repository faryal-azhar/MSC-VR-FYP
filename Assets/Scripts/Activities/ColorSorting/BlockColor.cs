using System;
using UnityEngine;

namespace KidsVR.Activities.ColorSorting
{
    // Order matches the color buttons on the board
    public enum BlockColor
    {
        Green,
        Red,
        Blue,
        Yellow,
        Pink,
        Orange,
        Purple,
        Brown,
        Grey
    }

    public static class BlockColorExtensions
    {
        public static Color ToColor(this BlockColor blockColor)
        {
            switch (blockColor)
            {
                case BlockColor.Green: return Color.green;
                case BlockColor.Red: return Color.red;
                case BlockColor.Blue: return Color.blue;
                case BlockColor.Yellow: return Color.yellow;
                case BlockColor.Pink: return new Color32(255, 105, 180, 255);
                case BlockColor.Orange: return new Color32(255, 165, 0, 255);
                case BlockColor.Purple: return new Color32(128, 0, 128, 255);
                case BlockColor.Brown: return new Color32(139, 69, 19, 255);
                case BlockColor.Grey: return Color.grey;
                default: throw new ArgumentOutOfRangeException(nameof(blockColor), blockColor, null);
            }
        }
    }
}
