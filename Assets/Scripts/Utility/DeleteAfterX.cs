using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteAfterX : MonoBehaviour
{

    public float deleteAfter = 5f;
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(deleteAfterX());
    }

    IEnumerator deleteAfterX ()
    {

        yield return new WaitForSeconds(deleteAfter);
        Destroy(gameObject);

    }
    
}
