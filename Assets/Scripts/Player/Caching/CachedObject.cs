using UnityEngine;



public class CachedObject : MonoBehaviour
{
    public bool isBusy = false;
    public bool IsActive => gameObject.activeSelf;
    public float Y { get; set; }
    public bool IsBig { get; set; }

    public void Activate() => gameObject.SetActive(true);
    public void Deactivate() => gameObject.SetActive(false);

    public void Reset()
    {
        Activate();
    }
}

