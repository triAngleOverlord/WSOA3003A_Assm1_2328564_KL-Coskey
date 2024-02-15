using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class itemWeight : MonoBehaviour
{
    [SerializeField]private objectType type;
    [SerializeField] private int weightAmount;
    [SerializeField] private bool isImperial;
    // Start is called before the first frame update

    private enum objectType
    {
        wheat, chicken, rice, peas
    }
    void Start()
    {
        switch(type)
        {
            case objectType.wheat:  weightAmount = 500; isImperial = false;
                break;
            case objectType.chicken: weightAmount = 60; isImperial = true;
                break;
            case objectType.rice: weightAmount = 100; isImperial = false;
                break;
            case objectType.peas: weightAmount = 5; isImperial = true;
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other != null && other.transform.tag== "triggerBox")
        {
            if (isImperial == true)
            {
                other.transform.GetComponent<scaleCont>().imperialTotal += weightAmount;
                //Debug.Log("Added imperial weight " + weightAmount);
            }
            else
            {
                other.transform.GetComponent<scaleCont>().metricTotal += weightAmount;
                //Debug.Log("Added metric weight " + weightAmount);
            }
            other.transform.GetComponent<scaleCont>().calculate();
        }

        else if (other != null && other.transform.tag == "destroyBox")
        {
            if (isImperial == true)
            {

                GameObject.Find("triggerBox").transform.GetComponent<scaleCont>().imperialTotal -= weightAmount;
                Debug.Log("Minus imperial weight " + weightAmount);
            }
            else if (isImperial == false)
            {

                GameObject.Find("triggerBox").transform.GetComponent<scaleCont>().metricTotal -= weightAmount;
                Debug.Log("Minus imperial weight " + weightAmount);
            }
            GameObject.Find("triggerBox").transform.GetComponent<scaleCont>().calculate();
            Destroy(gameObject);
        }
                

        
    }

}
