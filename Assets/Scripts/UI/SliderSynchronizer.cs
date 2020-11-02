using UnityEngine;
using UnityEngine.UI;

public class SliderSynchronizer : MonoBehaviour
{
    Slider sliderComponent;

    private void Start()
    {
        sliderComponent = GetComponent<Slider>();
    }

    public void Synchronize(Slider other)
    {
        float valueRatio = other.maxValue / sliderComponent.maxValue;
        other.value = other.maxValue - (sliderComponent.value * valueRatio);
    }
}
