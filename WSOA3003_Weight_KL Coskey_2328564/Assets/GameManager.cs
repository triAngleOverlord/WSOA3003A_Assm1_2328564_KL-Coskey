using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public orderNumber order;
    public static int difference;
    public List<GameObject> itemsToTrade = new List<GameObject>();
    public enum orderNumber
    {
        One, Two, Three, Four, Five, Six, Seven
    }
    void Start()
    {
        order = orderNumber.One;
        itemsToTrade.Add(Resources.Load<GameObject>("ItemsMET/flourMET"));
        instantiateItemsToList();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    public void dealIsMade()
    {
        if (difference == 0)
        {
            GameObject[] items = GameObject.FindGameObjectsWithTag("item");
            foreach (GameObject item in items)
            {
                item.transform.GetComponent<SphereCollider>().isTrigger = true;
            }

            GameObject[] allButtons = GameObject.FindGameObjectsWithTag("buttons");
            foreach (GameObject button in allButtons)
            {
                button.GetComponent<buttons>().allOfTheseItems.Clear();
                button.GetComponent<buttons>().itemInfo.text = new string(button.name);
            }

            itemsToTrade.Clear();
            //change past order image

            switch (order)
            {
                case orderNumber.One: order = orderNumber.Two; itemsToTrade.Add(Resources.Load<GameObject>("ItemsMET/chickenMET"));
                    break;
                case orderNumber.Two: order = orderNumber.Three; itemsToTrade.Add(Resources.Load<GameObject>("ItemsMET/chickenMET")); itemsToTrade.Add(Resources.Load<GameObject>("ItemsMET/flourMET"));
                    break;
                case orderNumber.Three: order = orderNumber.Four; itemsToTrade.Add(Resources.Load<GameObject>("ItemsMET/braincellMET")); itemsToTrade.Add(Resources.Load<GameObject>("ItemsMET/braincellMET"));
                    break;
                case orderNumber.Four: order = orderNumber.Five; itemsToTrade.Add(Resources.Load<GameObject>("ItemsMET/soulMET"));
                    break;
                case orderNumber.Five: order = orderNumber.Six; itemsToTrade.Add(Resources.Load<GameObject>("ItemsMET/crownMET"));
                    break;
                case orderNumber.Six: order = orderNumber.Seven; itemsToTrade.Add(Resources.Load<GameObject>("ItemsMET/braincellMET"));
                    break;
                case orderNumber.Seven: itemsToTrade.Add(Resources.Load<GameObject>("ItemsMET/donkey"));
                    break;

            }
            instantiateItemsToList();
        }

        else
            Debug.Log("The deal is not even");
        
    }

    private void instantiateItemsToList()
    {
        for(int i = 0; i < itemsToTrade.Count; i++)
        {
            Instantiate(itemsToTrade[i], GameObject.Find("spawnTrade").gameObject.transform.position, Quaternion.identity, GameObject.Find("spawnTrade").gameObject.transform);
        }
    }
}
