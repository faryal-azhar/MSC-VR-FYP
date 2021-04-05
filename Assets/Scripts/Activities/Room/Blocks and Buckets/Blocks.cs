using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(B_Color))]
public class Blocks : MonoBehaviour
{
    public void DestroyBlock()
    {
        Destroy(this.gameObject);
    }
}
