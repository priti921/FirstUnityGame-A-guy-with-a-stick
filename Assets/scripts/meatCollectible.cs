using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class meatCollectible : MonoBehaviour {
    // Start is called before the first frame update
    void Start () {

    }

    // Update is called once per frame
    void Update () {

    }

    void OnTriggerEnter2D (Collider2D other) {

        MummyController player = other.GetComponent<MummyController> ();
        if (player != null) {

            Destroy (gameObject);

            player.ChangeHealth (1);
        }
    }
}