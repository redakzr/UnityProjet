using UnityEngine;
using UnityEngine.UI;
 
public class HealthBar : MonoBehaviour
{
    [SerializeField]
    private Image fillImage;
 
    
    public void SetHealth(float healthNormalized)
    {
        fillImage.fillAmount = healthNormalized;
        
    }
}