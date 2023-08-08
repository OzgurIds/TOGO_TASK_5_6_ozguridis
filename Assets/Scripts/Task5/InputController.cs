using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


#pragma warning disable IDE0051, IDE0060
public class InputController : MonoBehaviour, IPointerDownHandler, IDragHandler
{

    public GameObject Player;
    public float xclamp;
    public GameManager manager;

    public void OnPointerDown(PointerEventData eventData)
    {
        manager.isStarted = true;
        Player.GetComponent<PlayerCont>().anim.SetBool("_isRunning", true);
    }


    public void OnDrag(PointerEventData eventData)
    {
        Player.transform.position += new Vector3(eventData.delta.x * Time.deltaTime, 0, 0);
        xclamp = Mathf.Clamp(Player.transform.position.x, -2.3f, 2.3f);
        Player.transform.position = new Vector3(xclamp, Player.transform.position.y, Player.transform.position.z);

    }
}
