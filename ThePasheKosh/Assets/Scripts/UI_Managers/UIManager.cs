using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using RTLTMPro;
using Debug = UnityEngine.Debug;

public class UIManager : MonoBehaviour
{
    
    public RTLTextMeshPro scoreText;
    [Space]
    public Image healthFillBar;

    [Space] 
    public Color green;
    public Color yellow;
    public Color red;

    [Space] 
    public GameObject hitScorePrefab;
    
    [Space]
    [SerializeField]
    private float fillSpeed = 1f;

    private Tweener fillAmount = null;
    private int counter = 0;

    private float lastAmount;
    private float maxHealth = 100f;

    public void Start()
    {
        EventManager.StartListening(Events.InsectKilled, DisplayHitScore);
    }

    public void Initialize(float score = 0, float health = 100)
    {
        scoreText.text = score.ToString("F0");
        maxHealth = health;
        healthFillBar.fillAmount = 1f;
        healthFillBar.color = green;
    }

    public void UpdateScore(float score)
    {
        scoreText.text = score.ToString("F0");
    }

    public void UpdateHealth(float health)
    {
        var amount = health / maxHealth;
        lastAmount = amount;
        
        Color nextColor;
        
        if (amount > 0.66f)
        {
            nextColor = green;
        }
        else if (amount > 0.33f && amount < 0.66f)
        {
            nextColor = yellow;
        }
        else
        {
            nextColor = red;
        }
        
        if (fillAmount == null)
        {
            counter++;
            TweenHealthBar(amount <= 0f ? 0.01f : amount, nextColor);
        }
    }

    private void TweenHealthBar(float amount, Color nextColor)
    {
        //Debug.Log(counter);
        fillAmount = healthFillBar.DOFillAmount(amount, amount).SetEase(Ease.Linear).
            OnComplete(() =>
            {
                fillAmount = null;
                if(healthFillBar.fillAmount <= 0.01f)
                    EventManager.TriggerEvent(Events.ZeroHealth);
                else if(healthFillBar.fillAmount - lastAmount > 0.01f)
                    UpdateHealth(lastAmount * maxHealth);
            });

        healthFillBar.DOColor(nextColor, fillSpeed / amount).SetEase(Ease.Linear);
    }

    private void DisplayHitScore(GameObject insect)
    {
        Insect insectComponent = insect.GetComponent<Insect>();
        if (insectComponent.IsBadInsect)
        {
            var badInsectComponent = insect.GetComponent<BadInsect>();
            
            var hitScore = Instantiate(hitScorePrefab, insect.transform.position, Quaternion.identity);
            hitScore.transform.SetParent(this.gameObject.transform);
            var hitScoreScript = hitScore.GetComponent<HitScore>();
            hitScoreScript.Initialize(badInsectComponent.addedPoints, Color.green);
        }
    }
    




}
