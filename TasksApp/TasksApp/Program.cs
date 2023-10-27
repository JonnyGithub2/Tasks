using Tasks;

Console.WriteLine("Welcome to my tasks management application");

BoardManager boardManager = new BoardManager();
Tasks.Task task1 = new Tasks.Task("this is my first task");
Console.WriteLine(task1.ToString());
Board board1 = new Board("this is my board");
board1.addTask(task1);
Console.WriteLine(board1.ToString());
Console.WriteLine(board1.listTasks());
Tasks.Task task2 = new Tasks.Task("this is my second task");
board1.addTask(task2);
Console.WriteLine(board1.listTasks());
boardManager.addBoard(board1);
ProgramOpen menus = new ProgramOpen(boardManager);
menus.OnSelect();
