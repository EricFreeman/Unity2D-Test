using System.Collections.Generic;
using System.Linq;
using System.Xml;
using Assets.Models;
using UnityEngine;

public class Director : MonoBehaviour
{
    private float _waveTime;
    private float _waveDelay;
    private List<Wave> _waves = new List<Wave>();
    private float _money;

    public float Money
    {
        get { return _money; }
        set
        {
            _money = value;
            GameObject.Find("MoneyText").guiText.text = "Money: $" + _money;
        }
    }

    // Use this for initialization
    void Start()
    {
        var doc = new XmlDocument();
        doc.Load("Assets/Resources/Levels/TestLevel.xml");
        XmlNode waves = doc.SelectSingleNode("Waves");

        foreach (XmlNode wave in waves.SelectNodes("Wave"))
        {
            var w = new Wave
            {
                BeforeWaveDelay =
                    float.Parse(wave.Attributes["BeforeWaveDelay"].InnerText),
                EnemiesToSpawn = new List<GameObject>()
            };

            foreach (XmlNode enemy in wave.SelectNodes("Enemy"))
            {
                var e = (GameObject)Instantiate(
                    Resources.Load("Prefabs/Enemies/" + enemy.Attributes["Type"].InnerText));
                var ecom = e.GetComponent<Enemy>();
                ecom.X = float.Parse(enemy.Attributes["X"].InnerText);
                ecom.Spawn = float.Parse(enemy.Attributes["Spawn"].InnerText);
                ecom.Speed = float.Parse(enemy.Attributes["Speed"].InnerText);
                ecom.transform.Translate(0, 17, 0);
                e.gameObject.SetActive(false);

                w.EnemiesToSpawn.Add(e);
            }

            _waves.Add(w);
        }
    }

    // Update is called once per frame
    void Update()
    {
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
                {
                    _waveDelay = newWave.BeforeWaveDelay;
                }
            }
        }

        var p = GameObject.FindGameObjectWithTag("Player");
        if (p != null)
        {
            Money = p.GetComponent<Player>().Money;
        }
    }
}