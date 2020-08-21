using UnityEngine;

public class ObstacleGenerator : MonoBehaviour
{
    public GameObject Pattern1;
    public GameObject Pattern2;
    public GameObject Pattern3;
    public GameObject Pattern4;
    public GameObject Pattern5;
    public GameObject Pattern6;
    public GameObject Pattern7;
    public GameObject Pattern8;
    public GameObject Pattern9;
    public GameObject Pattern10;
    public GameObject Pattern11;
    public GameObject Pattern12;
    public GameObject Pattern13;
    public GameObject Pattern14;
    public GameObject Pattern15;

    public GameObject player;

    private int index = 0;

    // Update is called once per frame
    void Update()
    {
        if (player.GetComponent<Transform>().position.x >= index - 50)
        {
            generateNewPattern();
        }
    }

    private void generateNewPattern()
    {
        int r = Random.Range(1, 16);
        if (r == 1)
        {
            Instantiate(Pattern1, new Vector3(index, 0, 0), Quaternion.identity);
        }
        else if (r == 2)
        {
            Instantiate(Pattern2, new Vector3(index, 0, 0), Quaternion.identity);
        }
        else if (r == 3)
        {
            Instantiate(Pattern3, new Vector3(index, 0, 0), Quaternion.identity);
        }
        else if (r == 4)
        {
            Instantiate(Pattern4, new Vector3(index, 0, 0), Quaternion.identity);
        }
        else if (r == 5)
        {
            Instantiate(Pattern5, new Vector3(index, 0, 0), Quaternion.identity);
        }
        else if (r == 6)
        {
            Instantiate(Pattern6, new Vector3(index, 0, 0), Quaternion.identity);
        }
        else if (r == 7)
        {
            Instantiate(Pattern7, new Vector3(index, 0, 0), Quaternion.identity);
        }
        else if (r == 8)
        {
            Instantiate(Pattern8, new Vector3(index, 0, 0), Quaternion.identity);
        }
        else if (r == 9)
        {
            Instantiate(Pattern9, new Vector3(index, 0, 0), Quaternion.identity);
        }
        else if (r == 10)
        {
            Instantiate(Pattern10, new Vector3(index, 0, 0), Quaternion.identity);
        }
        else if (r == 11)
        {
            Instantiate(Pattern11, new Vector3(index, 0, 0), Quaternion.identity);
        }
        else if (r == 12)
        {
            Instantiate(Pattern12, new Vector3(index, 0, 0), Quaternion.identity);
        }
        else if (r == 13)
        {
            Instantiate(Pattern13, new Vector3(index, 0, 0), Quaternion.identity);
        }
        else if (r == 14)
        {
            Instantiate(Pattern14, new Vector3(index, 0, 0), Quaternion.identity);
        }
        else if (r == 15)
        {
            Instantiate(Pattern15, new Vector3(index, 0, 0), Quaternion.identity);
        }
        index += 50;
    }
}
