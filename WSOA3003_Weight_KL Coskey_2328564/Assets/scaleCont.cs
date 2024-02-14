using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scaleCont : MonoBehaviour
{
    //[SerializeField] private GameObject scalar;
    public int imperialTotal;
    public int metricTotal;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void calculate()
    {
        int difference = imperialTotal - metricTotal;
        Debug.Log(difference);
        if (difference > 0)
        {
            Debug.Log("More Imperial");
            //Anim...
        }
        else
            Debug.Log("More Metric");
        //Anim...
    }


}
