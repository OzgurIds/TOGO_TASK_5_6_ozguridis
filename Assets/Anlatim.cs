using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Anlatim : MonoBehaviour
{
    public int deneme;

    void Start()
    {
    
       
    }

    void Update()
    {
         switch (deneme)
        {
            case 1:
                Debug.Log("Bir");
                break;

            case 2:
                Debug.Log("iki");
                //biseyler yap
                break;

            case 3:
                Debug.Log("uc");
                break;

            default: //ELSE
                Debug.Log("hicbiri");
                break;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        switch (other.tag)
        {
            case "Wall":
                break;

            case "SmallObstacle":

                break;
        }
    }
}

