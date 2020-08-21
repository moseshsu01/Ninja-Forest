using UnityEngine;

public class Level1Tip : MonoBehaviour
{

    public GameObject tipDisplay;
    public GameObject player;

    // Update is called once per frame
    void Update()
    {
        float position = player.GetComponent<Transform>().position.x;
        if (-15f < position && position < 10f)
        {
            tipDisplay.SetActive(true);
        } else
        {
            tipDisplay.SetActive(false);
        }
    }
}
