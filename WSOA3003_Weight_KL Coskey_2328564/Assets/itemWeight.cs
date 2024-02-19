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
        peaMET, peaIMP,
        appleMET, appleIMP,
        cabbageMET, cabbageIMP,
        flourMET, flourIMP, 
        chickenMET, chickenIMP, 
        brainMET, brainIMP,
        crownMET, crownIMP,
        soulMET, soulIMP,
        donkey
        
    }
    void Start()
    {
        switch(type)
        {
            case objectType.flourMET:  weightAmount = 500; isImperial = false;
                break;
            case objectType.chickenMET: weightAmount = 60; isImperial = true;
                break;
            case objectType.peaMET: weightAmount = 5; isImperial = true;
                break;
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other != null && other.transform.tag== "triggerBox")
        {
            if (isImperial == true)
            {
                other.transform.GetComponent<scaleCont>().imperialTotal += weightAmount;
                transform.SetParent(GameObject.Find("imperialContainer").gameObject.transform);
                //Debug.Log("Added imperial weight " + weightAmount);
            }
            else
            {
                other.transform.GetComponent<scaleCont>().metricTotal += weightAmount;
                transform.SetParent(GameObject.Find("metricContainer").gameObject.transform);
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
