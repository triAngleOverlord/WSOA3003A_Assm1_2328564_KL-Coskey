using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttons : MonoBehaviour
{
    private Transform allImperialItems;
    public List<GameObject> allOfTheseItems = new List<GameObject>();
    private GameObject thisItem;
    public Item item;
    public enum Item
    {
        chicken, pea
    }

    public void Start()
    {
        allImperialItems = GameObject.Find("collection").gameObject.transform;
        switch (item)
        {
            case Item.chicken: thisItem= Resources.Load<GameObject>("Items/chickenItem"); Debug.Log("pea found");
                break;
            case Item.pea: thisItem = Resources.Load<GameObject>("Items/peaItem");
                break;
        }
    }
    public void addAnItem()
    {
        GameObject newItem= Instantiate(thisItem, allImperialItems, true);
        allOfTheseItems.Add(newItem);
    }

    public void removeAnItem() 
    {
        if (allOfTheseItems.Count != 0)
        {
            allOfTheseItems[0].transform.GetComponent<SphereCollider>().isTrigger = true;
            Debug.Log(allOfTheseItems[0].transform.GetComponent<SphereCollider>().isTrigger);
            allOfTheseItems.Remove(allOfTheseItems[0]);
        }
        else
            Debug.Log("No more of these items to remove");
    }

}
