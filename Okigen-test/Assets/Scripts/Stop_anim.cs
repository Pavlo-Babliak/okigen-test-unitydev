using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stop_anim : MonoBehaviour
{
    public void Stop_an() 
    {
        GetComponent<Animator>().enabled = false;
        GetComponent<Animator>().Rebind();
    }
    public void Stop_an_non_rebind()
    {
        GetComponent<Animator>().enabled = false;
    }
}
