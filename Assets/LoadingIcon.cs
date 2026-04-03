using UnityEngine;
using UnityEngine.UI;


public class LoadingIcon : MonoBehaviour
{
    private Image _image;


    public void OnEnable()
    {
        _image = GetComponent<Image>();
    }


    public void SetFillAmount(float amount)
    {
        _image.fillAmount = amount;
    }
}
