using UnityEngine;

public class Patterns : MonoBehaviour
{
    GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < player.GetComponent<Transform>().position.x - 60)
        {
            Destroy(gameObject);
        }
    }
}
