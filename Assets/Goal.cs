using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (gameObject.CompareTag("left"))
            GameManager.Instance.scoreEvent.Invoke(GameManager.Side.Right);
        else
            GameManager.Instance.scoreEvent.Invoke(GameManager.Side.Left);
    }
}
