namespace Tasks
{
    public class Task
    {
        private string _name;
        private string _detail;
        public Task(string pName, string pDetail = "")
        {
            _name = pName;
            _detail = pDetail;
        }
        public override string ToString()
        {
            return _name;
        }
        public string TaskInfo()
        {
            string taskInfo = "";
            taskInfo += _name;
            taskInfo += "\n";
            taskInfo += _detail;
            return taskInfo;
        }
        public string getName()
        {
            return _name;
        }
    }
}