using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#pragma warning disable IDE0051, IDE0060
public class PlayerCont : MonoBehaviour
{
    public float speed;
    public float normalSpeed;

    public GameManager manager;
    public Animator anim;
    public Transform stackPoint, bag;
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
        collectedStuff.Remove(other.gameObject);
        Destroy(other.gameObject);
    }

    public void ListTarget()
    {
        for (int i = 0; i < collectedStuff.Count; i++)
        {
            if (i == 0)
            {
                collectedStuff[i].GetComponent<Collectable>().TargetObj = stackPoint;
            }
            else
            {
                collectedStuff[i].GetComponent<Collectable>().TargetObj = collectedStuff[i - 1].transform;
            }
        }
    }
    void OnTriggerEnter(Collider other)
    {
        switch (other.tag)
        {
            case "Finish":
                speed = 0;
                anim.SetBool("_isRunning", false);
                manager.cm1.SetActive(false);
                manager.cm2.SetActive(true);
                manager.button.SetActive(true);
                manager.button2.SetActive(true);
                break;

        }


    }

    public void Bagged(GameObject collected)
    {
        collected.transform.SetParent(bag);
        int index = collectedStuff.IndexOf(collected);
        collected.transform.localPosition = new Vector3(0, Math.Abs(index - collectedStuff.Count - 1)-2, 0);
    }
}
