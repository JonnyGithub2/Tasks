namespace Tasks
{
    public class BoardManager
    {
        public List<Board> _boards;
        public BoardManager()
        {
            _boards = new List<Board>();
        }
        public void addBoard(Board pBoard)
        {
            _boards.Add(pBoard);
        }
        public int NumOfBoards()
        {
            return _boards.Capacity;
        }
        public string ListBoards()
        {
            string boards = Display.Line() + "\n";
            foreach(Board eBoard in _boards)
            {
                boards += "- " + eBoard + "\n";
            }
            boards += Display.Line();
            return boards;
        }
        public string ListBoardsWithIndex()
        {
            string boards = Display.Line() + "\n";
            int boardNum = 0;
            foreach(Board eBoard in _boards)
            {
                boardNum ++;
                boards += boardNum + " - " + eBoard + "\n";
            }
            boards += Display.Line();
            return boards;
        }
    }
}