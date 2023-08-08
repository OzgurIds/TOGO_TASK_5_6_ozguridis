using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Task6Collect : MonoBehaviour
{
    public Transform TargetObj;
    public Task6Manager manager;
    bool fintouch = false;

    void Awake()
    {
        manager = GameObject.FindGameObjectWithTag("Manager").GetComponent<Task6Manager>();
    }
    void OnTriggerEnter(Collider other)
    {
        switch (other.tag)
        {
            case "Gate":
                if (other.GetComponentInParent<Gate>().resource > 0)
                {
                    manager.playersc.LoseCollectable(gameObject);
                    other.GetComponentInParent<Gate>().GateDamage();
                }
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
                if (other.GetComponentInParent<Gate>().resource > 0)
                {
                    manager.playersc.LoseCollectable(gameObject);
                    other.GetComponentInParent<Gate>().GateDamage();
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
