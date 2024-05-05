using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Realign : MonoBehaviour
{
    Vector3 startCoordinate;
    // Start is called before the first frame update
    void Start()
    {
        startCoordinate = this.gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (this.gameObject.transform.position == startCoordinate) return;
        this.gameObject.transform.position = startCoordinate;
    }
}
