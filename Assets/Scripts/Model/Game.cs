using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
[CLSCompliant(false)]
public class Game
{
    public string app_store_link { get; set; }
    public bool completed { get; set; }
    public bool deleted { get; set; }
    public string _id { get; set; }
    public string name { get; set; }
    public string editor { get; set; }
    public string team { get; set; }
    public string appstore_id { get; set; }
    public object bundle_id { get; set; }
    public string created_at { get; set; }
    public string description { get; set; }
    public string store_link { get; set; }
    public string icon { get; set; }
    public string screenshot { get; set; }
    public string background_image { get; set; }
    public string gcm_api_key { get; set; }
    public string status { get; set; }
    public string orientation { get; set; }
    public string engine { get; set; }
    public string android_name { get; set; }
    public string android_version { get; set; }
    public string ios_name { get; set; }
    public string ios_version { get; set; }
    /*public string name { get; set; }
    public string title { get; set; }*/
    public Game() { }
}
