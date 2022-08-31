using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public GameObject target;
    Transform Ptarget;
    Vector3 PPtarget;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Ptarget = target.GetComponent<Transform>();
        this.transform.position = Vector3.Lerp(this.transform.position, new Vector3(Ptarget.position.x, Ptarget.position.y, -10), 100 * Time.deltaTime);
    }
}
