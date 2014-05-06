using System.Collections.Generic;
using System.Linq;
using System.Xml;
using Assets.Extensions;
using Assets.Models;
using Assets.Services;
using UnityEngine;

namespace Assets.Scripts
{
    public class Director : MonoBehaviour
    {
        private float _waveTime;
        private float _waveDelay;
        private readonly List<Wave> _waves = new List<Wave>();
        private float _money;
        private bool _isGameSaved;

        private bool _isPlayerDead;
        private bool _isLevelOver;

        public Transform LevelCompleteGui;

        public float Money
        {
            get { return _money; }
            set
            {
                _money = value;
                GameObject.Find("MoneyText").GetComponent<UILabel>().text = "Money: $" + _money;
            }
        }

        private void Start()
        {
            var level = PlayerPrefs.GetString("SelectedLevel");
            if (level.IsEmpty()) level = "TestLevel"; // this is only really for debugging and will never happen in the real game

            LoadLevel(level);
        }

        private void LoadLevel(string levelName)
        {
            var doc = new XmlDocument();
            doc.Load("Assets/Resources/Levels/{0}.xml".ToFormat(levelName));
            var waves = doc.SelectSingleNode("Waves");

            foreach (XmlNode wave in waves.SelectNodes("Wave"))
            {
                var w = new Wave
                {
                    BeforeWaveDelay = float.Parse(wave.GetAttributeOrDefault("BeforeWaveDelay", "0")),
                    EnemiesToSpawn = new List<GameObject>()
                };

                foreach (XmlNode enemy in wave.SelectNodes("Enemy"))
                {
                    var e = (GameObject) Instantiate(
                        Resources.Load("Prefabs/Enemies/" + enemy.GetAttributeOrDefault("Type", "Popcorn")));
                    var ecom = e.GetComponent<Enemy>();
                    ecom.X = float.Parse(enemy.GetAttributeOrDefault("X", "0"));
                    ecom.Spawn = float.Parse(enemy.GetAttributeOrDefault("Spawn", "0"));
                    ecom.Speed = float.Parse(enemy.GetAttributeOrDefault("Speed", "5"));
                    ecom.transform.Translate(0, 17, 0);
                    e.gameObject.SetActive(false);

                    w.EnemiesToSpawn.Add(e);
                }

                _waves.Add(w);
            }
        }

        void ShowLevelCompleteScreen()
        {
            LevelCompleteGui.gameObject.SetActive(true);

            var text = "Level Over\r\n\r\n";
            text += "Level Loot: {0}\r\n".ToFormat(_money.ToString("c"));

            if (_isPlayerDead)
            {
                text += "Death Penalty (25%): {0}\r\n".ToFormat((_money*-.25).ToString("c"));
                text += "Total Level Loot: {0}".ToFormat((_money * .75).ToString("c"));
                SaveGame(_money * .75f);
            }

            GameObject.Find("LevelCompleteLabel").GetComponent<UILabel>().text = text;

            SaveGame(_money);
        }

        void SaveGame(float totalEarned)
        {
            if (!_isGameSaved)
            {
                _isGameSaved = true;
                var manager = new XmlManager<PlayerModel>();
                var player = manager.Load("savegame1.xml");
                player.Money += totalEarned;
                manager.Save("savegame1.xml", player);
            }
        }

        // Update is called once per frame
        private void Update()
        {
            if (_isPlayerDead || _isLevelOver)
            {
                ShowLevelCompleteScreen();
            }
            var p = GameObject.FindGameObjectWithTag("Player");
            if (p != null)
            {
                Money = p.GetComponent<Player>().Money;

                _waveDelay -= Time.deltaTime;

                // If there is a new wave to spawn AND the delay before next wave is up
                var currentWave = _waves.FirstOrDefault();
                if (currentWave != null && _waveDelay < 0)
                {
                    _waveTime += Time.deltaTime;

                    // Spawn the next enemies in the wave once it's time
                    var toEnable = currentWave.EnemiesToSpawn
                        .Where(x => x.GetComponent<Enemy>().Spawn < _waveTime)
                        .ToList();

                    // Enable correct enemies
                    foreach (var e in toEnable)
                    {
                        e.SetActive(true);
                        currentWave.EnemiesToSpawn.Remove(e);
                    }

                    // If all enemies in wave are dead, pop it off and reset delay
                    if (currentWave.EnemiesToSpawn.Count == 0 &&
                        !GameObject.FindGameObjectsWithTag("Enemy").Any())
                    {
                        _waveTime = 0;
                        _waves.RemoveAt(0);
                        var newWave = _waves.FirstOrDefault();

                        if (newWave != null)
                            _waveDelay = newWave.BeforeWaveDelay;
                        else
                            _isLevelOver = true;
                    }
                }
            }
            else
            {
                _isPlayerDead = true;
            }
        }
    }
}