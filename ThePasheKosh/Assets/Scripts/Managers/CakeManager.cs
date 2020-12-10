using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;



public class CakeManager : Singleton<CakeManager>
{
    public Transform screenCenterPoint;
    
    private CakeInfo currentCakeInfo;
    private Cake currentCake;

    public void PutTheCakes(CakeInfo cakeInfo)
    {
        currentCakeInfo = cakeInfo;
        currentCake = cakeInfo.cakePrefab.GetComponent<Cake>();
        
        showCake(cakeInfo);

        EventManager.StartListening(Events.CakePieceDestroyed, CakeDestroyedHandling);

        StartCoroutine(HealthUpdateCo());
    }

    IEnumerator HealthUpdateCo()
    {
        while (true)
        {
            GameManager.Instance.UpdateHealth(currentCake.Health, currentCake.maxHealth);
            
            yield return new WaitForSeconds(0.3f);
        }
    }

    void CakeDestroyedHandling()
    {
        currentCakeInfo.cakePrefab.SetActive(false);

        EventManager.TriggerEvent(Events.GameOver);
    }

    void showCake(CakeInfo cakeInfo)
    {
        cakeInfo.cakePrefab.SetActive(true);
        cakeInfo.cakePrefab.transform.position = screenCenterPoint.position;

        var cake = cakeInfo.cakePrefab.GetComponent<Cake>();
        cake.InitializeCake(cakeInfo.cakeSprites);
    }

    protected override void Awake()
    {
        base.Awake();
        
        /*gameObjectOfOnePiece.SetActive(false);
        for (int i = 0; i < gameObjectOfTwoPieces.Length; i++) gameObjectOfTwoPieces[i].SetActive(false);
        for (int i = 0; i < gameObjectOfFourPieces.Length; i++) gameObjectOfFourPieces[i].SetActive(false);
        */
    }

    private void Start()
    {
    }
    
    public static List<int> stringAnagram(List<string> dictionary, List<string> query)
    {
        List<int> result = new List<int>();
        
        
        for(int i = 0; i < query.Count; i++)
        {
            int individualResult = 0;
            
            var anagrams = GetAnagram(query[i]);
            
            for (int j = 0; j < anagrams.Count; j++)
            {
                if(dictionary.Contains(anagrams[j]))
                {
                    individualResult++;
                }
            }
            
            result.Add(individualResult);
        }
        
        return result;
        
    }
    
    private static List<string> GetAnagram(string query)
    {
        var anagrams = new List<string>();
        
        GetAnagram2(anagrams, query, "");
        
        return anagrams;
    }
    
    private static void GetAnagram2(List<string> p, string q, IEnumerable<char> r)
    {
        
        if(q.Length == 1)
        {
            r.Append(q[0]);
            p.Add((string) r);
        }
        else
        {
            for (int i = 0; i < q.Length; i++)
            {
                GetAnagram2(p, q.Remove(i, 1), r.Append(q[i]));
            }
        }
    }
}
