using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;　//追加

public class csvReader : MonoBehaviour
{
    private TextAsset csvFile; // CSVファイル
    private List<string[]> csvData = new List<string[]>(); // CSVファイルの中身を入れるリスト

    void Start()
    {
        csvFile = Resources.Load("MotionController") as TextAsset; // ResourcesにあるCSVファイルを格納
        StringReader reader = new StringReader(csvFile.text); // TextAssetをStringReaderに変換

        while (reader.Peek() != -1)
        {
            string line = reader.ReadLine(); // 1行ずつ読み込む
            csvData.Add(line.Split(',')); // csvDataリストに追加する
        }

        for (int i = 0; i < csvData.Count; i++) // csvDataリストの条件を満たす値の数（全て）
        {
            // データの表示
            Debug.Log("質問内容：" + csvData[i][0] + ", Animation：" + csvData[i][1] + ", Voice: "  + csvData[i][2] +  "picture: " + csvData[i][3]);
        }
    }
}