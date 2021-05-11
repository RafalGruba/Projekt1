using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Relics : MonoBehaviour
{
    SkeletonMageMechanics smm;
    // Start is called before the first frame update
    void Start()
    {
        smm = FindObjectOfType<SkeletonMageMechanics>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        smm.AddToRelics();
        Destroy(gameObject);
    }

}
