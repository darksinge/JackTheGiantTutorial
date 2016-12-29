using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGSpawner : MonoBehaviour {

    [SerializeField]
    private GameObject[] backgrounds;

    private float lastYPosition;

	// Use this for initialization
	void Start () {
        GetBackgroundAndSetLastY();
	}
	
    void GetBackgroundAndSetLastY() {
        backgrounds = GameObject.FindGameObjectsWithTag("Background");

        lastYPosition = backgrounds[0].transform.position.y;

        foreach(GameObject background in backgrounds) {
            if (background.transform.position.y < lastYPosition) {
                lastYPosition = background.transform.position.y;
            }
        }

    }

    void OnTriggerEnter2D(Collider2D target) {
        if (target.tag == "Background") {
            if (target.transform.position.y == lastYPosition) {
                Vector3 temp = target.transform.position;
                float height = ((BoxCollider2D) target).size.y;

                foreach(GameObject bg in backgrounds) {
                    if (!bg.activeInHierarchy) {
                        temp.y -= height;
                        lastYPosition = temp.y;
                        bg.transform.position = temp;
                        bg.SetActive(true);
                    }
                }

            }
        }
    }

}
