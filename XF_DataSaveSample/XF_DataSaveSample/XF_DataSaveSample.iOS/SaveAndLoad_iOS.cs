using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Foundation;
using UIKit;
using Xamarin.Forms;
using XF_DataSaveSample.iOS;

[assembly: Dependency(typeof(SaveAndLoad_iOS))]

namespace XF_DataSaveSample.iOS
{
    class SaveAndLoad_iOS: ISaveAndLoad
    {
        public void SaveData(string filename, string text)
        {
            var documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            var filePath = Path.Combine(documentsPath, filename);
            // File.WriteAllText �ł��ׂď㏑�����܂��BAppendAllText ���ƒǉ�����悤�ł��B
            System.IO.File.WriteAllText(filePath, text);
        }
        public string LoadData(string filename)
        {
            var documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            var filePath = System.IO.Path.Combine(documentsPath, filename);
            // �t�@�C����������� null ��Ԃ��܂��B
            if (System.IO.File.Exists(filePath))
            {
                return System.IO.File.ReadAllText(filePath);
            }
            return null;
        }
        public bool ClearData(string filename)
        {
            var documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            var filePath = System.IO.Path.Combine(documentsPath, filename);
            System.IO.File.Delete(filePath);
            // �t�@�C�����폜�o���Ă���� true, �����łȂ���� false ��Ԃ��܂��B
            return (System.IO.File.Exists(filePath)) ? false : true;
        }
    }
}