using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseTracker : MonoBehaviour
{
    Vector3 target;
    RaycastHit hit;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mouse = Input.mousePosition;
        Ray castPoint = Camera.main.ScreenPointToRay(mouse);
        if (Physics.Raycast(castPoint, out hit, Mathf.Infinity))
        {
            target = hit.point;
        }
    }

    public Vector3 GetMouse(){
        Vector3 mouse = Input.mousePosition;
        Ray castPoint = Camera.main.ScreenPointToRay(mouse);
        if (Physics.Raycast(castPoint, out hit, Mathf.Infinity))
        {
            return hit.point;
        }
        else 
        {
            return Vector3.zero;
        }
    }
}
