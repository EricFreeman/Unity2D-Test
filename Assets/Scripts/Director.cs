using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using Assets.Models;
using UnityEngine;

public class Director : MonoBehaviour
{
    private float _waveTime;
    private List<Wave> _waves = new List<Wave>(); 

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
                EnemyList = new List<GameObject>()
            };

            foreach (XmlNode enemy in wave.SelectNodes("Enemy"))
            {
                var e = (GameObject)Instantiate(
                    Resources.Load("Prefabs/" + enemy.Attributes["Type"].InnerText));
                var ecom = e.GetComponent<Enemy>();
                ecom.Y = float.Parse(enemy.Attributes["Y"].InnerText);
                ecom.Spawn = float.Parse(enemy.Attributes["Spawn"].InnerText);
                ecom.transform.Translate(10, 0, 0);
                e.gameObject.SetActive(false);

                w.EnemyList.Add(e);
            }

            _waves.Add(w);
        }
    }

    // Update is called once per frame
    void Update()
    {
        _waveTime += Time.deltaTime;

        var toEnable = _waves[0].EnemyList
            .Where(x => x.GetComponent<Enemy>().Spawn < _waveTime)
            .ToList();

        foreach (var e in toEnable)
        {
            e.SetActive(true);
            _waves[0].EnemyList.Remove(e);
        }
    }
}