using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.IO;

namespace TSPsolvers
{
    class Operations
    {
        static public double[,] GetCostMatrix(string xmlAddress)
        {
            XmlReader reader = XmlReader.Create(xmlAddress);
            int nodeId = 0;
            while (reader.ReadToFollowing("vertex"))
                nodeId++;
            int numNodes = nodeId;
            double[,] costs = new double[numNodes, numNodes];

            nodeId = -1;
            reader = XmlReader.Create(xmlAddress);
            while (reader.ReadToFollowing("vertex"))
            {
                nodeId++;
                int i = 0;
                while (i < numNodes)
                {
                    reader.ReadToFollowing("edge");
                    reader.MoveToFirstAttribute();
                    double cost = Convert.ToDouble(reader.Value);
                    costs[nodeId, i] = cost;
                    i++;
                }
            }

            return costs;
        }

        static public void ExportCostMatrix(string xmlAddress, Node[] nodes)
        {
            using (XmlWriter writer = XmlWriter.Create(xmlAddress))
            {
                writer.WriteStartDocument();

                writer.WriteStartElement("travellingSalesmanProblemInstance");

                writer.WriteElementString("source", "RandomlyGenerated");
                writer.WriteElementString("description", nodes.Length.ToString() + " node problem");

                writer.WriteStartElement("graph");
                foreach (Node node in nodes)
                {
                    writer.WriteStartElement("vertex");

                    for (int i = 0; i < node.costFromThis.Length; i++)
                    {
                        writer.WriteStartElement("edge");
                        writer.WriteAttributeString("cost", node.costFromThis[i].ToString());
                        writer.WriteString(i.ToString());
                        writer.WriteEndElement();
                    }

                    writer.WriteEndElement();
                }
                writer.WriteEndElement();

                writer.WriteEndElement();
                writer.WriteEndDocument();
            }
        }

        public static double[,] ReadCSVdata(string strFilePath)
        {
            StreamReader sr = new StreamReader(strFilePath);
            string[] headers = sr.ReadLine().Split(',');
            double[,] costs = new double[headers.Length - 1, headers.Length - 1];
            int city = 0;
            while (!sr.EndOfStream)
            {
                string[] rows = sr.ReadLine().Split(',');
                for (int i = 1; i < headers.Length; i++)
                {
                    costs[city, i - 1] = Convert.ToDouble(rows[i]);
                }
                city++;
            }
            return costs;
        }
    }
}