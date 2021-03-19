using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blocks : MonoBehaviour
{
    public enum BlockColor
    {
        Red,
        Green,
        Blue
    }

    public BlockColor color;
    
    public void DestroyBlock()
    {
        Destroy(this.gameObject);
    }
}
