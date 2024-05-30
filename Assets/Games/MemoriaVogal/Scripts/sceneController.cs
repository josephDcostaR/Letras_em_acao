using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class sceneController : MonoBehaviour
{
    public const int gridRows = 3;
    public const int gridCols = 4;
    public const float offSetX = 1.1f;
    public const float offSetY = 1.4f;
    [SerializeField] private mainCard originalCard;
    [SerializeField] private Sprite[] images;

    private void Start()
    {

        Vector3 startPos = originalCard.transform.position;

        int[] numbers = { 0, 0, 1, 1, 2, 2, 3, 3, 4, 4, 5, 5 };

        numbers = ShuffleArray(numbers);

        for (int i = 0; i < gridCols; i++)
        {
            for (int j = 0; j < gridRows; j++)
            {
                mainCard card;
                if (i == 0 && j == 0)
                {
                    card = originalCard;
                }
                else
                {
                    card = Instantiate(originalCard) as mainCard;
                }

                int index = j * gridCols + i;
                int id = numbers[index];
                Sprite cardImage = images[id];

                card.ChangeSprite(id, images[id]);

                float posX = (offSetX * i) + startPos.x;
                float posY = (offSetY * j) + startPos.y;
                card.transform.position = new Vector3(posX, posY, startPos.z);
            }
        }

    }

    private int[] ShuffleArray(int[] numbers)
    {
        int[] newArray = numbers.Clone() as int[];
        for (int i = 0; i < newArray.Length; i++)
        {
            int tmp = newArray[i];
            int r = Random.Range(i, newArray.Length);
            newArray[i] = newArray[r];
            newArray[r] = tmp;
        }
        return newArray;
    }


    private mainCard _firstRevealed;
    private mainCard _secondRevealed;
    private int _score;
    [SerializeField] private TextMesh Score;
    public GameObject victoryScreen;
    private int _totalPairs = 6;
    private int _foundPairs = 0;

    public bool canReveal
    {
        get { return _secondRevealed == null; }
    }

    public void cardRevealed(mainCard card)
    {
        if (_firstRevealed == null)
        {
            _firstRevealed = card;
        }
        else
        {
            _secondRevealed = card;
            StartCoroutine(CheckMatch());

        }
    }

    private IEnumerator CheckMatch()
    {
        if (_firstRevealed.id == _secondRevealed.id)
        {
            _score++;
            Score.text = "Pontos: " + _score;
            _foundPairs++;

            if (_foundPairs == _totalPairs)
            {
                ShowVictoryScreen();
            }
        }
        else
        {
            yield return new WaitForSeconds(0.5f);

            _firstRevealed.Unreveal();
            _secondRevealed.Unreveal();
        }

        _firstRevealed = null;
        _secondRevealed = null;
    }

    private void ShowVictoryScreen()
    {
      
        victoryScreen.SetActive(true);
    }



}
