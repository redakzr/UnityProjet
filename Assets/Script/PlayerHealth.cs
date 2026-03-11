using UnityEngine;
using TMPro;
using System.Collections;
 
public class PlayerHealth : MonoBehaviour
{
    [SerializeField]
    private int currentLifePoints;
    [SerializeField]
    private int maxLifePoints;
    [SerializeField]
    private TextMeshProUGUI currentLifePointsText;
 
    private bool isInvulnerable = false;
 
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        currentLifePoints = maxLifePoints;
        currentLifePointsText.SetText(currentLifePoints.ToString());
 
    }
 
   
    public void TakeDamage()
    {
        if (isInvulnerable)
        {
            return;
        }
        currentLifePoints = Mathf.Clamp(
        currentLifePoints - 1,
        0,
        maxLifePoints);
        currentLifePointsText.SetText(currentLifePoints.ToString());
    }
 
    IEnumerator InvulnerableFlash()
    {
        isInvulnerable = true;
 
        yield return new WaitForSeconds(3);
        Debug.Log("Fini");
    }
 
}