using OWML.Common;
using OWML.ModHelper;
using UnityEngine;

namespace Crowbar
{
    public class Crowbarmod : ModBehaviour
    {
        private GameObject duckGM;
        private void Start ()
        {
            var duck = ModHelper.Assets.Load3DObject("duck.obj", "duck.png");
            duck.Loaded += OnDuckLoaded;
            ModHelper.Events.Event += OnEvent;
        }

        private void OnEvent(MonoBehaviour behaviour, Events ev)
        {
            if (ev == Events.AfterAwake)
            {
                var duck1 = GameObject.Find("duck");
                duckGM = new GameObject("DuckTool");
                duckGM.transform.parent = GameObject.Find("PlayerCamera").transform;
                duck1.transform.parent = duckGM.transform;
                ModHelper.Console.WriteLine($"Parente de duck1 {duck1.transform.parent.name}", MessageType.Info);
                ModHelper.Console.WriteLine($"Parente de DuckGm {duckGM.transform.parent.name}", MessageType.Info);
            }
        }
        private void OnDuckLoaded (GameObject duck)
        {
            duck.SetActive(false);
        }

        private void Update ()
        {
            if (Input.GetMouseButtonDown(0))
            {
                //PlayerTool playerTool = this._crowbar;
                ///playerTool.EquipTool();
                //this._equippedTool = playerTool;
            }
        }
    }
}
