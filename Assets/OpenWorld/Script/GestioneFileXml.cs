using Photon;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

static class GestioneFileXml
{
    public static string path = "";
    public static void SaveConfig(List<Blocco> U)
    {
        string NomeFile = GestioneFileXml.path + "World.xml";
        try
        {
            XmlSerializer xmls = new XmlSerializer(typeof(List<Blocco>));
            StreamWriter Sw = new StreamWriter(NomeFile, false);
            xmls.Serialize(Sw, U);
            Sw.Close();
        }

        catch (Exception e)
        {
            Console.WriteLine(e.ToString());
        }
    }

    public static List<Blocco> ReadConfig()
    {
        string NomeFile = GestioneFileXml.path + "World.xml";
        try
        {
            XmlSerializer Xmls = new XmlSerializer(typeof(List<Blocco>));
            StreamReader Sr = new StreamReader(NomeFile);
            List<Blocco> L = (List<Blocco>)Xmls.Deserialize(Sr);
            Sr.Close();
            return L;
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            return null;
        }
    }
}