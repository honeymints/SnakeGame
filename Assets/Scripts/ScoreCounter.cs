using TMPro;
using UnityEngine;

public class ScoreCounter : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _score;
    public static ScoreCounter Instance { get; private set; }
    private float _currentScore;
    // Start is called before the first frame update
    void Start()
    {
        _currentScore = 0;
    }

    void Awake()
    {
        Instance = this;
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    public void GainScore(int points)
    {
        _currentScore += points;
        _score.text = _currentScore.ToString();
    }
}
