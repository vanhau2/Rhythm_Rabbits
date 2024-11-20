using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class script : MonoBehaviour
{
    public GameObject go;
    public float speed = 0.5f;
    private Vector3 position = new Vector3(0, -6, 0);
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        go.transform.position = Vector3.MoveTowards(go.transform.position, position, speed);
    }
}
