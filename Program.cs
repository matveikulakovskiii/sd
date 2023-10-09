using System;
using System.Text;

namespace Football
{
    class Program
    {
        static void Main(string[] args)
        {
            // Создайте стадион
            Stadium stadium = new Stadium(50, 20);

            // Создайте две команды
            Team homeTeam = new Team("Home Team");
            Team awayTeam = new Team("Away Team");

            // Создайте игру и установите команды и стадион
            Game footballGame = new Game(homeTeam, awayTeam, stadium);

            // Добавьте игроков в команды
            Player player1 = new Player("Player1");
            Player player2 = new Player("Player2");
            Player player3 = new Player("Player3");
            Player player4 = new Player("Player4");

            homeTeam.AddPlayer(player1);
            homeTeam.AddPlayer(player2);
            awayTeam.AddPlayer(player3);
            awayTeam.AddPlayer(player4);

            // Начните игру
            footballGame.Start();

            // Игровой цикл
            for (int i = 0; i < 100; i++)
            {
                // В этом цикле вы можете обновлять игру на каждом шаге
                footballGame.Move();
                Console.Clear(); // Очистить консоль для обновления экрана

                // Создайте буфер для рисования
                char[,] buffer = new char[stadium.Width, stadium.Height];

                // Отобразите стадион
                for (int x = 0; x < stadium.Width; x++)
                {
                    for (int y = 0; y < stadium.Height; y++)
                    {
                        buffer[x, y] = ' ';
                    }
                }

                // Отобразите игроков
                foreach (var player in homeTeam.Players)
                {
                    int x = (int)Math.Round(player.X);
                    int y = (int)Math.Round(player.Y);
                    buffer[x, y] = 'H'; // 'H' - домашний игрок
                }

                foreach (var player in awayTeam.Players)
                {
                    int x = (int)Math.Round(player.X);
                    int y = (int)Math.Round(player.Y);
                    buffer[x, y] = 'A'; // 'A' - гостевой игрок
                }

                // Отобразите мяч
                int ballX = (int)Math.Round(footballGame.Ball.X);
                int ballY = (int)Math.Round(footballGame.Ball.Y);
                buffer[ballX, ballY] = 'O'; // 'O' - мяч

                // Выведите буфер на экран
                StringBuilder screen = new StringBuilder();
                for (int y = 0; y < stadium.Height; y++)
                {
                    for (int x = 0; x < stadium.Width; x++)
                    {
                        screen.Append(buffer[x, y]);
                    }
                    screen.AppendLine();
                }
                Console.WriteLine(screen.ToString());

                // Задержка для визуализации
                System.Threading.Thread.Sleep(1000);
            }

            // Завершение игры
            Console.WriteLine("Game over!");
        }
    }
}