using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.IO.IsolatedStorage;
using System.Runtime.Serialization;
using System.IO;
using System.Xml.Serialization;

namespace HcsLib.WindowsPhone.Msic
{
    public class IsolatedStorageHelper
    {

        public static T LoadFile<T>(string fileName, bool isUseXmlSerializer = false)
        {
            T obj = default(T);
            try
            {
                using (var file = IsolatedStorageFile.GetUserStoreForApplication())
                {
                    if (file.FileExists(fileName))
                    {
                        using (var stream = file.OpenFile(fileName, System.IO.FileMode.Open))
                        {
                            if (isUseXmlSerializer)
                            {
                                XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
                                obj = (T)xmlSerializer.Deserialize(stream);
                            }
                            else
                            {
                                DataContractSerializer ser = new DataContractSerializer(typeof(T));
                                obj = (T)ser.ReadObject(stream);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                //TODO: 
            }
            return obj;
        }

        public static void SaveFile<T>(string fileName, T obj, bool isUseXmlSerializer = false)
        {
            try
            {
                using (var file = IsolatedStorageFile.GetUserStoreForApplication())
                {
                    using (var stream = file.OpenFile(fileName, System.IO.FileMode.Create))
                    {
                        if (isUseXmlSerializer)
                        {
                            XmlSerializer xmlSer = new XmlSerializer(typeof(T));
                            xmlSer.Serialize(stream,obj);
                        }
                        else
                        {
                            DataContractSerializer ser = new DataContractSerializer(typeof(T));
                            ser.WriteObject(stream, obj);
                        }
                    }
                }
            }
            catch (Exception)
            {
                //TODO: 
            }
        }
    }
}
