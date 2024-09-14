using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minimap : MonoBehaviour
{
    public Maze maze;
    private Camera cam;

    void Start()
    {

    }

    void Update()
    {
        
    }

    public void LoadCamera()
    {
        cam = GetComponent<Camera>();

        float center = (float)maze.size * (float)maze.scale / 2;
        cam.orthographicSize = center;

        float centerPos = center - (float)maze.scale / 2;
        transform.position = new Vector3(centerPos, 50, centerPos);
    }
}
