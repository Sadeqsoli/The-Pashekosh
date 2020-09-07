using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CakeManager : Singleton<CakeManager>
{
    public GameObject gameObjectOfOnePiece;
    public GameObject[] gameObjectOfTwoPieces;
    public GameObject[] gameObjectOfFourPieces;

    List<CakePiece> existedPieces;

    float totalHealth;

    public void PutTheCakes(CakeStruct cake, PieceNumber pieceNum)
    {
        existedPieces = new List<CakePiece>();


        switch (pieceNum) 
        {
            case PieceNumber.One:
                showCake(gameObjectOfOnePiece, cake.wholeCake, cake.maxHealth);
                break;

            case PieceNumber.Two:
                for(int i = 0; i < 2; i++)
                {
                    showCake(gameObjectOfTwoPieces[i], cake.cake2Pieces[i], cake.maxHealth / 1.5f);
                }
                break;
            case PieceNumber.Four:
                for (int i = 0; i < 4; i++)
                {
                    showCake(gameObjectOfFourPieces[i], cake.cake4Pieces[i], cake.maxHealth / 3f);
                }
                break;
        }

        EventManager.StartListening("CakePieceDestroyed", CakeDestroyedHandling);
    }

    IEnumerator HealthUpdateCo()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.3f);
            UpdateHealth();
        }
    }

    public void UpdateHealth()
    {
        totalHealth = 0;
        for(int i = 0; i < existedPieces.Count; i++)
        {
            totalHealth += existedPieces[i].Health;
        }

        GameManager.Instance.UpdateHealth(totalHealth);
    }

    void CakeDestroyedHandling(GameObject cakePieceGO)
    {
        CakePiece cakePieceComp = cakePieceGO.GetComponent<CakePiece>();
        existedPieces.Remove(cakePieceComp);

        cakePieceGO.SetActive(false);

        if(existedPieces.Count == 0)
        {
            EventManager.TriggerEvent("GameOver");
        }
    }

    void showCake(GameObject cakePieceGameObject, Sprite cakeSprite, float maxHealth)
    {
        cakePieceGameObject.SetActive(true);

        cakePieceGameObject.GetComponent<SpriteRenderer>().sprite = cakeSprite;
        CakePiece cakePieceComp = cakePieceGameObject.GetComponent<CakePiece>();
        cakePieceComp.InitializeCake(maxHealth);

        existedPieces.Add(cakePieceComp);
    }

    protected override void Awake()
    {
        base.Awake();

        gameObjectOfOnePiece.SetActive(false);
        for (int i = 0; i < gameObjectOfTwoPieces.Length; i++) gameObjectOfTwoPieces[i].SetActive(false);
        for (int i = 0; i < gameObjectOfFourPieces.Length; i++) gameObjectOfFourPieces[i].SetActive(false);
    }

    private void Start()
    {
        StartCoroutine(HealthUpdateCo());
    }
}
