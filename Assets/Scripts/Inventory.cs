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


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("1"))
        {
            string type = "Straw";
            if (items.ContainsKey(type) && items[type] > 0)
            {
                removeItem(type, 1);
                item = Instantiate(straw, new Vector3(0, 0, 0), transform.rotation);
                item.transform.SetParent(transform.Find("Hand").transform, false);
                ui_hotbar.Select(0);
            }
            else
            {
                ui_hotbar.Select(-1);
                Debug.Log("You don't have the item!!!");
            }
        }
        else if (Input.GetKeyDown("2"))
        {
            ui_hotbar.Select(1);
            string type = "Wood";
            if (items.ContainsKey(type) && items[type] > 0)
            {
                removeItem(type, 1);
                item = Instantiate(wood, new Vector3(0, 0, 0), transform.rotation);
                item.transform.SetParent(GameObject.Find("Hand").transform, false);
            }
            else
            {
                ui_hotbar.Select(-1);
                Debug.Log("You don't have the item!!!");
            }
        }
        else if (Input.GetKeyDown("3"))
        {
            ui_hotbar.Select(2);
            string type = "Stone";
            if (items.ContainsKey(type) && items[type] > 0)
            {
                removeItem(type, 1);
                item = Instantiate(stone, new Vector3(0, 0, 0), transform.rotation);
                item.transform.SetParent(GameObject.Find("Hand").transform, false);
            }
            else
            {
                ui_hotbar.Select(-1);
                Debug.Log("You don't have the item!!!");
            }
        }
        else if (Input.GetKeyDown("4"))
        {
            ui_hotbar.Select(3);
            string type = "Iron";
            if (items.ContainsKey(type) && items[type] > 0)
            {
                removeItem(type, 1);
                item = Instantiate(iron, new Vector3(0, 0, 0), transform.rotation);
                item.transform.SetParent(GameObject.Find("Hand").transform, false);
            }
            else
            {
                ui_hotbar.Select(-1);
                Debug.Log("You don't have the item!!!");
            }

        }
        if (Input.GetKeyDown("e"))
        {
            GameObject.Find("Hand").transform.DetachChildren();
            item.GetComponent<Rigidbody>().isKinematic = false;
            item.GetComponent<CenterGravity>().enabled = true;
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
}
