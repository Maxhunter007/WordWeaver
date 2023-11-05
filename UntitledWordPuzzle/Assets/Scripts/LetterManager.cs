using System;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

public class LetterManager : MonoBehaviour
{
    [SerializeField] private GameObject ContainerPrefab;
    [SerializeField] private GameObject LetterPrefab;

    [SerializeField] private float ContainerDistance;

    private Puzzle _activePuzzle;
    private GameObject[] _containers;
    private GameObject[] _letters;
    private Sprite _boxSprite;
    [SerializeField] private string ContainedLetters;
    private bool _activepuzzleSolved;

    public bool SolutionCheckAvailable = false;


    public void Awake()
    {
        _boxSprite = Resources.Load<Sprite>("Pics/Box");
    }
    
    public void Enable(Puzzle puzzle)
    {
        SolutionCheckAvailable = false;
        
        puzzle.TogglePuzzleClickability();
        _activePuzzle = puzzle;
        _containers = new GameObject[_activePuzzle.LetterAmount];
        _letters = new GameObject[_activePuzzle.CurrentLetters.Length];

        var initializationPosition = -(ContainerDistance + _boxSprite.rect.width * ContainerPrefab.transform.localScale.x / _boxSprite.pixelsPerUnit / 2) * (_activePuzzle.LetterAmount - 1);
        var spaces = 0;
        for (int i = 0; i < _activePuzzle.LetterAmount; i++)
        {
            if (i < _activePuzzle.Solution.Length && _activePuzzle.Solution[i].Equals(' '))
            {
                initializationPosition += 2 * ContainerPrefab.transform.localScale.x * (ContainerDistance + _boxSprite.rect.width / _boxSprite.pixelsPerUnit / 2);
                spaces++;
                continue;
            }
            var container = Instantiate(ContainerPrefab, transform.parent);
            container.transform.localPosition = new Vector3(initializationPosition, 7f);
            initializationPosition += 2 * ContainerPrefab.transform.localScale.x * (ContainerDistance + _boxSprite.rect.width / _boxSprite.pixelsPerUnit / 2);
            _containers[i] = container;

            if (i < _activePuzzle.CurrentLetters.Length)
            {
                Vector3 position = new(container.transform.position.x, container.transform.position.y);
                var letter = Instantiate(LetterPrefab, position, Quaternion.identity);
                letter.GetComponent<TMP_Text>().text = "" + _activePuzzle.CurrentLetters[i-spaces];
                _letters[i] = letter;
            }
        }

        SolutionCheckAvailable = true;
    }

    public void Disable()
    {
        SolutionCheckAvailable = false;
        
        if (_activePuzzle)
        {
            if(!_activepuzzleSolved)
            {
                _activePuzzle.TogglePuzzleClickability();
            }
            _activepuzzleSolved = false;

            for (int i = 0; i < _containers.Length; i++)
            {
                Destroy(_containers[i]);
            }
            _containers = null;

            for (int i = 0; i < _letters.Length; i++)
            {
                Destroy(_letters[i]);
            }
            _letters = null;
        }
        
        SolutionCheckAvailable = true;
    }

    public void CheckForSolution()
    {
        if(!SolutionCheckAvailable) return;
        ContainedLetters = "";
        foreach (var container in _containers)
        {
            if (container)
            {
                var letterContainer = container.GetComponent<LetterContainer>();
                if (letterContainer.ContainedLetter)
                {
                    ContainedLetters += letterContainer.ContainedLetter.TextContent;
                }
            }else
            {
                ContainedLetters += ' ';
            }
            
        }
        Debug.Log(ContainedLetters);
        if (ContainedLetters.ToUpper().Equals(_activePuzzle.Solution.ToUpper()))
        {
            _activepuzzleSolved = true;
            Disable();
            _activePuzzle.SetPuzzleSolved();
            _activePuzzle = null;
        }
    }

}