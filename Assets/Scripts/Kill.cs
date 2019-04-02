using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kill : MonoBehaviour
{
    public void KillSth(GameObject toKill)
    {
        Destroy(toKill);
    }
}
