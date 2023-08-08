using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


#pragma warning disable IDE0051, IDE0060
public class Task6Input : MonoBehaviour, IPointerDownHandler, IDragHandler
{

    public GameObject Player;
    public float xclamp;
    public Task6Manager manager;

    public void OnPointerDown(PointerEventData eventData)
    {
        manager.isStarted = true;
        Player.GetComponent<Task6Player>().anim.SetBool("_isRunning", true);
    }


    public void OnDrag(PointerEventData eventData)
    {
        Player.transform.position += new Vector3(eventData.delta.x * Time.deltaTime, 0, 0);
        xclamp = Mathf.Clamp(Player.transform.position.x, -2.7f, 2.7f);
        Player.transform.position = new Vector3(xclamp, Player.transform.position.y, Player.transform.position.z);

    }
}
