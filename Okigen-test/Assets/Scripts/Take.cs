using UnityEngine;

public class Take : MonoBehaviour
{
    GameObject hand;
    public GameObject G_O;
    private void Start()
    {
        hand = GameObject.Find("Take").transform.gameObject;
        Application.targetFrameRate = 60;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "G_O")
        {
            hand.GetComponent<SpringJoint>().connectedBody = other.GetComponent<Rigidbody>();
            G_O = other.gameObject;
            GameObject.Find("Male").GetComponent<Take>().G_O = G_O;
            G_O.tag = "Finish";
            GameObject.Find("Main Camera").GetComponent<Select_G_O>().Active_G_O = null;
        }
    }
    public void Take_korz()
    {
        hand.GetComponent<SpringJoint>().connectedBody = null;
        G_O.GetComponent<Rigidbody>().drag = 3;
        G_O.GetComponent<Rigidbody>().angularDrag = 1;
        G_O.GetComponent<Rigidbody>().velocity = Vector3.zero;
        if (GameObject.Find("Main Camera").GetComponent<Select_G_O>().fruit == G_O.name) 
        {
            GameObject.Find("Text+1").GetComponent<Animator>().enabled = true;
            GameObject.Find("Main Camera").GetComponent<Select_G_O>().Count--;
            if (GameObject.Find("Main Camera").GetComponent<Select_G_O>().Count == 0) 
            {
                GameObject.Find("Main Camera").GetComponent<Select_G_O>().Fin = true;
            }
        }
        
    }
    public void Take_fin() 
    {
        GameObject.Find("Male").GetComponent<Animator>().SetBool("Take", false);
    }
}
