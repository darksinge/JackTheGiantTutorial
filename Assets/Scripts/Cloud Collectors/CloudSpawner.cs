using UnityEngine;
using System.Collections;
using System.Linq;

public class CloudSpawner : MonoBehaviour {

    [SerializeField]
    private GameObject[] clouds;

    private float distanceBetweenClouds = 3f;

    private float minX, maxX;

    private float lastCloudPositionY;

    private int controlX;

    [SerializeField]
    private GameObject[] collectables;

    private GameObject player;

    void Awake() {
        controlX = 0;
        SetMinAndMaxX();
        CreateClouds();
        player = GameObject.Find("Player");

        foreach(GameObject collectable in collectables) {
            collectable.SetActive(false);
        }

    }

    void Start() {
        PositionThePlayer();
    }

    void CreateClouds() {
        Shuffle(clouds);

        float positionY = 0;

        foreach(GameObject cloud in clouds) {

            Vector3 temp = cloud.transform.position;

            temp.y = positionY;

            if (controlX == 0) {

                temp.x = Random.Range(0, maxX);
                controlX = 1;

            } else if (controlX == 1) {

                temp.x = Random.Range(0, minX);
                controlX = 2;

            } else if (controlX == 2) {

                temp.x = Random.Range(1.0f, maxX);
                controlX = 3;

            } else if (controlX == 3) {

                temp.x = Random.Range(-1.0f, minX);
                controlX = 0;
            }

            lastCloudPositionY = positionY;

            cloud.transform.position = temp;
            positionY -= distanceBetweenClouds;

        }

    }

    void Shuffle(GameObject[] array) {
        for (int i = 0; i < array.Length; i++) {
            GameObject temp = array[i];
            int random = Random.Range(i, array.Length);
            array[i] = array[random];
            array[random] = temp;
        }
    }

    void SetMinAndMaxX() {
        Vector3 bounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));

        minX = -bounds.x + 0.5f;
        maxX = bounds.x - 0.5f;
    }

    void PositionThePlayer() {

        // getting back clouds
        GameObject[] darkClouds = GameObject.FindGameObjectsWithTag("Deadly");

        // getting clouds in game
        GameObject[] clouds = GameObject.FindGameObjectsWithTag("Cloud");

        foreach(GameObject darkCloud in darkClouds) {
            if (darkCloud.transform.position.y == 0) {
                Vector3 t = darkCloud.transform.position;
                darkCloud.transform.position = new Vector3(clouds.First().transform.position.x,
                                                           clouds.First().transform.position.y,
                                                           clouds.First().transform.position.z);
                clouds.First().transform.position = t;
                break;
            }
        }

        Vector3 temp = clouds.First().transform.position;
        GameObject firstCloud = clouds.First();
        foreach(GameObject cloud in clouds) {
            if (temp.y < cloud.transform.position.y) {
                temp = cloud.transform.position;
                firstCloud = cloud;
            }
        }

        // positioning the player above the cloud
        player.transform.position = new Vector3(temp.x, temp.y + player.transform.localScale.y, temp.z);
    }

    void OnTriggerEnter2D(Collider2D target) {

        if (!(target.tag == "Deadly" || target.tag == "Cloud")) 
            return;

        if (target.transform.position.y == lastCloudPositionY) {

            Vector3 temp = target.transform.position;
            Shuffle(clouds);
            Shuffle(collectables);

            foreach(GameObject cloud in clouds) {

                if (!cloud.activeInHierarchy) {

                    if (controlX == 0) {
                        temp.x = Random.Range(0, maxX);
                        controlX = 1;
                    } else if (controlX == 1) {
                        temp.x = Random.Range(0, minX);
                        controlX = 2;
                    } else if (controlX == 2) {
                        temp.x = Random.Range(1.0f, maxX);
                        controlX = 3;
                    } else if (controlX == 3) {
                        temp.x = Random.Range(-1.0f, minX);
                        controlX = 0;
                    }

                    temp.y -= distanceBetweenClouds;

                    lastCloudPositionY = temp.y;

                    cloud.transform.position = temp;
                    cloud.SetActive(true);

                    int random = Random.Range(0, collectables.Length);

                    if (cloud.tag != "Deadly") {
                        
                        if (!collectables[random].activeInHierarchy) {
                            Vector3 temp2 = cloud.transform.position;
                            temp2.y += 0.7f;

                            if (collectables[random].tag == "Life") {

                                if (PlayerScore.GetLifeCount() < 3) {
                                    collectables[random].transform.position = temp2;
                                    collectables[random].SetActive(true);
                                }

                            } else {
                                collectables[random].transform.position = temp2;
                                collectables[random].SetActive(true);
                            } // else

                        } // if collectable is not active

                    } // if clouds.tag != Deadly

                } // if clouds is not activate

            } // loop through clouds

        } // if target transform position == lastCloudPosition

    } // On Trigger enter 2D

} // CloudSpawner

