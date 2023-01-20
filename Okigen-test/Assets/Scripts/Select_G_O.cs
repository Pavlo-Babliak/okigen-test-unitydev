using TMPro;
using UnityEngine;

public class Select_G_O : MonoBehaviour
{
    public GameObject Active_G_O, Player;
    public float speed;
    public int Count;
    public int Target;
    string target_text;
    public string fruit;
    public bool Fin;
    private void Start()
    {
        Count = Random.Range(1, 5);
        Target = Random.Range(0, 3);
        if (Target == 0) { target_text = "Collect " + Count + " Apples"; fruit = "Apple"; }
        if (Target == 1) { target_text = "Collect " + Count + " Oranges"; fruit = "Orange"; }
        if (Target == 2) { target_text = "Collect " + Count + " Bananas"; fruit = "Bananas"; }
        GameObject.Find("Target").GetComponent<TextMeshProUGUI>().text = target_text;
        GameObject.Find("Target").GetComponent<Animator>().enabled = true;
    }
    public void Rest()
    {
        Application.LoadLevel(Application.loadedLevel);
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.tag == "G_O")
                {
                    Active_G_O = hit.transform.gameObject;
                }
            }
        }
        if (Active_G_O != null)
        {
            Player.GetComponent<Animator>().SetBool("Walk", true);
            Player.transform.position = Vector3.MoveTowards(Player.transform.position, new Vector3(Active_G_O.transform.position.x + 0.4f, Player.transform.position.y, Player.transform.position.z), 0.1f * speed);
        }
        if (Player.GetComponent<Animator>().GetBool("Take") == false && Active_G_O == null)
        {
            Player.GetComponent<Animator>().SetBool("Walk", true);
            Player.transform.position = Vector3.MoveTowards(Player.transform.position, new Vector3(0, Player.transform.position.y, Player.transform.position.z), 0.1f * speed);
        }
        if (Player.transform.position == new Vector3(0, Player.transform.position.y, Player.transform.position.z))
        {
            Player.GetComponent<Animator>().SetBool("Walk", false);
        }
        if (Active_G_O != null && Player.transform.position == new Vector3(Active_G_O.transform.position.x + 0.4f, Player.transform.position.y, Player.transform.position.z))
        {
            Player.GetComponent<Animator>().SetBool("Take", true);
        }

        if (Fin == true)
        {
            Player.GetComponent<Animator>().SetBool("Walk", true);
            Player.transform.position = Vector3.MoveTowards(Player.transform.position, new Vector3(0, Player.transform.position.y, Player.transform.position.z), 0.1f * speed);
            if (Player.transform.position == new Vector3(0, Player.transform.position.y, Player.transform.position.z)) 
            {
                GameObject.Find("Male").GetComponent<Animator>().SetBool("Dance", true);
                GameObject.Find("Conveer").SetActive(false);
                GameObject.Find("Main Camera").GetComponent<Animator>().enabled=true;
                GameObject.Find("Level Passed").GetComponent<Animator>().enabled = true;
                GameObject.Find("Next level").GetComponent<Animator>().enabled = true;
                Fin = false;
            }
        }
    }
}
