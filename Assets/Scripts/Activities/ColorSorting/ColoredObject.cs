using UnityEngine;

namespace KidsVR.Activities.ColorSorting
{
    [RequireComponent(typeof(Renderer))]
    public abstract class ColoredObject : MonoBehaviour
    {
        public BlockColor ColorType { get; private set; }

        public void SetColor(BlockColor color)
        {
            ColorType = color;
            GetComponent<Renderer>().material.color = color.ToColor();
        }
    }
}
