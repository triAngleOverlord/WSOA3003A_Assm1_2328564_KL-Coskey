using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scaleCont : MonoBehaviour
{
    [SerializeField] private Animator scaleAnim;
    public int imperialTotal;
    public int metricTotal;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void calculate()
    {
        GameManager.difference= imperialTotal - metricTotal;
        //Debug.Log(GameManager.difference);
        if (GameManager.difference > 0)
        {
            //Debug.Log("More Imperial");
            scaleAnim.SetInteger("difference", 1);
        }
        else if (GameManager.difference < 0)
        {
            //Debug.Log("More Metric");
            scaleAnim.SetInteger("difference", 2);

        }
        else
        {
            //Debug.Log("Even");
            scaleAnim.SetInteger("difference", 0);
        }
        Debug.Log(metricTotal + ":" + imperialTotal);
    }


}
