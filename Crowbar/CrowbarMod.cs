using OWML.Common;
using OWML.ModHelper;
using UnityEngine;

namespace Crowbar
{
    public class Crowbarmod : ModBehaviour
    {
        private GameObject duckGM;
        private GameObject duck1;
        private Crowbar crowbar;
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
                duck1.transform.position = new Vector3(0, 0, 0);

                duckGM = new GameObject("DuckTool");
                duckGM.SetActive(false);
                duckGM.transform.position = new Vector3(0, 0, 0);
                duckGM.transform.localScale = new Vector3(1, 1, 1);

                crowbar = duckGM.AddComponent<Crowbar>();
                crowbar._crowbarGameObject = GameObject.Find("Props_HEA_Signalscope");
                duckGM.SetActive(true);
                duckGM.transform.parent = GameObject.Find("PlayerCamera").transform;
                duck1.transform.parent = duckGM.transform;
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
                PlayerTool playerTool = null;
                playerTool = crowbar;
                playerTool.EquipTool();
            }
        }
    }
}
