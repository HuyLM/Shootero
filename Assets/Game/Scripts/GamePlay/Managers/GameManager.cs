using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : SingletonBind<GameManager> {
    [SerializeField] private GameLoader gameLoader;

    [SerializeField] private int currentZoneIndex;
    [SerializeField] private int currentWaveIndex;

    private GameState currentGameState;
    [SerializeField] private float countdownSpawnTime = -1;
    [SerializeField] private float countdownSpawnEnemies = -1f;
    public WaveData CurrentWaveData {
        get {
            return GameResource.Instance.ConquerorData.Zones[currentZoneIndex].WaveDatas[currentWaveIndex];
        }
    }
    public ZoneData CurrentZoneData {
        get {
            return GameResource.Instance.ConquerorData.Zones[currentZoneIndex];
        }
    }
    public int CurrentWaveIndex { get => currentWaveIndex; }
    public int CurrentZoneIndex { get => currentZoneIndex; }


    public GameLoader GameLoader { get => gameLoader; }

    public bool IsInTimeSpawn {
        get {
            return countdownSpawnTime > 0;
        }
    }

    public void SetState(GameState state) {
        currentGameState = state;
    }

    public GameState GetState() {
        return currentGameState;
    }

    private void Start() {
        StartGame();
    }

    public void StartGame() {
        gameLoader.Initalize();
        SetState(GameState.Play);
        StartWave();
    }

    private void StartWave() {
        if(currentGameState != GameState.Play) {
            return;
        }
        EventDispatcher.Instance.Dispatch(EventKey.StartWave);
        CurrentWaveData.Initalize();
        countdownSpawnTime = CurrentWaveData.Time;
        CalculationDelaySpawnEnemy();
    }

    public void CalculationDelaySpawnEnemy() {
        if(countdownSpawnTime > 0) {
            int currentE = gameLoader.Enemies.Count;
            int limitE = CurrentWaveData.Limit;
            float newDelaySpawn = (1.0f * currentE / limitE) * 3;
            if(countdownSpawnEnemies >= 0 && newDelaySpawn < countdownSpawnEnemies) {
                countdownSpawnEnemies = newDelaySpawn;
            }
            else if(countdownSpawnEnemies < 0) {
                countdownSpawnEnemies = newDelaySpawn;
            }
        }
    }

    private void SpawnEnemies() {
        int limitE = CurrentWaveData.Limit;
        int currentE = gameLoader.Enemies.Count;
        int numberEnemyNeedSpawn = limitE - currentE;
        for(int i = 0; i < numberEnemyNeedSpawn; ++i) {
            gameLoader.SpawnEnemy(CurrentWaveData.Difficult, CurrentWaveData.EnemyIds);
        }
    }


    public void Win() {
        currentGameState = GameState.Win;
        Debug.Log("win");
        PopupHUD.Instance.Show<ResultPopup>()
            .SetWave(currentWaveIndex)
            .SetZone(currentZoneIndex)
            .SetTittle("MISSION ACCOMPLISHED");
    }
    public void Lose() {
        PopupHUD.Instance.Show<ResultPopup>()
            .SetWave(currentWaveIndex)
            .SetZone(currentZoneIndex)
            .SetTittle("GAME OVER");
    }


    public void Pause() {
        Time.timeScale = 0;
        currentGameState = GameState.Pause;
    }

    public void Resume() {
        Time.timeScale = 1;
        currentGameState = GameState.Play;
    }

    private void CheckWinWave() {
        if(countdownSpawnTime < 0 && gameLoader.Enemies.Count == 0) {
            StartCoroutine(NextWave());
        }
    }

    private IEnumerator NextWave() {
        yield return new WaitForSeconds(2f);
        bool isWin = CheckWinGame();
        if(!isWin) {
            if(gameLoader.Player.LevelerPlayer.HasUpgradePoint) {
                PopupHUD.Instance.Show<LevelupPopup>();
            }
            yield return new WaitUntil(() => currentGameState == GameState.Play);
            currentWaveIndex++;
            StartWave();
        }

    }

    public void RemoveEnemy(EnemyBase enemy) {
        gameLoader.RemoveEnemy(enemy);
        CheckWinWave();
    }

    private bool CheckWinGame() {
        if(currentGameState != GameState.Play) {
            return false;
        }
        if(currentWaveIndex >= CurrentZoneData.WaveDatas.Length) {
            Win();
            return true;
        }
        return false;
    }


    private void Update() {
        if(currentGameState != GameState.Pause) {
            if(countdownSpawnTime >= 0) {
                countdownSpawnTime -= Time.deltaTime;
            }

            if(countdownSpawnEnemies >= 0) {
                countdownSpawnEnemies -= Time.deltaTime;
                if(countdownSpawnEnemies < 0) {
                    SpawnEnemies();
                }
            }
        }
    }

}

public enum GameState {
    None, Play, Lose, Win, Pause
}
