using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour 
{
    public float LineHeight;
    public Color LineColor;
    public Transform []WinLine;
    
    void Start()
    {
    }

    void OnDrawGizmos()
    {

        Gizmos.color = LineColor;
        foreach (var item in WinLine)
        {            
            Gizmos.DrawLine(new Vector3(item.position.x, item.position.y + LineHeight, item.position.z), new Vector3(item.position.x, item.position.y - LineHeight, item.position.z));
        }

    }

    
}