using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using System.Xml.Serialization;

namespace ConsoleApp2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int index = 0;
            string linha;

            StreamReader arquivoDePonto = new StreamReader("abril2017.txt");

            
            OcorrenciaPonto registroPonto = new OcorrenciaPonto();
            List<OcorrenciaPonto> listaDePontos = new List<OcorrenciaPonto>();


            //METODO UTILIZANDO SUBSTRING
            //while ((linha = arquivoDePonto.ReadLine()) != null)
            //{
            //    listaDePontos.Add(new OcorrenciaPonto());

            //    listaDePontos[index].matricula = linha.Substring(0, 15);
            //    listaDePontos[index].data = linha.Substring(15, 6);
            //    listaDePontos[index].hora = linha.Substring(21, 4);
            //    listaDePontos[index].filler = linha.Substring(25);

            //    index++;
            //}
            //arquivoDePonto.Close();

            

            //METODO UTILIZANDO REGEX
            while ((linha = arquivoDePonto.ReadLine()) != null)
            {
                Regex expressao = new Regex(@"(?<matricula>.{15})(?<data>\d{6})(?<hora>\d{4})(?<filler>\d{8})");
                Match dados = expressao.Match(linha);
                listaDePontos.Add(new OcorrenciaPonto());

                listaDePontos[index].setMatricula(dados.Groups["matricula"].Value);
                listaDePontos[index].setData(dados.Groups["data"].Value);
                listaDePontos[index].setHora(dados.Groups["hora"].Value);
                listaDePontos[index].setFiller(dados.Groups["filler"].Value);

                index++;
            }
            arquivoDePonto.Close();

            
            

            TextWriter arquivoXML = new StreamWriter("PontoAbril2017regex.xml");
            XmlSerializer objetoNaoSerializado = new XmlSerializer(listaDePontos.GetType());

            objetoNaoSerializado.Serialize(arquivoXML, listaDePontos);
            arquivoXML.Close();

        }
    }
}