/*
 * Tencent is pleased to support the open source community by making xLua available.
 * Copyright (C) 2016 THL A29 Limited, a Tencent company. All rights reserved.
 * Licensed under the MIT License (the "License"); you may not use this file except in compliance with the License. You may obtain a copy of the License at
 * http://opensource.org/licenses/MIT
 * Unless required by applicable law or agreed to in writing, software distributed under the License is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied. See the License for the specific language governing permissions and limitations under the License.
*/

using UnityEngine;
using System.Collections;
using XLua;
using System.IO;

namespace Tutorial
{
    public class CustomLoader : MonoBehaviour
    {
        public LuaEnv luaenv = null;

        void Awake()
        {
            SaveTextToPersistent();

            luaenv = new LuaEnv();
            luaenv.AddLoader(MyLoader);
        }

        void Update()
        {
            if (luaenv != null)
            {
                luaenv.Tick();
            }
        }

        void OnDestroy()
        {
            luaenv.Dispose();
        }

        private static byte[] MyLoader(ref string fileName)
        {
#if UNITY_EDITOR
            string folder = Path.Combine(Application.dataPath, "Lua");
#else
            string folder = Path.Combine(Application.persistentDataPath, "Lua");
#endif
            string path = Path.Combine(folder, fileName + ".lua");

            return File.ReadAllBytes(path);
        }

        private void SaveTextToPersistent()
        {
            File.WriteAllText(Application.persistentDataPath + "/1.txt", "helloworld");
        }
    }
}
