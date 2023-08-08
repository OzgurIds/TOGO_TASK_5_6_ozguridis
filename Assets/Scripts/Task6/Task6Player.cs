using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#pragma warning disable IDE0051, IDE0060
public class Task6Player : MonoBehaviour
{
    public float speed;
    public float normalSpeed;

    public Task6Manager manager;
    public Animator anim;
    public Transform stackPoint;
    public List<GameObject> collectedStuff;

    void Start()
    {
        speed = normalSpeed;
    }

    void Update()
    {
        Move();
        ListTarget();
    }
    void Move()
    {
        if (manager.isStarted)
        {
            transform.position += new Vector3(0, 0, speed * Time.deltaTime);
        }
    }
    public void CollectProcess(GameObject other)
    {
        collectedStuff.Add(other.gameObject);
    }

    public void LoseCollectable(GameObject other)
    {
        GameObject popeffect = Instantiate(Resources.Load("NukeConeExplosionFire")as GameObject,other.transform.position, Quaternion.identity);
        collectedStuff.Remove(other.gameObject);
        Destroy(other.gameObject);
    }

    public void ListTarget()
    {
        for (int i = 0; i < collectedStuff.Count; i++)
        {
            if (i == 0)
            {
                collectedStuff[i].GetComponent<Task6Collect>().TargetObj = stackPoint;
            }
            else
            {
                collectedStuff[i].GetComponent<Task6Collect>().TargetObj = collectedStuff[i - 1].transform;
            }
        }
    }
    void OnTriggerEnter(Collider other)
    {
        switch (other.tag)
        {
            case "Finish":
                // manager.cm1.SetActive(false);
                // manager.cm2.SetActive(true);
                // manager.button.SetActive(true);
                if (collectedStuff.Count == 0 && !other.gameObject.GetComponentInParent<Gate>().Gatecheck())
                {
                    speed = 0;
                    anim.SetBool("_isRunning", false);
                    manager.LosePanel.SetActive(true);
                    manager.restartbutton.SetActive(true);
                }
                else
                {
                    manager.cm1.SetActive(false);
                    manager.cm2.SetActive(true);
                    manager.inputs.SetActive(false);    
                    manager.wintext.SetActive(true);
                }
                break;
            case "Gate":
                if (collectedStuff.Count == 0 && !other.gameObject.GetComponentInParent<Gate>().Gatecheck())
                {
                    speed = 0;
                    anim.SetBool("_isRunning", false);
                    manager.LosePanel.SetActive(true);
                    manager.restartbutton.SetActive(true);
                }
                break;

        }


    }
}
