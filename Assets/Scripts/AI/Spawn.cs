using System.Collections;
using System.Collections.Generic;
using Unity.AI.Navigation;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class Spawn : MonoBehaviour
{
    public Maze maze;
    public GameObject surface;
    [HideInInspector]
    public NavMeshSurface navSurface;

    [HideInInspector]
    public List<MapLocation> locations = new List<MapLocation>();

    public List<MapLocation> EmptySpaces()
    {
        List<MapLocation> empty = new List<MapLocation>();
        for (int z = 0; z < maze.depth; z++)
        {
            for (int x = 0; x < maze.width; x++)
            {
                if (maze.map[x, z] == 0)
                {

                    empty.Add(new MapLocation(x * maze.scale, z * maze.scale));
                }
            }
        }
        return empty;
    }

    public static void SpawnObject(GameObject obj, List<MapLocation> locations)
    {

        System.Random rnd = new System.Random();
        int index = rnd.Next(locations.Count);

        Instantiate(obj, new Vector3(locations[index].x, 0, locations[index].z), obj.transform.rotation);
        return;
    }

    private void Start()
    {

    }

    public void StartSpawn()
    {
        maze.CreateMaze();

        navSurface = surface.GetComponent<NavMeshSurface>();
        navSurface.BuildNavMesh();

        locations = EmptySpaces();
    }

    public void RebuildNavMesh()
    {
        navSurface = surface.GetComponent<NavMeshSurface>();
        navSurface.BuildNavMesh();
    }
}
