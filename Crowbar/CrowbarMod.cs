using OWML.Common;
using OWML.ModHelper;
using UnityEngine;

namespace Crowbar
{
    public class Crowbarmod : ModBehaviour
    {
        private GameObject duckGM;
        private GameObject duck1;
        private void Start ()
        {
            var duck = ModHelper.Assets.Load3DObject("duck.obj", "duck.png");
            duck.Loaded += OnDuckLoaded;
            ModHelper.Console.WriteLine($"{duck}", MessageType.Info);
            ModHelper.Events.Event += OnEvent;
        }

        private void OnEvent(MonoBehaviour behaviour, Events ev)
        {
            if (ev == Events.AfterAwake)
            {
                duck1.name = "prop_duck";
                ModHelper.Console.WriteLine($"A {duck1.name}", MessageType.Info);
                duckGM = new GameObject("DuckTool");
                duckGM.transform.parent = GameObject.Find("PlayerCamera").transform;
                duck1.transform.parent = duckGM.transform;
                ModHelper.Console.WriteLine($"Parente de duck1 {duck1.transform.parent.name}", MessageType.Info);
                ModHelper.Console.WriteLine($"Parente de DuckGm {duckGM.transform.parent.name}", MessageType.Info);
            }
        }
        private void OnDuckLoaded (GameObject duck)
        {
            duck1 = duck;
            duck1.SetActive(false);
        }

        private void Update ()
        {
            if (Input.GetMouseButtonDown(0))
            {
                duck1.SetActive(true);
            }
        }
    }
}
