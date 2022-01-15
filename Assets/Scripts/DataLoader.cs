using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;


public sealed class DataLoader : IDataLoader
{
    private const string DATA_FOLDER = "Data";
    
		
    public T GetData<T>(string name) where T : UnityEngine.Object
    {
        var path = Path.Combine(DATA_FOLDER, name);
        var data = Resources.Load<T>(path);

        if (data == null)
            throw new Exception("Data by path: " + path + " not found");

        return data;
    }
		
    public List<T> GetAllDataByType<T>() where T : UnityEngine.Object
    {
        var data = Resources.LoadAll<T>(DATA_FOLDER).ToList();

        if (data == null)
            throw new Exception("Data by path: " + DATA_FOLDER + " not found");

        return data;
    }

}