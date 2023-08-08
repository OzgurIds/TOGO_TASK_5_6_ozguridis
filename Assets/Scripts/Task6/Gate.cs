using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Gate : MonoBehaviour
{
    public int resource;
    public TextMeshPro text;
    public Animator Gateanim;

    void Start()
    {
        resource = 10;
        text.text = "" + resource;
    }

    void Update()
    {
        text.text = "" + resource;
        if (resource == 0)
        {
            Gateanim.SetBool("Open", true);
        }
    }

    public bool Gatecheck()
    {
        return Gateanim.GetBool("Open");
    }

    public void GateDamage()
    {
        resource--;
    }

}
