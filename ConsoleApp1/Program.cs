using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

class ServerProgram
{
    static void Main()
    {
        var listener = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        var endPoint = new IPEndPoint(IPAddress.Any, 5000);

        try
        {
            listener.Bind(endPoint);
            listener.Listen(5);
            Console.WriteLine("Сервер запущен и ждет подключения...");

            while (true)
            {
                var clientSocket = listener.Accept();
                Console.WriteLine("Клиент подключился!");

                while (true)
                {
                    var buffer = new byte[1024];
                    int receivedBytes = clientSocket.Receive(buffer);
                    string clientMessage = Encoding.UTF8.GetString(buffer, 0, receivedBytes);

                    if (clientMessage.ToLower() == "exit")
                    {
                        Console.WriteLine("Клиент завершил соединение.");
                        break;
                    }

                    Console.WriteLine($"Клиент: {clientMessage}");
                    string serverResponse = $"Эхо: {clientMessage}";
                    clientSocket.Send(Encoding.UTF8.GetBytes(serverResponse));
                }

                clientSocket.Close();
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка: {ex.Message}");
        }
        finally
        {
            listener.Close();
        }
    }
}
