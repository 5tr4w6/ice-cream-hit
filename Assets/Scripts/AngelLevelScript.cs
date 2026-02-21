using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class AngelLevelScript : MonoBehaviour
{
    GameController GameController;
    GameObject Scoop;
    GameObject Wing;

    int stagesLeft = 6;

    int moreSpoons = 10;

    public AudioSource angelScream;

    void Start()
    {
        GameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        Scoop = GameObject.FindGameObjectWithTag("Scoop");
    }
    void Update()
    {
        AddSpoons();
    }

    public void AddSpoons()
    {
        int shotSpoonCount = 0;
        foreach (Transform child in GameController.panelSpoons.transform)
        {
            if (child.CompareTag("UsedIconSpoon"))
                shotSpoonCount++;
        }
        bool shotAllSpoons = shotSpoonCount == GameController.spoonCount;

        if (shotAllSpoons && stagesLeft != 0)
        {
            foreach (Transform child in Scoop.transform)
            {
                Destroy(child.gameObject);
            }

            GameController.spoonCount += moreSpoons;
            moreSpoons++;

            stagesLeft--;
            Debug.Log("Stages Left" + stagesLeft);

            foreach (GameObject child in GameObject.FindGameObjectsWithTag("UsedIconSpoon"))
            {
                Destroy(child);
            }

            GameController.SetInitialDisplaySpoonCount(moreSpoons);

            StartCoroutine(DestroyWing());
        }
        else if (shotAllSpoons && stagesLeft == 0)
        {
            GameController.GameOverSequence();
        }
    }
    IEnumerator DestroyWing()
    {
        Wing = GameObject.FindGameObjectWithTag("Wing");
        Wing.GetComponent<Rigidbody2D>().gravityScale = 1;

        angelScream.Play();

        yield return new WaitForSecondsRealtime(2f);
        Destroy(Wing);
    }
}
