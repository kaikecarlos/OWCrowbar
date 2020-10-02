using UnityEngine;
using OWML.ModHelper;
using OWML.Common;

namespace Crowbar
{
    public class Crowbar : PlayerTool
    {
        protected DampedSpringQuat _moveSpring = new DampedSpringQuat();
        protected Transform _stowTransform = GameObject.Find("ToolStowTransform").transform;
        protected Transform _holdTransform = GameObject.Find("ToolHoldTransform").transform;

        private Transform _transform;
        public GameObject _crowbarGameObject;
        protected bool _isEquipped;
        protected bool __isPuttingAway;

        private void Awake ()
        {
            this._transform = base.transform;
        }
        protected override void Start()
        {
            base.Start();
        }

        private void OnEnable ()
        {
            this._crowbarGameObject.SetActive(true);
        }
        private void OnDisable ()
        {
            this._crowbarGameObject.SetActive(false);
        }

        public override void EquipTool()
        {
            base.EquipTool();
            GlobalMessenger<Crowbar>.FireEvent("EquipSignalscope", this);
        }
        public override void UnequipTool()
        {
            base.UnequipTool();
            GlobalMessenger.FireEvent("UnequipSignalscope");
        }

        protected override void Update()
        {
            base.Update();
            if (!this._isEquipped || this._isPuttingAway)
            {
                return;
            }
        }
    }
}
