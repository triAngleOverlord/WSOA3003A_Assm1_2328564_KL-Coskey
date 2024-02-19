using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pastOrders : MonoBehaviour
{
    private bool ordersAreIn;

    public void viewPastOrders()
    {
        if (ordersAreIn)
        {
            ordersAreIn = false;
            transform.GetComponent<RectTransform>().anchoredPosition = new Vector3(935, -59);
        }
        else
        {
            ordersAreIn = true;
            transform.GetComponent<RectTransform>().anchoredPosition = new Vector3(423, -59);
        }
            
    }
}
