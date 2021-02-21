using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drawer : MonoBehaviour
{
    enum ConditionType
    {
        Greater,
        Lesser
    }

    enum Coordinates
    {
        x, y, z
    };
    [SerializeField] Coordinates selectedCord;
    [SerializeField] ConditionType conditionType;
    [SerializeField] Vector3 customLinearLimits;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        switch (conditionType)
        {
            case ConditionType.Greater :
                if (selectedCord ==Coordinates.x)
                {
                    if (transform.localPosition.x>=customLinearLimits.x)
                    {
                        var newPos = transform.localPosition;
                        newPos.x = customLinearLimits.x;
                        transform.localPosition = newPos;
                    }
                }
                else if (selectedCord ==Coordinates.y)
                {
                    if (transform.localPosition.y>=customLinearLimits.y)
                    {
                        var newPos = transform.localPosition;
                        newPos.y = customLinearLimits.y;
                        transform.localPosition = newPos;
                    }
                }
                else if (selectedCord ==Coordinates.z)
                {
                    if (transform.localPosition.z>=customLinearLimits.z)
                    {
                        var newPos = transform.localPosition;
                        newPos.z = customLinearLimits.z;
                        transform.localPosition = newPos;
                    }
                }
                break;
            case ConditionType.Lesser:
                if (selectedCord ==Coordinates.x)
                {
                    if (transform.localPosition.x<=customLinearLimits.x)
                    {
                        var newPos = transform.localPosition;
                        newPos.x = customLinearLimits.x;
                        transform.localPosition = newPos;
                    }
                }
                else if (selectedCord ==Coordinates.y)
                {
                    if (transform.localPosition.y<=customLinearLimits.y)
                    {
                        var newPos = transform.localPosition;
                        newPos.y = customLinearLimits.y;
                        transform.localPosition = newPos;
                    }
                }
                else if (selectedCord ==Coordinates.z)
                {
                    if (transform.localPosition.z<=customLinearLimits.z)
                    {
                        var newPos = transform.localPosition;
                        newPos.z = customLinearLimits.z;
                        transform.localPosition = newPos;
                    }
                }
                break;
        }
        
        
    }

}


