using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class buttons : MonoBehaviour
{
    private Transform allImperialItems;
    public List<GameObject> allOfTheseItems = new List<GameObject>();
    private GameObject thisItem;
    public Item item;
    public TextMeshProUGUI itemInfo;
    public enum Item
    {
        peaIMP,
        appleIMP,
        cabbageIMP,
        chickenIMP, 
        flourIMP,
        brainIMP,
        crownIMP,
        soulIMP
    }

    public void Start()
    {
        allImperialItems = GameObject.Find("collection").gameObject.transform;
        switch (item)
        {
            case Item.peaIMP: thisItem = Resources.Load<GameObject>("ItemsIMP/peaIMP");
                break;
            case Item.appleIMP: thisItem = Resources.Load<GameObject>("ItemsIMP/appleIMP");
                break;
            case Item.cabbageIMP: thisItem = Resources.Load<GameObject>("ItemsIMP/cabbageIMP");
                break;
            case Item.chickenIMP: thisItem= Resources.Load<GameObject>("ItemsIMP/chickenIMP"); 
                break;
            case Item.flourIMP: thisItem = Resources.Load<GameObject>("ItemsIMP/flourIMP");
                break;
            case Item.brainIMP: thisItem = Resources.Load<GameObject>("ItemsIMP/braincellIMP");
                break;
            case Item.crownIMP: thisItem = Resources.Load<GameObject>("ItemsIMP/crownIMP");
                break;
            case Item.soulIMP: thisItem = Resources.Load<GameObject>("ItemsIMP/soulIMP");
                break;
            
        }
    }
    public void addAnItem()
    {

        GameObject newItem= Instantiate(thisItem, new Vector3( Random.Range(37, 42) ,48, 90) , Quaternion.identity, allImperialItems);
        allOfTheseItems.Add(newItem);
        itemInfo.text = new string(name + "(" + allOfTheseItems.Count + ")");
    }

    public void removeAnItem() 
    {
        if (allOfTheseItems.Count != 0)
        {
            allOfTheseItems[0].transform.GetComponent<SphereCollider>().isTrigger = true;
            Debug.Log(allOfTheseItems[0].transform.GetComponent<SphereCollider>().isTrigger);
            allOfTheseItems.Remove(allOfTheseItems[0]);
            itemInfo.text = new string(name + "(" + allOfTheseItems.Count + ")");
        }
        else
            Debug.Log("No more of these items to remove");
    }

}
