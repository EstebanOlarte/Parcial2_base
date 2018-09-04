using UnityEngine;
using UnityEngine.UI;

public class Shelter : MonoBehaviour
{
    [SerializeField]
    public int maxResistance = 5;

    public Text vida;
    public int MaxResistance
    {
        get
        {
            return maxResistance;
        }
        protected set
        {
            maxResistance = value;
        }
    }

    private void Update()
    {
        vida.text = maxResistance.ToString();

        if (maxResistance <= 0)
        {
            GameObject.Find("Canvas").GetComponent<GameOver>().gameOver();
        }
    }

    public void Damage(int damage)
    {
    }
}