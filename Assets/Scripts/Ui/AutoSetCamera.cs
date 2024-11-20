using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoSetCamera :MonoBehaviour
{
    public Camera mainCamera;
    // Start is called before the first frame update
    void Start()
    {
        // 0.3*x + 4.53 = y
        float x = ((float)Screen.height) /((float) Screen.width);
        float y = 0.3f*x+4.53f;
        mainCamera.orthographicSize = y;
    }


}
