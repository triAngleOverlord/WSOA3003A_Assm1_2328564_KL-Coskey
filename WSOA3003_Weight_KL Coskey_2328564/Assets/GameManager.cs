using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public orderNumber order;
    public static int difference;
    private List<GameObject> itemsToTrade = new List<GameObject>();
    public enum orderNumber
    {
        One, Two, Three, Four, Five, Six, Seven, Eight
    }
    void Start()
    {
        order = orderNumber.One;
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
                Destroy(item);
            }

            itemsToTrade.Clear();
            //change past order image

            switch (order)
            {
                case orderNumber.One: order = orderNumber.Two; itemsToTrade.Add(Resources.Load<GameObject>("ItemsMET/riceMET")); itemsToTrade.Add(Resources.Load<GameObject>("ItemsMET/riceMET"));
                    break;
                case orderNumber.Two: order = orderNumber.Three;
                    break;
                case orderNumber.Three: order = orderNumber.Four;
                    break;
                case orderNumber.Four: order = orderNumber.Five;
                    break;
                case orderNumber.Five: order = orderNumber.Six;
                    break;
                case orderNumber.Six: order = orderNumber.Seven;
                    break;
                case orderNumber.Seven: order = orderNumber.Eight;
                    break;
                case orderNumber.Eight:
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
            Instantiate(itemsToTrade[i], GameObject.Find("spawnTrade").gameObject.transform, true);
        }
    }
}
