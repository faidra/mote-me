using VRM;
using UniRx.Async;
using UnityEngine;
using System;
using System.IO;

public class VRMAccessor
{
    public async UniTask<GameObject> LoadAsync(string path)
    {
        var context = new VRMImporterContext();
        context.ParseGlb(await ReadAllBytesAsync(GetSystemPath(path)));
        var model = await context.LoadAsyncTask();
        context.ShowMeshes();
        return model;
    }

    string GetSystemPath(string unityPath)
    {
        return "Assets/" + unityPath;
    }

    async static UniTask<Byte[]> ReadAllBytesAsync(string path)
    {
        byte[] result;
        using (FileStream SourceStream = File.Open(path, FileMode.Open))
        {
            result = new byte[SourceStream.Length];
            await SourceStream.ReadAsync(result, 0, (int)SourceStream.Length);
        }
        return result;
    }
}
