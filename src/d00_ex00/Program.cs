// Первая строка, которая является комментарием

/*
    Многострочный комментарий
*/
Console.WriteLine("Hello, World!");  // Выводим Hello, world!
Console.WriteLine("AbobA");          // Выводим абобу

Console.WriteLine(args.FirstOrDefault());
for (int i = 0; i < args.Length; i++) {
    Console.Write("{0} ", args[i]);
}
