using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public static class SaveSystem
{
    private const string EXPORT_METHOD = "txt";

    private static readonly string SAVE_FOLDER = Application.dataPath + "/saves/";

    private static bool isInit = false;

    public static void Init()
    {
        if (!isInit)
        {
            isInit = true;
            if (!Directory.Exists(SAVE_FOLDER)) { 
                Directory.CreateDirectory(SAVE_FOLDER);
            };
        }
    }

    public static void Save(string filename, string saveString, bool overwrite)
    {
        Init();
        string saveFileName = filename;
        if (!overwrite)
        {
            int saveNumber = 1;
            while (File.Exists(SAVE_FOLDER + saveFileName +"." +EXPORT_METHOD))
            {
                saveNumber++;
                saveFileName = filename + "_" + saveNumber;
            }

        }
        File.WriteAllText(SAVE_FOLDER + saveFileName + "." + EXPORT_METHOD, saveString);
    }

    public static string Load(string fileName)
    {
        Init();
        if (File.Exists(SAVE_FOLDER + fileName +"."+ EXPORT_METHOD))
        {
            string saveString = File.ReadAllText(SAVE_FOLDER + fileName + "." + EXPORT_METHOD);
            return saveString;
        }
        else { return null; }
    }
    public static string LoadMostRecentFile()
    {
        Init();
        DirectoryInfo directoryInfo = new DirectoryInfo(SAVE_FOLDER);
        FileInfo[] saveFiles = directoryInfo.GetFiles("*." + EXPORT_METHOD);
        FileInfo mostRecentFile = null;
        foreach(FileInfo fileInfo in saveFiles)
        {
            if(mostRecentFile == null)
            {
                mostRecentFile = fileInfo;
            }
            else
            {
                if(fileInfo.LastWriteTime > mostRecentFile.LastWriteTime) { mostRecentFile = fileInfo; }
            }
        }
        // If theres a save file, load it else return null
        if(mostRecentFile != null)
        {
            string saveString = File.ReadAllText(mostRecentFile.FullName);
            return saveString;
        }
        else { return null; }
    }

    public static void SaveObject(object saveObject)
    {
        SaveObject("save", saveObject, false);
    }

    public static void SaveObject(string fileName, object saveObject, bool overwrite)
    {
        Init();
        string json = JsonUtility.ToJson(saveObject);
        Save(fileName, json, overwrite);
    }
    
    public static TSaveObject LoadMostRecentObject<TSaveObject>()
    {
        Init();
        string saveString = LoadMostRecentFile();
        if (saveString != null)
        {
            TSaveObject saveObject = JsonUtility.FromJson<TSaveObject>(saveString);
            return saveObject;


        }
        else
        {
            return default(TSaveObject);
        }

    }

    public static TSaveObject LoadObject<TSaveObject>(string fileName)
    {
        Init();
        string saveString = Load(fileName);
        if(saveString != null)
        {
            TSaveObject saveObject = JsonUtility.FromJson<TSaveObject>(saveString);
            return saveObject;
        }else { return default(TSaveObject); }

    }

}
