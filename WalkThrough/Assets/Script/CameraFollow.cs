using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour 
{
    public Transform Hero;
    public float LineHeight;
    public Color LineColor;
    public Transform []WinLine;
    public float CamCatchSpeedX;

    private Transform Target;
    private int Dir;
    private Transform Edge;

    void Start()
    {
        Target = WinLine[1];
        Dir = 1;
        Edge = WinLine[0];
    }

    void Update()
    {
        if (Hero.localScale.x == Dir)
        {
            if (Target.position.x == Hero.position.x)
            {
                transform.position = new Vector3(transform.position.x-Target.position.x + Hero.position.x, transform.position.y);
            }
            else
            {
                //Camera catch hero X
                float dis = (Hero.position.x - Target.position.x) * Dir;
                if (dis > 0)
                {
                    float newX;
                    if (dis < CamCatchSpeedX)
                    {
                        newX = transform.position.x +dis*Dir;
                    }
                    else
                    {
                        newX = transform.position.x + CamCatchSpeedX*Dir;
                    }
                    transform.position=new Vector3(newX,transform.position.y);
                }
            }
        }
        else
        {
            if ((Hero.position.x - Edge.position.x) * Dir <= 0)
            {
                //If Hero Reaches Edge,ChangeDir
                ChangeDirection();
            }
            else
            {
                //Don't move
            }
        }
    }

    private void ChangeDirection()
    {
        Dir *= -1;
        if (Dir == 1)
        {
            Target = WinLine[1];
            Edge = WinLine[0];
        }
        else if (Dir == -1)
        {
            Target = WinLine[2];
            Edge = WinLine[3];
        }
        else Debug.LogError("Wrong Dirction");
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