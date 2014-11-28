using System;
using System.IO;
using System.Runtime.InteropServices;

namespace CleanCode
{
    public static class RefactorMethod
    {
        private static void SaveData(string s, byte[] d)
        {
            WriteFile(s, d);
            SaveTime(s, d);
        }

        private static void WriteFile(string s, byte[] d)
        {
            var fs = new FileStream(s, FileMode.OpenOrCreate);
            fs.Write(d, 0, d.Length);

            fs = new FileStream(Path.ChangeExtension(s, "bkp"), FileMode.OpenOrCreate);
            fs.Write(d, 0, d.Length);
        }

        private static void SaveTime(string s, byte[] d)
        {
            string tf = s + ".time";
            var fs = new FileStream(tf, FileMode.OpenOrCreate);
            var t = BitConverter.GetBytes(DateTime.Now.Ticks);
            fs.Write(t, 0, t.Length);
            fs.Close();
        }
    }
}