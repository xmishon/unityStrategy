using System;
using UnityEngine;
using Newtonsoft.Json;
using System.Collections.Generic;

[System.Serializable]
public class JsonUtils : MonoBehaviour
{
    public TextAsset textJSON;
    public Root root;

    [Serializable]
    public class Root
    {
        [JsonProperty("template")]
        public List<List<int>> Template { get; set; }

        [JsonProperty("parts")]
        public List<List<List<int>>> Parts { get; set; }
    }

    void Start()
    {
        root = JsonConvert.DeserializeObject<Root>(textJSON.text);

        Debug.Log(root.Parts[0][0][0]);
    }
}