using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    public Transform TargetObj;
    public GameManager manager;
    bool fintouch = false;

    void Awake()
    {
        manager = GameObject.FindGameObjectWithTag("Manager").GetComponent<GameManager>();
    }
    void OnTriggerEnter(Collider other)
    {
        switch (other.tag)
        {
            case "Obstacle":
                manager.playersc.LoseCollectable(gameObject);
                break;
            case "SphereMaker":
                gameObject.GetComponent<MeshFilter>().sharedMesh = manager.spherepref.GetComponent<MeshFilter>().sharedMesh;
                break;
            case "CubeMaker":
                gameObject.GetComponent<MeshFilter>().sharedMesh = manager.cubepref.GetComponent<MeshFilter>().sharedMesh;
                break;
            case "Player":
                manager.playersc.CollectProcess(gameObject);
                gameObject.tag = "Collected";
                break;
            case "Collected":
                if (gameObject.tag != "Collected")
                {
                    manager.playersc.CollectProcess(gameObject);
                    gameObject.tag = "Collected";
                }
                break;
            case "Finish":
                manager.playersc.Bagged(gameObject);
                fintouch = true;
                if (gameObject.GetComponent<MeshFilter>().sharedMesh == manager.spherepref.GetComponent<MeshFilter>().sharedMesh)
                {
                    manager.scoreupdate(10);
                }
                else
                {
                    manager.scoreupdate(5);
                }
                break;
        }


    }

    public void GoTarget()
    {
        if (TargetObj != null)
        {
            transform.position = Vector3.Lerp(transform.position, TargetObj.position + new Vector3(0, 0f, 1f), Time.deltaTime * 10f);
        }
    }


    void Update()
    {
        if (!fintouch)
        {
            GoTarget();
        }


    }
}
