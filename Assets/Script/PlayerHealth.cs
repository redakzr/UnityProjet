using UnityEngine;
using TMPro;
 
public class PlayerHealth : MonoBehaviour
{
    [SerializeField]
    private int currentLifePoints;
    [SerializeField]
    private int maxLifePoints;
    [SerializeField]
    private TextMeshProUGUI currentLifePointsText;
 
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        currentLifePoints = maxLifePoints;
        currentLifePointsText.SetText(currentLifePoints.ToString());
    
    }
 
   
    public void TakeDamage()
    {
        currentLifePoints = Mathf.Clamp(
        currentLifePoints - 1,
        0,
        maxLifePoints);
        currentLifePointsText.SetText(currentLifePoints.ToString());
    }
}