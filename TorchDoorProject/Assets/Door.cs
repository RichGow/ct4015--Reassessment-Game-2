using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField]
    private GameObject arrow, doorFire;

    // Start is called before the first frame update
    void Start()
    {
        arrow.SetActive(false);
        doorFire.SetActive(false);
        Torch.SetDoorOnFire += SmallDelayBeforeFireUp;
    }

    private void SmallDelayBeforeFireUp()
    {
        Invoke("FireUp", 1f);
    }

    private void FireUp()
    {
        doorFire.SetActive(true);
        Invoke("DestroyDoor", 2f);
    }

    private void DestroyDoor()
    {
        doorFire.SetActive(false);
        arrow.SetActive(true);
        Destroy(gameObject);
    }

    private void OnDestroy()
    {
        Torch.SetDoorOnFire -= SmallDelayBeforeFireUp;
    }
}
