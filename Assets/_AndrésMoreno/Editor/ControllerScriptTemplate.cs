using UnityEditor;
using AndresMoreno.Editor;

namespace AndresMoreno.Templates {
    public class ControllerScriptTemplate : AbstractScriptTemplate{
        protected const string customScriptPath = "ControllerScriptTemplate.cs.txt";

        [MenuItem(itemName: "Assets/Create/" + simplyPath + customScriptPath, isValidateFunction: false, priority: 51)]
        public static void CreateScriptFromTemplate() => ProjectWindowUtil.CreateScriptAssetFromTemplateFile(commonPath + customScriptPath, "NewControllerScript.cs");
    }
}
