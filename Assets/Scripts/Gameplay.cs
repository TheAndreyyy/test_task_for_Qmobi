using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Gameplay : MonoBehaviour
{

    public GameObject asteroid;
    public GameObject rocket;
    private int _startLevelAsteroidsNum;
    private bool _allAsteroidsOffScreen;
    private int levelAsteroidNum;
    private Camera mainCam;
    private int asteroidLife;
    public GameObject[] obj_player_lives;

    //public GameObject obj_score;
    public Text score_text;

    public int Score = 0;

    int Player_lives = 3;

    private void Start()
    {
        //score_text = obj_score.GetComponent<Text>();//GetComponent<Text>(GameObject.Find("")); 
        asteroid.SetActive(false);
        mainCam = Camera.main;
        _startLevelAsteroidsNum = 2;
        CreateAsteroids(_startLevelAsteroidsNum);
        //Load_State();
    }

    private void Save_State()
    {
        //PlayerPrefs.SetInt("Player_lives", Player_lives);
    }

    private void Load_State()
    {
        //if (PlayerPrefs.GetInt("Player_lives", Player_lives) == 0)
        //{

        //}
        //PlayerPrefs.GetInt("Player_lives", Player_lives);
        //if (Player_lives<1)
        //{
        //    Player_lives = 3;
        //}
        //for (int i = 0; i < obj_player_lives.Length; i++)
        //{
        //    obj_player_lives[i].SetActive(false);
        //}
        //for (int i = 0; i < Player_lives; i++)
        //{
        //    obj_player_lives[i].SetActive(true);
        //}
        //print("we load ur lives = "+Player_lives);
    }

    private void Update()
    {
        score_text.text ="Score: "+ Score.ToString();
        //print("Score: " + Score.ToString());
        //RenderSettings.skybox.SetFloat("_Rotation", Time.time * 0.8f);

        if (asteroidLife <= 0)
        {
            asteroidLife = 6;
            CreateAsteroids(1);
        }

        float sceneWidth = mainCam.orthographicSize * 2 * mainCam.aspect;
        float sceneHeight = mainCam.orthographicSize * 2;
        float sceneRightEdge = sceneWidth / 2;
        float sceneLeftEdge = sceneRightEdge * -1;
        float sceneTopEdge = sceneHeight / 2;
        float sceneBottomEdge = sceneTopEdge * -1;

        _allAsteroidsOffScreen = true;

    }

    public void Inc_Score(int count)
    {
        Score =Score+count;//+count.ToString();
    }

    private void CreateAsteroids(float asteroidsNum)
    {
        for (int i = 1; i <= asteroidsNum; i++)
        {
            GameObject AsteroidClone = Instantiate(asteroid, new Vector2(Random.Range(-10, 10), 6f), transform.rotation);
            AsteroidClone.GetComponent<Asteroid>().SetGeneration(1);
            AsteroidClone.SetActive(true);
        }
    }

    public void RocketFail()
    {
        //Cursor.visible = true;
        Player_lives--;
        if (Player_lives < 1)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        for (int i = 0; i < obj_player_lives.Length; i++)
        {
            obj_player_lives[i].SetActive(false);
        }
        for (int i = 0; i < Player_lives; i++)
        {
            obj_player_lives[i].SetActive(true);
        }
        //print(Player_lives);
        //Save_State();
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        //print("GAME OVER");

    }

    public void asterodDestroyed()
    {
        asteroidLife--;
    }

    public int startLevelAsteroidsNum
    {
        get { return _startLevelAsteroidsNum; }
    }

    public bool allAsteroidsOffScreen
    {
        get { return _allAsteroidsOffScreen; }
    }

}