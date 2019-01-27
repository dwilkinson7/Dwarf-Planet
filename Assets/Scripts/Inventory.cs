using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    Dictionary<string, int> items = new Dictionary<string, int>();
    int current_amount = 0;

    GameObject item;
    [Header("Components")]
    public HotBar ui_hotbar;

    [Header("Templates")]
    public GameObject straw;
    public GameObject wood;
    public GameObject stone;
    public GameObject iron;

    bool holding = false;
    bool canPick = false;


    // Start is called before the first frame update
    void Start()
    {
        if (ui_hotbar == null)
        {
            ui_hotbar = FindObjectOfType<HotBar>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!holding)
        {
            if (Input.GetKeyDown("1"))
            {
                ui_hotbar.Select(0);
                string type = "Straw";
                if (items.ContainsKey(type) && items[type] > 0)
                {
                    chooseObject(type, straw);
                }
                else
                {
                    ui_hotbar.Select(-1);
                    Debug.Log("You don't have the item!!!");
                }
                holding = true;
                canPick = false;
            }
            else if (Input.GetKeyDown("2"))
            {
                ui_hotbar.Select(1);
                string type = "Wood";
                if (items.ContainsKey(type) && items[type] > 0)
                {
                    chooseObject(type, wood);
                }
                else
                {
                    ui_hotbar.Select(-1);
                    Debug.Log("You don't have the item!!!");
                }
                holding = true;
                canPick = false;
            }
            else if (Input.GetKeyDown("3"))
            {
                ui_hotbar.Select(2);
                string type = "Stone";
                if (items.ContainsKey(type) && items[type] > 0)
                {
                    chooseObject(type, stone);
                }
                else
                {
                    ui_hotbar.Select(-1);
                    Debug.Log("You don't have the item!!!");
                }
                holding = true;
                canPick = false;
            }
            else if (Input.GetKeyDown("4"))
            {
                ui_hotbar.Select(3);
                string type = "Iron";
                if (items.ContainsKey(type) && items[type] > 0)
                {
                    chooseObject(type, iron);
                }
                else
                {
                    ui_hotbar.Select(-1);
                    Debug.Log("You don't have the item!!!");
                }
                holding = true;
                canPick = false;

            }
        }
        if (Input.GetKeyDown("e") && holding)
        {
            GameObject.Find("Hand").transform.DetachChildren();
            item.GetComponent<Rigidbody>().isKinematic = false;
            item.GetComponent<CenterGravity>().enabled = true;
            holding = false;
            ui_hotbar.Select(-1);
        }
        if (Input.GetKeyDown("f") && canPick && !holding)
        {
            holding = true;
        }
    }

    public void addItem(string type, int amount)
    {
        if (items.ContainsKey(type))
            current_amount = items[type];
        items[type] = current_amount + amount;
        Debug.Log("Added: " + type + " of amount: " + amount.ToString());
        ui_hotbar.SetQuantity(type, items[type]);
    }

    public void removeItem(string type, int amount)
    {
        items[type] = items[type] - amount;
        ui_hotbar.SetQuantity(type, items[type]);
    }

    void OnCollisionStay(Collision collision)
    {
        if(collision.gameObject.tag == "Straw" && Input.GetKeyDown("f"))
        {
            pickUpObject(collision, straw);
        }
        else if (collision.gameObject.tag == "Wood" && Input.GetKeyDown("f"))
        {
            pickUpObject(collision, wood);
        }
        else if (collision.gameObject.tag == "Iron" && Input.GetKeyDown("f"))
        {
            pickUpObject(collision, iron);
        }
        else if (collision.gameObject.tag == "Stone" && Input.GetKeyDown("f"))
        {
            pickUpObject(collision, stone);
        }
    }

    void chooseObject(string type, GameObject go)
    {
        removeItem(type, 1);
        item = Instantiate(go, new Vector3(0, 0, 0), transform.rotation);
        item.transform.SetParent(transform.Find("Hand").transform, false);
    }

    void pickUpObject(Collision col, GameObject go)
    {
        canPick = true;
        Destroy(col.gameObject);
        item = Instantiate(go, new Vector3(0, 0, 0), transform.rotation);
        item.transform.SetParent(GameObject.Find("Hand").transform, false);
    }
}
