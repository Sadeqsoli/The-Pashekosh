using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CakeManager : Singleton<CakeManager>
{
    public GameObject gameObjectOfOnePiece;
    public GameObject[] gameObjectOfTwoPieces;
    public GameObject[] gameObjectOfFourPieces;

    List<GameObject> existedPieces;

    public void PutTheCakes(CakeStruct cake, PieceNumber pieceNum)
    {
        existedPieces = new List<GameObject>();

        

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

    void CakeDestroyedHandling(GameObject cakePiece)
    {
        existedPieces.Remove(cakePiece);

        cakePiece.SetActive(false);

        if(existedPieces.Count == 0)
        {
            EventManager.TriggerEvent("GameOver");
        }
    }

    void showCake(GameObject cakePieceGameObject, Sprite cakeSprite, float maxHealth)
    {
        cakePieceGameObject.SetActive(true);

        cakePieceGameObject.GetComponent<SpriteRenderer>().sprite = cakeSprite;
        cakePieceGameObject.GetComponent<CakePiece>().InitializeCake(maxHealth);

        existedPieces.Add(cakePieceGameObject);
    }

    protected override void Awake()
    {
        base.Awake();

        gameObjectOfOnePiece.SetActive(false);
        for (int i = 0; i < gameObjectOfTwoPieces.Length; i++) gameObjectOfTwoPieces[i].SetActive(false);
        for (int i = 0; i < gameObjectOfFourPieces.Length; i++) gameObjectOfFourPieces[i].SetActive(false);
    }

}
