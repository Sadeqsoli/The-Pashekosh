using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CakeManager : Singleton<CakeManager>
{
    public GameObject positionOfOnePiece;
    public GameObject[] positionsOfTwoPieces;
    public GameObject[] positionsOfFourPieces;

    List<GameObject> existedPieces;

    public void PutTheCakes(CakeStruct cake, PieceNumber pieceNum)
    {
        existedPieces = new List<GameObject>();

        switch (pieceNum) 
        {
            case PieceNumber.One:
                showCake(positionOfOnePiece, cake.wholeCake, cake.maxHealth);
                break;

            case PieceNumber.Two:
                for(int i = 0; i < 2; i++)
                {
                    showCake(positionsOfTwoPieces[i], cake.cake2Pieces[i], cake.maxHealth / 1.5f);
                }
                break;
            case PieceNumber.Four:
                for (int i = 0; i < 4; i++)
                {
                    showCake(positionsOfFourPieces[i], cake.cake4Pieces[i], cake.maxHealth / 3f);
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

    void showCake(GameObject position, Sprite cakeSprite, float maxHealth)
    {
        position.SetActive(true);
        position.GetComponent<SpriteRenderer>().sprite = cakeSprite;
        position.GetComponent<CakePiece>().InitializeCake(maxHealth);

        existedPieces.Add(position);
    }

    protected override void Awake()
    {
        base.Awake();

        positionOfOnePiece.SetActive(false);
        for (int i = 0; i < positionsOfTwoPieces.Length; i++) positionsOfTwoPieces[i].SetActive(false);
        for (int i = 0; i < positionsOfFourPieces.Length; i++) positionsOfFourPieces[i].SetActive(false);
    }

}
