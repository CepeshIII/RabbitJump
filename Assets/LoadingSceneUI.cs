using UnityEngine;

public class LoadingSceneUI: MonoBehaviour
{
    [SerializeField] private LoadingIcon loadingIcon;


    public void Show()
    {
        gameObject.SetActive(true);
    }


    public void Hide()
    {
        gameObject.SetActive(false);
    }


    public void SetFillAmount(float amount)
    {
        loadingIcon.SetFillAmount(amount);
    }

}
