using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;
using System.IO;
using System.Text;
// using System.Collections.Generic;

public class DataManager : MonoBehaviour
{

#if UNITY_WEBGL && !UNITY_EDITOR
    [DllImport("__Internal")]
    private static extern void addData(string jsonData);

    [DllImport("__Internal")]
    private static extern void downloadData();

#elif UNITY_STANDALONE || UNITY_EDITOR
    private StreamWriter sw;

#endif

    [System.Serializable]
    public class Data
    {
        public int score;
        public int hit_num;
        public float hit_rate;
        public int playtime;
    }

    // [System.Serializable]
    // public static class Datas
    // {
    //     public string username;
    //     public string datetime;
    //     public int finalScore;
    //     public int hitNum;
    //     public float hitRate;
    //     public List<Log> logs;
    // }

    // [System.Serializable]
    // public static class Log
    // {
    //     public float time;
    //     public string hitPos;
    //     public string target;
    //     public int score;
    // }

    // Datas datas;

    int _id;

    void Start()
    {
#if UNITY_STANDALONE || UNITY_EDITOR
        sw = new StreamWriter(@getNow()+".csv", true, Encoding.GetEncoding("Shift_JIS"));
        string[] s1 = { "id", "score", "hit_num", "hit_rate", "playtime" };
        string s2 = string.Join(",", s1);
        sw.WriteLine(s2);
#endif
        // json = new Json();
        // json.datas = new List<Data>();
    }

    // public void addData(float _time, string _hitPos, string _target, int _score)
    // {
    //     hitCount++;
    //     // Log _log = new Log();
    //     // _log.time = _time;
    //     // _log.hitPos = _hitPos;
    //     // _log.target = _target;
    //     // _log.score = _score;
    //     // datas.logs.Add(_log);
    // }

    public void postData(int _score, int _hitCount, int _triggerCount, int _playtime)
    {
        Data data = new Data();
        data.score = _score;
        data.hit_num = _hitCount;
        data.hit_rate = (float)_hitCount / (float)_triggerCount;
        data.playtime = _playtime;
        string json = JsonUtility.ToJson(data);
        Debug.Log(json);
#if UNITY_WEBGL && !UNITY_EDITOR
        addData(json);
#elif UNITY_STANDALONE || UNITY_EDITOR
        _id++;
        string[] s1 = { _id.ToString(), _score.ToString(), _hitCount.ToString(), ((float)_hitCount / (float)_triggerCount).ToString(), _playtime.ToString() };
        string s2 = string.Join(",", s1);
        sw.WriteLine(s2);
#endif
        // datas.username = "user";
        // datas.finalScore = _score;
        // datas.hitNum = datas.logs.Count;
        // datas.hitRate = (float)datas.logs.Count / (float)_triggerCount;
        // datas.datetime = getNow();
    }

    public void getData()
    {
#if UNITY_WEBGL && !UNITY_EDITOR
        downloadData();
#elif UNITY_STANDALONE || UNITY_EDITOR
        sw.Close();
#endif
    }

    string getNow()
    {
        var now = System.DateTime.Now;
        string year = now.Year.ToString();
        string month = now.Month.ToString();
        if (now.Month < 10) month = "0" + month;
        string day = now.Day.ToString();
        if (now.Day < 10) day = "0" + day;
        string hour = now.Hour.ToString();
        if (now.Hour < 10) hour = "0" + hour;
        string minute = now.Minute.ToString();
        if (now.Minute < 10) minute = "0" + minute;
        string second = now.Second.ToString();
        if (now.Second < 10) second = "0" + second;
        return year + month + day + "_" + hour + minute + second;
    }
}
