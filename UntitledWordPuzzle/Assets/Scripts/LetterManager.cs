using UnityEngine;

public class LetterManager : MonoBehaviour
{
    [SerializeField] private GameObject ContainerPrefab;

    [SerializeField] private float ContainerDistance;
    
    private Puzzle _activePuzzle;
    private GameObject[] _containers;
    private Sprite _aSprite;
    private Sprite _boxSprite;
    
    public void Awake()
    {
        _aSprite = Resources.Load<Sprite>("Pics/A");
        _boxSprite = Resources.Load<Sprite>("Pics/Box");
    }

    public void Enable(Puzzle puzzle)
    {
        _activePuzzle = puzzle;
        _aSprite = Resources.Load<Sprite>("Pics/A");   //muss später raus
        _boxSprite = Resources.Load<Sprite>("Pics/Box");
        _containers = new GameObject[_activePuzzle.LetterAmount];

        var initializationPosition = -(ContainerDistance + _boxSprite.rect.width * ContainerPrefab.transform.localScale.x / _boxSprite.pixelsPerUnit / 2) * (_activePuzzle.LetterAmount-1);
        
        for (int i = 0; i < _activePuzzle.LetterAmount; i++)
        {
            var gameObject = Instantiate(ContainerPrefab, transform.parent);
            gameObject.transform.localPosition = new Vector3(initializationPosition, 7f);
            initializationPosition += 2 * ContainerPrefab.transform.localScale.x * (ContainerDistance + _boxSprite.rect.width / _boxSprite.pixelsPerUnit / 2);
            _containers[i] = gameObject;
        }
    }

    public void Disable()
    {
        //alle children durchgehen & löschen
        for(int i = 0; i < transform.childCount; i++)
        {
            Destroy(transform.GetChild(0).gameObject);
        }
    }

}
