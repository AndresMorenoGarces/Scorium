using UnityEditor;
using AndresMoreno.Editor;

namespace AndresMoreno.Templates {
    public class CommonControllerScriptTemplate : AbstractScriptTemplate{
        protected const string customScriptPath = "CommonControllerScriptTemplate.cs.txt";

        [MenuItem(itemName: "Assets/Create/" + simplyPath + customScriptPath, isValidateFunction: false, priority: 51)]
        public static void CreateScriptFromTemplate() => ProjectWindowUtil.CreateScriptAssetFromTemplateFile(commonPath + customScriptPath, "NewCommonControllerScript.cs");
    }
}
