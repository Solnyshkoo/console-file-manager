using System;
using System.IO;
using System.Text;

namespace Peergrade
{
    class Program
    {
        static string path;
        static void Main()
        {
            Console.WriteLine(" И снова добрый вечер) И снова мы вместе) " +
                "Это проверять уже не так интересно, поэтому успехов тебе." +
                " Надеюсь на лояльную проверку) " + Environment.NewLine
                + Environment.NewLine + "Такс, начнём. Вот список дисков, " +
                "выбери где будем работать." + Environment.NewLine + Environment.NewLine +
                "PS." + Environment.NewLine + "Название директорий, файлов и тд надо вводить в ручную " + Environment.NewLine +
                "с соответствующим регистром, иначе входные данные считаются некорректными." + Environment.NewLine +
                " Будь внимателен)" + Environment.NewLine);
            FileManager(1);
            Console.WriteLine("Отлично) Идём дальше. ");
            Rules();
            do
            {
                Console.Write(Environment.NewLine + "Выбери, что будем делать: ");
                if (!(int.TryParse(Console.ReadLine(), out int number) && number >= 0 && number <= 15))
                {
                    do
                    {
                        Console.Write(Environment.NewLine + "Так не подойдёт. Выбери число от 0 до 15. " +
                                      Environment.NewLine + "Повтори ввод: ");
                    } while (!(int.TryParse(Console.ReadLine(), out number) && number >= 0 && number <= 15));

                }

                FileManager(number);

            } while (RepeatGame());
            Console.WriteLine(Environment.NewLine + "Приятно было с тобой работать) Хорошего дня.");
        }
        /// <summary>
        /// Вывод функционала.
        /// </summary>
        public static void Rules()
        {
            Console.WriteLine(Environment.NewLine + "0. Вывод команд." + Environment.NewLine +
                "1. Просмотр списка дисков компьютера и выбор диска." + Environment.NewLine +
                "2. Переход в другую директорию(выбор папки)." + Environment.NewLine +
                "3. Просмотр всех файлов в директории и выбор файла." + Environment.NewLine +
                "4. Вывод содержимого текстового файла в консоль в кодировке UTF-8." + Environment.NewLine +
                "5. Вывод содержимого текстового файла в консоль в выбранной " +
                "пользователем кодировке." + Environment.NewLine +
                "6. Копирование файла." + Environment.NewLine +
                "7. Перемещение файла в выбранную пользователем директорию." + Environment.NewLine +
                "8. Удаление файла." + Environment.NewLine +
                "9. Создание простого текстового файла в кодировке UTF-8." + Environment.NewLine +
                "10. Создание простого текстового файла в выбранной пользователем " +
                "кодировке." + Environment.NewLine +
                "11. Объединение содержимого двух или более текстовых файлов и вывод" + Environment.NewLine +
                "результата в консоль в кодировке UTF-8." + Environment.NewLine +
                "12. Подняться на один шаг вверх." + Environment.NewLine +
                "13. Очистить консоль." + Environment.NewLine +
                "14. Информация о дисках" + Environment.NewLine +
                "15. Информация о текущем пути.");

        }
        /// <summary>
        /// Вызов задач.
        /// </summary>
        /// <param name="number"> Выбор пользователя. </param>
        public static void FileManager(int number)
        {
            switch (number)
            {
                case 0:
                    Rules();
                    break;
                case 1:
                    ChooseDisk();
                    break;
                case 2:
                    ChooseDirectory();
                    break;
                case 3:
                    ChooseFile();
                    break;
                case 4:
                    WriteFile8();
                    break;
                case 5:
                    WriteFileChoose();
                    break;
                case 6:
                    CopyFile();
                    break;
                case 7:
                    MoveFile();
                    break;
                case 8:
                    DeleteFile();
                    break;
                case 9:
                    CreateFileUtf8();
                    break;
                case 10:
                    CreateFileChoose();
                    break;
                case 11:
                    MergeFiles();
                    break;
                case 12:
                    Back();
                    break;
                case 13:
                    Clean();
                    break;
                case 14:
                    DiskInfo();
                    break;
                case 15:
                    GetCurrentPath();
                    break;
            }
        }
        /// <summary>
        /// Повтор решения.
        /// </summary>
        /// <returns> Выбор пользователя. </returns>
        static bool RepeatGame()
        {
            Console.WriteLine(Environment.NewLine + "Для выхода нажми - Escape. " +
                              "Для продолжения любую клавишу.");
            return Console.ReadKey(true).Key != ConsoleKey.Escape;
        }
        /// <summary>
        /// Выбор диска.
        /// </summary>
        static void ChooseDisk()
        {
            DriveInfo[] allDrives = DiskName();
            while (true)
            {
                try
                {
                    int a = 0;
                    Console.Write("Выбери диск: ");
                    path = Console.ReadLine();
                    for (int i = 0; i < allDrives.Length; i++)
                    {
                        if (path == allDrives[i].ToString())
                        {
                            a = 1;
                            break;
                        }
                    }
                    if (a == 1)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Такого диска нет. Выбери из предложенных.");
                    }
                }
                catch (System.Security.SecurityException ex)
                {
                    Console.WriteLine($"Произошла ошибка безопасности: {ex.Message}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("ex " + ex.Message);
                }

            }

        }
        /// <summary>
        /// Запись имён диска в массив.
        /// </summary>
        /// <returns></returns>
        private static DriveInfo[] DiskName()
        {
            DriveInfo[] allDrives = DriveInfo.GetDrives();
            try
            {
                Console.WriteLine("Названия всех доступных дисков:");
                foreach (DriveInfo d in allDrives)
                {
                    if (d.IsReady == true)
                    {
                        Console.WriteLine("Диск {0}", d.Name);
                    }
                }
            }
            catch (System.Security.SecurityException ex)
            {
                Console.WriteLine($"Произошла ошибка безопасности: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine("ex " + ex.Message);
            }

            return allDrives;
        }
        /// <summary>
        /// Выбор директорий.
        /// </summary>
        private static void ChooseDirectory()
        {
            string[] dirs;
            try
            {
                dirs = Directory.GetDirectories(path);
                if (dirs.Length == 0)
                {
                    Console.WriteLine("Нет доступных директорий. Выбери другую команду");
                    return;
                }
                Console.WriteLine("Названия всех доступных директорий:");
                foreach (string item in dirs)
                {
                    Console.WriteLine(item);
                }
                Console.WriteLine("");
                while (true)
                {
                    int a = 0;
                    Console.Write($"Выберите директорию: {path}");
                    string dir = Console.ReadLine();
                    for (int i = 0; i < dirs.Length; i++)
                    {
                        if (path + dir == dirs[i].ToString())
                        {
                            a = 1;
                            break;
                        }
                    }
                    if (a == 1)
                    {
                        path += dir;
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Такой директории нет. Выбери из предложенных.");
                    }
                }
            }
            catch (System.Security.SecurityException ex)
            {
                Console.WriteLine($"Произошла ошибка безопасности: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine("ex " + ex.Message);
            }


        }
        /// <summary>
        /// Выбор файла.
        /// </summary>
        private static void ChooseFile()
        {
            string[] fileName;
            try
            {
                fileName = Directory.GetFiles(path);
                if (fileName.Length == 0)
                {
                    Console.WriteLine("Нет доступных файлов. Выбери другую команду");
                    return;
                }
                foreach (string item in fileName)
                {
                    Console.WriteLine(item);
                }
                Console.WriteLine("");

                while (true)
                {
                    int a = 0;
                    Console.Write($"Выберите файл: {path}");
                    string file = Console.ReadLine();
                    for (int i = 0; i < fileName.Length; i++)
                    {
                        if (path + file == fileName[i].ToString())
                        {
                            a = 1;
                            break;
                        }
                    }
                    if (a == 1)
                    {
                        path += file;
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Такого файла нет. Выбери из предложенных.");
                    }
                }
            }
            catch (System.Security.SecurityException ex)
            {
                Console.WriteLine($"Произошла ошибка безопасности: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine("ex " + ex.Message);
            }
        }
        /// <summary>
        /// Вывод файла в консоль в кодировке UTF8.
        /// </summary>
        private static void WriteFile8()
        {
            Console.WriteLine("Вывод:");
            try
            {
                if (File.Exists(path))
                {
                    Console.WriteLine(File.ReadAllText(path, Encoding.UTF8));
                }
                else
                {
                    Console.WriteLine("Данный файл невозможно вывести. По каким-то причинам его не существует.");
                }

            }
            catch (System.Security.SecurityException ex)
            {
                Console.WriteLine($"Произошла ошибка безопасности: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine("ex " + ex.Message);
            }

        }
        /// <summary>
        /// Вывод файла в консоль в выбранной пользователем кодировке.
        /// </summary>
        private static void WriteFileChoose()
        {
            string encode;

            try
            {
                do
                {
                    Console.Write("Выбери кодировку(UTF8, ASCII, UTF7, UTF32): ");
                    encode = Console.ReadLine().ToLower();
                    switch (encode)
                    {
                        case "utf8":
                            Console.WriteLine(File.ReadAllText(path, Encoding.UTF8));
                            break;
                        case "ascii":
                            Console.WriteLine(File.ReadAllText(path, Encoding.ASCII));
                            break;
                        case "utf7":
                            Console.WriteLine(File.ReadAllText(path, Encoding.UTF7));
                            break;
                        case "utf32":
                            Console.WriteLine(File.ReadAllText(path, Encoding.UTF32));
                            break;
                        default:
                            Console.WriteLine("Прости, такая кодировка не поддерживается( " + Environment.NewLine
                            + "Если она есть то, доработаем, а  пока выбери из предложенных" + Environment.NewLine);
                            break;
                    }
                } while (!(encode.ToLower() == "utf8" ||
                encode.ToLower() == "ascii" ||
                encode.ToLower() == "utf7" ||
                encode.ToLower() == "utf32"));

            }
            catch (System.Security.SecurityException ex)
            {
                Console.WriteLine($"Произошла ошибка безопасности: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine("ex " + ex.Message);
            }
        }
        /// <summary>
        /// Копирование файла.
        /// </summary>
        private static void CopyFile()
        {
            if (!File.Exists(path))
            {
                Console.WriteLine("Файла не существует или вы его не выбрали.");
                return;
            }
            Console.Write("Куда скопируем? Введите путь полностью: ");
            string path2 = Console.ReadLine();
            FileInfo fi1 = new FileInfo(path);
            try
            {
                if (!Directory.Exists(path2))
                {
                    do
                    {
                        Console.Write("Такого пути не существует. Введите корректные данные: ");
                        path2 = Console.ReadLine();
                    } while (!Directory.Exists(path2));
                }
                string[] fileName = path.Split(Path.DirectorySeparatorChar.ToString());
                path2 += Path.DirectorySeparatorChar.ToString() + fileName[fileName.Length - 1];
                if (File.Exists(path2))
                {
                    Console.WriteLine("Данный файл уже существует.");
                    return;
                }
                //Копирование.
                fi1.CopyTo(path2);
                Console.WriteLine("{0} файл был скопирован в {1}.", path, path2);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        /// <summary>
        /// Перемещение файла.
        /// </summary>
        private static void MoveFile()
        {
            if (!File.Exists(path))
            {
                Console.WriteLine("Файла не существует или вы его не выбрали.");
                return;
            }
            Console.Write("Введите путь полностью: ");
            string path2 = Console.ReadLine();
            try
            {
                if (!Directory.Exists(path2))
                {
                    do
                    {
                        Console.Write("Такого пути не существует. Введите корректные данные: ");
                        path2 = Console.ReadLine();
                    } while (!Directory.Exists(path2));
                }
                string[] fileName = path.Split(Path.DirectorySeparatorChar.ToString());
                path2 += Path.DirectorySeparatorChar.ToString() + fileName[fileName.Length - 1];
                if (!File.Exists(path))
                {
                    using (FileStream fs = File.Create(path)) { }
                }
                if (File.Exists(path2))
                {
                    Console.WriteLine("Данный файл уже существует.");
                    return;
                }
                File.Move(path, path2);
                Console.WriteLine("{0} файл был скопирован в {1}.", path, path2);

                if (!File.Exists(path))
                {
                    Console.WriteLine("Первоначальный файл больше не существует, как и ожидалось, он перемещён.");
                }
                else
                {
                    Console.WriteLine("Первоначальный файл существует, что странно,но он всё равно перемещён.");
                }
                FileManager(12);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
        /// <summary>
        /// Удаление файла.
        /// </summary>
        private static void DeleteFile()
        {

            try
            {
                if (!File.Exists(path))
                {
                    Console.WriteLine("Файла не существует или вы его не выбрали.");
                    return;
                }
                File.Delete(path);
                Console.WriteLine("Файл был удалён.");
                FileManager(12);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
        /// <summary>
        /// Создание файла в кодировке UTF8.
        /// </summary>
        private static void CreateFileUtf8()
        {
            try
            {
                Console.Write("Введите имя файла:");
                string FileName = Console.ReadLine() + ".txt";
                string path2 = path + Path.DirectorySeparatorChar.ToString() + FileName;
                if (File.Exists(path2))
                {
                    Console.WriteLine("Файл уже существует.");
                    return;
                }
                //File.CreateText(path2);
                Console.Write("Хотите что-то вписать в файл?" + Environment.NewLine
                    + "Введите текст здесь:");
                string text = Console.ReadLine();
                File.WriteAllText(path2, text, Encoding.UTF8);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }
            Console.WriteLine("Файл создан, иди проверяй)");
        }
        /// <summary>
        /// Создание файла в кодировке, выбранной пользователем.
        /// </summary>
        private static void CreateFileChoose()
        {
            string encode;
            try
            {
                Console.Write("Введите имя файла:");
                string FileName = Console.ReadLine() + ".txt";
                string path2 = path + Path.DirectorySeparatorChar.ToString() + FileName;
                if (File.Exists(path2))
                {
                    Console.WriteLine("Файл уже существует.");
                    return;
                }
                //File.CreateText(path2);
                Console.Write("Хотите что-то вписать в файл?" + Environment.NewLine
                    + "Введите текст здесь:");
                string text = Console.ReadLine();

                do
                {
                    Console.Write("Выбери кодировку(UTF8, ASCII, UTF7, UTF32): ");
                    encode = Console.ReadLine().ToLower();
                    switch (encode)
                    {
                        case "utf8":
                            File.WriteAllText(path2, text, Encoding.UTF8);
                            break;
                        case "ascii":
                            File.WriteAllText(path2, text, Encoding.ASCII);
                            break;
                        case "utf7":
                            File.WriteAllText(path2, text, Encoding.UTF7);
                            break;
                        case "utf32":
                            File.WriteAllText(path2, text, Encoding.UTF32);
                            break;
                        default:
                            Console.WriteLine("Прости, такая кодировка не поддерживается( " + Environment.NewLine
                            + "Если она есть, то доработаем, а  пока выбери из предложенных" + Environment.NewLine);
                            break;

                    }
                } while (!(encode.ToLower() == "utf8" ||
                 encode.ToLower() == "ascii" ||
                 encode.ToLower() == "utf7" ||
                 encode.ToLower() == "utf32"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }
            Console.WriteLine("Файл создан, иди проверяй)");
        }
        /// <summary>
        /// Объединение двух и более файлов.
        /// </summary>
        private static void MergeFiles()
        {
            string filePath;
            try
            {
                if (!Directory.Exists(path))
                {
                    Console.WriteLine("Директории не существует.");
                    return;
                }
                Console.Write("Сколько файлов вы хотите объединить: ");
                int countffiles;
                while (!int.TryParse(Console.ReadLine(), out countffiles) || countffiles <= 1)
                {
                    Console.Write("Введите корректное число файлов.");
                }
                Console.Write("Введи название нового файла: ");
                string NewFilePath = Path.Combine(path, Console.ReadLine().Trim() + ".txt");

                while (File.Exists(NewFilePath))
                {
                    Console.Write("Такой файл уже существует. Введите другое название: ");
                    NewFilePath = Path.Combine(path, Console.ReadLine().Trim() + ".txt");
                }
                for (int i = 0; i < countffiles; i++)
                {
                    Console.Write($"Введите полный путь {i + 1} файла: ");
                    filePath = Console.ReadLine().Trim();

                    while (!File.Exists(filePath))
                    {
                        Console.Write("Такого файла не существует." + Environment.NewLine +
                            " Введите корректный путь файла: ");
                        filePath = Console.ReadLine().Trim();
                    }
                    if (i == 0)
                    {
                        File.WriteAllLines(NewFilePath, File.ReadAllLines(filePath, Encoding.UTF8), Encoding.UTF8);
                    }
                    else
                    {
                        File.AppendAllLines(NewFilePath, File.ReadAllLines(filePath, Encoding.UTF8), Encoding.UTF8);
                    }
                }
                Console.WriteLine($"Файлы соединены в {Path.GetFileName(NewFilePath)}:");
                foreach (string i in File.ReadAllLines(NewFilePath, Encoding.UTF8))
                {
                    Console.WriteLine(i);
                }
            }
            catch (System.Security.SecurityException ex)
            {
                Console.WriteLine($"Произошла ошибка безопасности: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine("ex " + ex.Message);
            }
        }
        /// <summary>
        /// Очищение консоли.
        /// </summary>
        private static void Clean()
        {
            Console.Clear();
            FileManager(0);
        }
        /// <summary>
        /// Поднятие на один шаг вверх.
        /// </summary>
        private static void Back()
        {
            try
            {
                string[] pat = path.Split(Path.DirectorySeparatorChar);
                string[] res = new string[pat.Length - 1];
                Array.ConstrainedCopy(pat, 0, res, 0, pat.Length - 1);
                path = String.Join(Path.DirectorySeparatorChar.ToString(), res);
                Console.WriteLine($"Текущий путь: {path}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        /// <summary>
        /// Информация о дисках.
        /// </summary>
        private static void DiskInfo()
        {
            try
            {
                DriveInfo[] allDrives = DriveInfo.GetDrives();

                foreach (DriveInfo d in allDrives)
                {
                    Console.WriteLine("Диск {0}", d.Name);
                    Console.WriteLine("  Тип диска: {0}", d.DriveType);
                    if (d.IsReady == true)
                    {
                        Console.WriteLine("  Файловая система: {0}", d.DriveFormat);
                        Console.WriteLine(
                            "  Доступное пространство для текущего пользователя: {0, 15} байт",
                            d.AvailableFreeSpace);

                        Console.WriteLine(
                            "  Общее доступное пространство:          {0, 15} байт",
                            d.TotalFreeSpace);

                        Console.WriteLine(
                            "  Общий размер диска:            {0, 15} байт ",
                            d.TotalSize);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        /// <summary>
        /// Показывает текущий путь.
        /// </summary>
        private static void GetCurrentPath()
        {
            Console.WriteLine($"Текущий путь: {path}");
            try
            {
                Console.WriteLine(Environment.NewLine + "Доступные директории:");
                string[] infoDirectory = Directory.GetDirectories(path);
                foreach (string directory in infoDirectory)
                {
                    Console.WriteLine("     " + directory);
                }
                Console.WriteLine(Environment.NewLine + "Доступные файлы:");
                string[] infoFile = Directory.GetFiles(path);
                foreach (string files in infoFile)
                {
                    Console.WriteLine("     " + files);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
    }
}
