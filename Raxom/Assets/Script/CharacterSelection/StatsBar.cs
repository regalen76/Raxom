using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatsBar : MonoBehaviour
{

    public Slider slider;

    public void SetMaxStats(int stats)
    {
        slider.maxValue = stats;
        slider.value = stats;
    }

    public void SetStats(int stats)
    {
        slider.value = stats;
    }
}
