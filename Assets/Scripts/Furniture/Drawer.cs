using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drawer:MonoBehaviour
{
    public int selectedCord;
    public ConditionType conditionType;
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
                if (selectedCord ==0)
                {
                    if (transform.localPosition.x>=customLinearLimits.x)
                    {
                        var newPos = transform.localPosition;
                        newPos.x = customLinearLimits.x;
                        transform.localPosition = newPos;
                    }
                }
                else if (selectedCord ==1)
                {
                    if (transform.localPosition.y>=customLinearLimits.y)
                    {
                        var newPos = transform.localPosition;
                        newPos.y = customLinearLimits.y;
                        transform.localPosition = newPos;
                    }
                }
                else if (selectedCord ==2)
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
                if (selectedCord ==0)
                {
                    if (transform.localPosition.x<=customLinearLimits.x)
                    {
                        var newPos = transform.localPosition;
                        newPos.x = customLinearLimits.x;
                        transform.localPosition = newPos;
                    }
                }
                else if (selectedCord ==1)
                {
                    if (transform.localPosition.y<=customLinearLimits.y)
                    {
                        var newPos = transform.localPosition;
                        newPos.y = customLinearLimits.y;
                        transform.localPosition = newPos;
                    }
                }
                else if (selectedCord ==2)
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

public enum ConditionType
{
    Greater,
    Lesser
}
