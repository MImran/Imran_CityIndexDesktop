using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.IO;

namespace CityIndexHelper
{
    public class ConfigurationHelper
    {
        public ConfigurationHelper(string applicationPath)
        {
            appPath = applicationPath;
        }

        private string appPath;

        private void createConfigXML()
        {
            XmlDocument xmlConfigFile;
            XmlNode rootNode;
            XmlElement xmlElement;

            xmlConfigFile = new XmlDocument();
            rootNode = xmlConfigFile.CreateElement("", "Configurations", "");
            xmlConfigFile.AppendChild(rootNode);

            xmlElement = xmlConfigFile.CreateElement("", "UI", "");
            xmlConfigFile.ChildNodes.Item(0).AppendChild(xmlElement);

            xmlElement = xmlConfigFile.CreateElement("", "Symbols", "");
            xmlConfigFile.ChildNodes.Item(0).AppendChild(xmlElement);

            xmlElement = xmlConfigFile.CreateElement("", "configuration", "");
            xmlElement.SetAttribute("name", "opacity");
            xmlElement.InnerText = "100";
            xmlConfigFile.ChildNodes.Item(0).ChildNodes.Item(0).AppendChild(xmlElement);

            xmlElement = xmlConfigFile.CreateElement("", "configuration", "");
            xmlElement.SetAttribute("name", "backColor");
            xmlElement.InnerText = "123324";
            xmlConfigFile.ChildNodes.Item(0).ChildNodes.Item(0).AppendChild(xmlElement);


            xmlElement = xmlConfigFile.CreateElement("", "configuration", "");
            xmlElement.SetAttribute("name", "foreColor");
            xmlElement.InnerText = "1234534";
            xmlConfigFile.ChildNodes.Item(0).ChildNodes.Item(0).AppendChild(xmlElement);

            xmlElement = xmlConfigFile.CreateElement("", "configuration", "");
            xmlElement.SetAttribute("name", "fontName");
            xmlElement.InnerText = "Arial";
            xmlConfigFile.ChildNodes.Item(0).ChildNodes.Item(0).AppendChild(xmlElement);


            xmlElement = xmlConfigFile.CreateElement("", "configuration", "");
            xmlElement.SetAttribute("name", "fontSize");
            xmlElement.InnerText = "10";
            xmlConfigFile.ChildNodes.Item(0).ChildNodes.Item(0).AppendChild(xmlElement);

            xmlConfigFile.Save(appPath + "\\CISS_Configurations.xml");
        }
        public UIConfiguration GetConfigurations()
        {
            UIConfiguration currentConfigurations = new UIConfiguration();

            if (!File.Exists(appPath + "\\CISS_Configurations.xml"))
                createConfigXML();
            XmlDocument configFile = new XmlDocument();
            configFile.Load("CISS_Configurations.xml");
            XmlNodeList configNodes = configFile.GetElementsByTagName("configuration");

            for (int i = 0; i < configNodes.Count; i++)
            {
                if (configNodes[i].Attributes[0].Value == "opacity")
                    currentConfigurations.Opacity = Convert.ToInt16(configNodes[i].InnerText);
                if (configNodes[i].Attributes[0].Value == "backColor")
                    currentConfigurations.BackColor = Convert.ToInt32(configNodes[i].InnerText);
                if (configNodes[i].Attributes[0].Value == "foreColor")
                    currentConfigurations.ForeColor = Convert.ToInt32(configNodes[i].InnerText);
                if (configNodes[i].Attributes[0].Value == "fontName")
                    currentConfigurations.FontName = configNodes[i].InnerText;
                if (configNodes[i].Attributes[0].Value == "fontSize")
                    currentConfigurations.FontSize = Convert.ToDouble(configNodes[i].InnerText);
            }

            return currentConfigurations;
        }
        public void SetConfigurations(UIConfiguration newConfig)
        {
            XmlDocument configFile = new XmlDocument();
            configFile.Load("CISS_Configurations.xml");

            configFile.FirstChild.ChildNodes[0].ChildNodes[0].InnerText = newConfig.Opacity.ToString();
            configFile.FirstChild.ChildNodes[0].ChildNodes[1].InnerText = newConfig.BackColor.ToString();
            configFile.FirstChild.ChildNodes[0].ChildNodes[2].InnerText = newConfig.ForeColor.ToString();
            configFile.FirstChild.ChildNodes[0].ChildNodes[3].InnerText = newConfig.FontName;
            configFile.FirstChild.ChildNodes[0].ChildNodes[4].InnerText = newConfig.FontSize.ToString();

            configFile.Save(appPath + "\\CISS_Configurations.xml");
        }
    }
}
