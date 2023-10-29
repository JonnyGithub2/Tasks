using System.Runtime.CompilerServices;
using System.Security.Cryptography;

namespace Tasks
{
    #region MenuItems
    public abstract class MenuItem
    {
        public abstract string MenuText();
        public abstract void OnSelect();
    }
    public class AddTaskMenuItem : MenuItem
    {
        private Board _currentBoard;
        public AddTaskMenuItem(Board pBoard)
        {
            _currentBoard = pBoard;
        }
        public override string MenuText()
        {
            return "Add a task to this board";
        }
        public override void OnSelect()
        {
            Console.WriteLine("What is the name of the task?");
            string taskName = Console.ReadLine();
            Console.WriteLine("Any more detail to the task");
            string taskDetail = Console.ReadLine();
            _currentBoard.addTask(new Task(taskName, taskDetail));
        }
    }
    public class ProgramOpen : MenuItem
    {
        BoardManager _boardManager;
        public ProgramOpen(BoardManager pBoardManager)
        {
            _boardManager = pBoardManager;
        }
        public override string MenuText()
        {
            return "errorrrr";
        }
        public override void OnSelect()
        {
            Console.WriteLine("Welcome to my task management application");
            Menu nextMenu = new BoardsViewMenu(_boardManager);
            nextMenu.CreateMenu();
        }
    }
    public class BoardSelectMenuItem : MenuItem
    {
        Board _board;
        BoardManager _boardManager;
        public BoardSelectMenuItem(Board pBoard, BoardManager pBoardManager)
        {
            _board = pBoard;
            _boardManager = pBoardManager;
        }
        public override string MenuText()
        {
            return _board.ToString();
        }
        public override void OnSelect()
        {
            Menu newMenu = new BoardViewMenu(_board, _boardManager);
            newMenu.CreateMenu();
        }
    }
    public class TaskSelectMenuItem : MenuItem
    {
        Task _task;
        Board _board;
        BoardManager _boardManager;
        public TaskSelectMenuItem(Task pTask, Board pBoard, BoardManager pBoardManager)
        {
            _task = pTask;
            _board = pBoard;
            _boardManager = pBoardManager;
        }
        public override string MenuText()
        {
            return _task.ToString();
        }
        public override void OnSelect()
        {
            Menu newMenu = new TaskViewMenu(_task, _board, _boardManager);
            newMenu.CreateMenu();
        }
    }
    public class ExitMenuMenuItem : MenuItem
    {
        public Menu _menu;
        public ExitMenuMenuItem(Menu pMenu)
        {
            _menu = pMenu;
        }
        public override string MenuText()
        {
            return "Exit";
        }
        public override void OnSelect()
        {
            _menu.Close();
        }
    }
    #endregion MenuItems
    #region Menus
    public abstract class Menu
    {
        public abstract void CreateMenu();
        public abstract void Select();
        public abstract bool isActive();

        public abstract void Close();
    }
    public class BoardsViewMenu : Menu
    {
        BoardManager _boardManager;
        bool _isActive;
        public override bool isActive()
        {
            return _isActive;
        }
        public List<MenuItem> _items = new List<MenuItem>();
        public BoardsViewMenu(BoardManager pBoardManager)
        {
            _isActive = true;
            _boardManager = pBoardManager;
        }
        public override void CreateMenu()
        {
            _items.Clear();
            if(_isActive)
            {
                Console.WriteLine("Overall Board view");
                foreach(Board board in _boardManager._boards)
                {
                    _items.Add(new BoardSelectMenuItem(board, _boardManager));
                }
                _items.Add(new ExitMenuMenuItem(this));
                Select();
            }
        }
        public override void Select()
        {
            int i = 1;
            foreach (MenuItem item in _items)
            {
                Console.WriteLine(i + " - " + item.MenuText());
                i++;
            }
            int choice = MenuHelpers.MakeChoice(_items.Count);
            _items[choice].OnSelect();
            CreateMenu();
        }
        public override void Close()
        {
            _isActive = false;
        }
    }
    public class BoardViewMenu : Menu
    {
        BoardManager _boardManager;
        Board _board;
        bool _isActive;
        public override bool isActive()
        {
            return _isActive;
        }
        public List<MenuItem> _items = new List<MenuItem>();
        public BoardViewMenu(Board pBoard, BoardManager pBoardManager)
        {
            _isActive = true;
            _boardManager = pBoardManager;
            _board = pBoard;
        }
        public override void CreateMenu()
        {
            _items.Clear();
            if(_isActive)
            {
                Console.WriteLine($"Board view for board {_board.getName()}");
                foreach(Task task in _board._tasks)
                {
                    _items.Add(new TaskSelectMenuItem(task, _board,  _boardManager));
                }
                _items.Add(new AddTaskMenuItem(_board));
                _items.Add(new ExitMenuMenuItem(this));
                Select();
            }
        }
        public override void Select()
        {
            int i = 1;
            foreach (MenuItem item in _items)
            {
                Console.WriteLine(i + " - " + item.MenuText());
                i++;
            }
            int choice = MenuHelpers.MakeChoice(_items.Count);
            _items[choice].OnSelect();
            CreateMenu();
        }
        public override void Close()
        {
            _isActive = false;
        }
    }
    public class TaskViewMenu : Menu
    {
        BoardManager _boardManager;
        Board _board;
        Task _task;
        bool _isActive;
        public override bool isActive()
        {
            return _isActive;
        }
        public List<MenuItem> _items = new List<MenuItem>();
        public TaskViewMenu(Task pTask, Board pBoard, BoardManager pBoardManager)
        {
            _isActive = true;
            _boardManager = pBoardManager;
            _board = pBoard;
            _task = pTask;
        }
        public override void CreateMenu()
        {
            _items.Clear();
            if(_isActive)
            {
                Console.WriteLine($"Task view for {_task.getName()}");
                //_items.Add(new EditTaskMenuItem(_task));
                //_items.Add(new RemoveTaskMenuItem(_task));
                _items.Add(new ExitMenuMenuItem(this));
                Select();
            }
        }
        public override void Select()
        {
            Console.WriteLine(_task.TaskInfo());
            int i = 1;
            foreach (MenuItem item in _items)
            {
                Console.WriteLine(i + " - " + item.MenuText());
                i++;
            }
            int choice = MenuHelpers.MakeChoice(_items.Count);
            _items[choice].OnSelect();
            CreateMenu();
        }
        public override void Close()
        {
            _isActive = false;
        }
    }
    #endregion Menus
}