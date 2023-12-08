using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;
using UnityEngine.UI;

public class CharacterStats : MonoBehaviour
{
    [SerializeField]
    float maxHealth = 100;
   public float power = 10;
    int killScore = 200;


    public float CurretnHealth {  get; private set; }
    
    // Start is called before the first frame update
    void Start()
    {
        CurretnHealth = maxHealth;
    }

    public void ChangedHealth(float value)
    {
        //curretnHealth += value;


        CurretnHealth = Mathf.Max(CurretnHealth, value, 0 ,maxHealth);
        Debug.Log("Current Health" + CurretnHealth + "/" + maxHealth);
        if (transform.CompareTag("enemy"))
            transform.Find("Canvas").GetChild(1).GetComponent<UnityEngine.UI.Image>().fillAmount = CurretnHealth / maxHealth;

        if (CurretnHealth <= 0)
            Die();


    }

     void Die()
    {
        if (transform.CompareTag("Player"))
        {
            //oyun biter
        }
        else if (transform.CompareTag("enemy"))
        {

            LevelManager.instance.score += killScore;
            Destroy(gameObject);
            //düþman yok olur
            Instantiate(LevelManager.instance.Particles[2], transform.position, transform.rotation);

        }
    }
}
