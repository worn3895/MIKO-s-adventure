using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HealItem : MonoBehaviour
{
    public Slider HPslider;
    // Start is called before the first frame update
    void heal()
    {
        HPslider.value += 30;
    }
}
