using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;
using System.Text;
using System.IO;

public class ConfigIni
{
    public string path; //ini文件的路径
    public ConfigIni(string path)
    {
        this.path = path;
    }
    [DllImport("kernel32")]
    public static extern long WritePrivateProfileString(string section, string key, string value, string path);
    [DllImport("kernel32")]
    public static extern int GetPrivateProfileString(string section, string key, string deval, StringBuilder stringBuilder, int size, string path);

    //写入ini文件
    public void WriteIniContent(string section, string key, string value)
    {
        WritePrivateProfileString(section, key, value, this.path);
    }
    //读取ini文件
    public string ReadIniContent(string section, string key)
    {
        StringBuilder temp = new StringBuilder(255);
        int i = GetPrivateProfileString(section, key, "", temp, 255, this.path);
        return temp.ToString();
    }
    //判断路径是否正确
    public bool IsIniPath()
    {
        return File.Exists(this.path);

    }
}