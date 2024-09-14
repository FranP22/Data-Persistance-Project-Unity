using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{

    private MapLocation location;

    public GameObject mazeGameObject;
    private Maze maze;
    private Spawn spawn;

    public int explosionRadius = 2;

    void Start()
    {
        maze = mazeGameObject.GetComponent<Maze>();
        spawn = mazeGameObject.GetComponent<Spawn>();
        location = new MapLocation((int)(transform.position.x / maze.scale), (int)(transform.position.z / maze.scale));
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.isTrigger) return;

        switch (other.gameObject.tag)
        {
            case "Player":
                Explode();
                Destroy(gameObject);
                break;
            case "Enemy":
                Explode();
                Destroy(gameObject);
                break;
            default:
                break;
        }
    }

    public void Explode()
    {
        Collider[] hit = Physics.OverlapSphere(transform.position, explosionRadius*maze.scale);
        foreach(Collider c in hit)
        {
            if(c.gameObject.tag == "Wall")
            {
                //Destroy(c.gameObject);
                c.gameObject.SetActive(false);
            }
        }

        spawn.RebuildNavMesh();
    }
}
