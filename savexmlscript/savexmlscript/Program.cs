using System;
using System.IO;
using System.Xml.Serialization;

namespace savexmlscript
{
    [XmlRoot("dados")]
    public class Transform
    {
        public int posx;
        public int posy;

        [XmlElement("PosX", typeof(Int32))]
        public int PosX
        {
            get { return this.posx; }
            set { this.posx = value; }
        }
        [XmlElement("PosY", typeof(Int32))]
        public int PosY
        {
            get { return this.posy; }
            set { this.posy = value; }
        }
        public string toString()
        {
            return PosX + " : " + PosY;
        }
    } //Meta Dados

    class class1
    {
        static string path = @"C:\Users\Usuário\AppData\LocalLow\savestests\save.dat"; //local de armazenamento
        static void Main(string[] args)
        {
            Console.WriteLine("selecione 1 para salvar ou 2 para carregar");

            int i = 0;
            i = int.Parse(Console.ReadLine());

            switch (i)
            {
                case 1: Save();
                    break;
                case 2: Load();
                    break;
            } //seleção
        }
        static void Save()
        {
            if (File.Exists(path))
            {
                File.Delete(path);
            } //deleta os dados do arquivo de save para reescreve-los

            XmlSerializer x = new XmlSerializer(typeof(Transform)); //serialização da classe
            StreamWriter writer = new StreamWriter(path, true); //escrita das variaveis 

            Transform p = new Transform(); //classe a serializar
            p.posx = int.Parse(Console.ReadLine()); //dado
            p.posy = int.Parse(Console.ReadLine()); //dado

            x.Serialize(writer, p); //escreve o save xml

            writer.Close(); //fecha o arquivo
            Console.ReadKey();
        } //Salvamento de dados
        static void Load()
        {
            XmlSerializer x = new XmlSerializer(typeof(Transform)); //Serialização da classe
            StreamReader reader = new StreamReader(path); //Leitura das variaveis

            Transform p = (Transform)x.Deserialize(reader); //Transfere variaveis carregadas para sua classe de origem
            reader.Close(); //fecha arquivo

            Console.WriteLine(p.toString()); //mostrar ao usuario o valor carregado
            Console.ReadKey();
        } //Carregamento de dados
    }
}