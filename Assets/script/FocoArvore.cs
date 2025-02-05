using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FocoArvore : MonoBehaviour
{
    public NavMeshAgent navMesh;
    GameObject player;
    public float velocidadeInimigo;

    // Start is called before the first frame update
    void Start()
    {
        navMesh = gameObject.GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("ArvoreMae");
        
        if (navMesh == null)
        {
            Debug.LogError("NavMeshAgent not found on " + gameObject.name);
        }

        if (player == null)
        {
            Debug.LogError("Player with tag 'ArvoreMae' not found");
        }

        if (navMesh != null)
        {
            navMesh.speed = velocidadeInimigo;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (navMesh != null && player != null)
        {
            if (navMesh.isOnNavMesh) // Verifica se o NavMeshAgent está no NavMesh
            {
                navMesh.destination = player.transform.position;

                if (Vector3.Distance(transform.position, player.transform.position) < 1.5f)
                {
                    navMesh.speed = 0;
                }
            }
            else
            {
                Debug.LogError("NavMeshAgent is not on the NavMesh");
            }
        }
    }
}
