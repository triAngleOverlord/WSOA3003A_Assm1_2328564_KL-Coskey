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
            case objectType.peaMET: weightAmount = 3; isImperial = false;
                break;
            case objectType.peaIMP: weightAmount = 3; isImperial = true;
                break;

            case objectType.appleMET: weightAmount = 7; isImperial = false;
                break;
            case objectType.appleIMP: weightAmount = 7; isImperial= true;
                break;

                case objectType.cabbageMET: weightAmount = 8; isImperial = false;
                break;
            case objectType.cabbageIMP: weightAmount = 8; isImperial = true;
                break;

            case objectType.flourMET: weightAmount = 11; isImperial = false;
                break;
            case objectType.flourIMP:  weightAmount = 11; isImperial = true;
                break;

            case objectType.chickenMET: weightAmount = 13; isImperial = false;
                break;
            case objectType.chickenIMP: weightAmount = 13; isImperial = true;
                break;

            case objectType.brainMET: weightAmount = 17; isImperial = false;
                break;
            case objectType.brainIMP: weightAmount = 17; isImperial = true;
                break;

            case objectType.soulMET: weightAmount = 67; isImperial = false;
                break;
            case objectType.soulIMP: weightAmount = 67; isImperial = true;
                break;

            case objectType.crownMET: weightAmount = 127; isImperial = false;
                break;
            case objectType.crownIMP: weightAmount = 127; isImperial = true;
                break;

            case objectType. donkey: weightAmount = 21; isImperial = false;
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
            else if (isImperial == false) 
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
                //Debug.Log("Minus imperial weight " + weightAmount);
                GameObject.Find("triggerBox").transform.GetComponent<scaleCont>().calculate();
                Destroy(gameObject);
            }
            else if (isImperial == false)
            {
                GameObject.Find("triggerBox").transform.GetComponent<scaleCont>().metricTotal -= weightAmount;
                //Debug.Log("Minus imperial weight " + weightAmount);
                GameObject.Find("triggerBox").transform.GetComponent<scaleCont>().calculate();
                Destroy(gameObject);
            }
            //GameObject.Find("triggerBox").transform.GetComponent<scaleCont>().calculate();
            //Destroy(gameObject);
        }
                

        
    }

}
