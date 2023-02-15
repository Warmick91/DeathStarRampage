using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatBackground : MonoBehaviour
{
    private Vector3 initPosition;
    private float repeatWidth;
    // Start is called before the first frame update
    void Start()
    {
        initPosition = transform.position;
        //Set repeat width to half of the background's
        repeatWidth = GetComponent<BoxCollider>().size.x / 2 * transform.localScale.x;
        Debug.Log(repeatWidth);
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < initPosition.x - repeatWidth)
        {
            transform.position = initPosition;
        }
    }
}
