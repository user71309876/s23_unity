using System;
using System.Collections.Generic;
using System.IO;
using System.Collections;
using UnityEngine;

public class DataManager<T>
{
    private static string dataFilePath=Application.persistentDataPath + "/GameData.json";

    [Serializable]
    public class SerializableData{
        public int id;
        public T data;
        public SerializableData(int id,T data){
            this.id = id;
            this.data = data;
        }
    }

    public class DataSaver{
        public static void SaveData(List<SerializableData> dataList){
            string jsonData=JsonUtility.ToJson(dataList);
            File.WriteAllText(dataFilePath,jsonData);
        }
    }

    public class DataLoader{
        public static List<SerializableData> LoadData(){
            List<SerializableData> dataList = new List<SerializableData>();
            if(File.Exists(dataFilePath)){
                string jsonData=File.ReadAllText(dataFilePath);
                dataList=JsonUtility.FromJson<List<SerializableData>>(jsonData);
            }
            else{
                Debug.LogWarning("no data");
            }
            return dataList;
        }

        public static Dictionary<int,T> GetDataDictionary(List<SerializableData> dataList){
            Dictionary<int,T> dataDictionary = new Dictionary<int,T>();
            foreach(var data in dataList){
                dataDictionary[data.id]=data.data;
            }
            return dataDictionary;
        }

        public static T GetDataById(Dictionary<int,T> dataDictionary, int id){
            T resultData;
            if(dataDictionary.TryGetValue(id, out resultData)){
                return resultData;
            }
            else{
                Debug.LogWarning("no data for id");
                return default(T);
            }
        }
    }
}