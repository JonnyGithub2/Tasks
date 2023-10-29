namespace Tasks
{
    public class Board
    {
        private string _name;
        public List<Task> _tasks;
        public Board(string pName)
        {
            _name = pName;
            _tasks = new List<Task>();
        }
        public void addTask(Task pTask)
        {
            _tasks.Add(pTask);
        }
        public override string ToString()
        {
            return _name;
        }
        public string listTasks()
        {
            string tasks = Display.Line() + "\n";
            foreach(Task eTask in _tasks)
            {
                tasks += "- " + eTask + "\n";
            }
            tasks += Display.Line();
            return tasks;
        }
        public string getName()
        {
            return _name;
        }
    }
}