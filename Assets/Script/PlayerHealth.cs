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

    [SerializeField]
    private SpriteRenderer sr;

    [SerializeField]
    private HealthBar healthBar;
 
    private bool isInvulnerable = false;
 
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        currentLifePoints = maxLifePoints;
        currentLifePointsText.SetText(currentLifePoints.ToString());
        healthBar.SetHealth((float)currentLifePoints / maxLifePoints);
 
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
        healthBar.SetHealth((float)currentLifePoints / maxLifePoints);
        StartCoroutine(InvulnerableFlash());
        currentLifePointsText.SetText(currentLifePoints.ToString());
    }
 
   IEnumerator InvulnerableFlash()
    {
        isInvulnerable = true;
 
        // Durée de l'invulnerabilité
        float invulnerableDuration = 1.25f;
        // Temps écoulé durant la période d'invulnerabilité
        float timeElapsed = 0;
 
        // Durée durant laquelle le sprite est visible ou invisible
        float flashInvulnerabilityDuration = 0.2f;
        // Temps écoulé durant la période de visibilité ou invisibilité
        float flashTimeElapsed = 0;
        bool isVisible = true;
 
        while (timeElapsed < invulnerableDuration)
        {
            timeElapsed += Time.deltaTime;
            flashTimeElapsed += Time.deltaTime;
 
            if (flashTimeElapsed >= flashInvulnerabilityDuration)
            {
                if (isVisible)
                {
                    sr.color = Color.clear;
                } else
                {
                    sr.color = Color.white;
                }
 
                flashTimeElapsed = 0;
                isVisible = !isVisible;
            }
 
            // Attendre le rafraichissement de l'écran
            yield return null;
        }
 
        sr.color = Color.white;
        isInvulnerable = false;
    }
}