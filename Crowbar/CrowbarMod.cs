using OWML.Common;
using OWML.ModHelper;
using UnityEngine;

namespace Crowbar
{
    public class Crowbarmod : ModBehaviour
    {
        private GameObject duckGameObject;
        private GameObject duckModel;
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
                duckGameObject = new GameObject("DuckTool");
                duckGameObject.transform.parent = GameObject.Find("PlayerCamera").transform;
                duckGameObject.transform.position = new Vector3(0, 0, 0);
                duckGameObject.transform.localScale = new Vector3(1, 1, 1);
                duckGameObject.SetActive(false);

                duckModel.transform.parent = duckGameObject.transform;
                duckModel.transform.position = new Vector3(0, -0.42f, 0.5f);
                duckModel.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);

                crowbar = duckGameObject.AddComponent<Crowbar>();
                crowbar._crowbarGameObject = duckModel;
                duckGameObject.SetActive(true);
                // Debug
                ModHelper.Console.WriteLine($"{duckModel.transform.parent}");
                ModHelper.Console.WriteLine($"{duckGameObject.transform.parent}");
            }
        }
        private void OnDuckLoaded (GameObject duck)
        {
            duckModel = duck;
            duckModel.name = "Props_HEA_Duck";
            duckModel.SetActive(false);
        }

        private void Update ()
        {
            if (Input.GetMouseButtonDown(0))
            {
                PlayerTool playerTool = null;
                playerTool = crowbar;
                playerTool.EquipTool();
                Instantiate(duckModel);
            }
        }
    }
}