using Netick.Unity;
using NetickEditor;
using Sirenix.OdinInspector.Editor;
using UnityEditor;

namespace NetickOdinEditor
{
    [CustomEditor(typeof (NetworkBehaviour), true, isFallback = false)]
    [CanEditMultipleObjects]
    public class OdinNetworkBehaviourEditor : OdinEditor
    {
        private NetworkBehaviourEditor _netickInspector;

        protected override void OnEnable()
        {
            base.OnEnable();
            _netickInspector = (NetworkBehaviourEditor)CreateEditor(targets, typeof(NetworkBehaviourEditor));
        }

        protected override void OnDisable()
        {
            base.OnDisable();
            if (_netickInspector != null) 
                UnityEngine.Object.DestroyImmediate(_netickInspector);
        }
        
        public new void DrawDefaultInspector()
        {
            if (_netickInspector != null)
                _netickInspector.DrawNetworkBehaviourInspector();
            
            base.DrawDefaultInspector(); // will draw odin inspector
        }

        public override void OnInspectorGUI()
        {
            this.DrawDefaultInspector();
        }
    }
}