using System.Collections.Generic;

namespace SolitaryDungeon
{
    class Level
    {
        public Level(int Width, int Height)
        {
            _width = Width;
            _height = Height;
            InitializeMap();
            GenerateRoom(2, 0, 14, 9);
            GenerateRoom(22, 1, 18, 6);
            GenerateRoom(1, 12, 18, 6);
            GenerateHorizontalHallway(15, 3, 8, false);
            GenerateVerticalHallway(6, 8, 5, true);
            _characters = new List<Character>();
        }

        #region Properties

        public int Width
        {
            get { return _width; }
        }

        public int Height
        {
            get { return _height; }
        }

        public Tile[,] Map
        {
            get { return _map; }
        }

        public List<Character> Characters
        {
            get { return _characters; }
        }

        public Player Player
        {
            get { return (Player)_characters[0]; }
        }

        #endregion

        public void Update()
        {
            for (int i = 1; i < _characters.Count; ++i)
                _characters[i].Update();
        }

        public bool CheckCollision(int Xposition, int Yposition)
        {
            return _map[Yposition, Xposition].IsSolid;
        }

        public void Interact(int Xposition, int Yposition)
        {
            _map[Yposition, Xposition].ExecuteBehaviour();
        }

        private void InitializeMap()
        {
            _map = new Tile[_height, _width];
            for (int i = 0; i < _height; ++i)
                for (int j = 0; j < _width; ++j)
                    _map[i, j] = Tile.Empty();
        }

        #region Generators

        private void GenerateRoom(int Xposition, int Yposition, int Width = 5, int Height = 5)
        {
            _map[Yposition, Xposition] = new Wall(Wall.Type.TopLeft);
            _map[Yposition, Xposition + Width - 1] = new Wall(Wall.Type.TopRight);
            _map[Yposition + Height - 1, Xposition] = new Wall(Wall.Type.BotLeft);
            _map[Yposition + Height - 1, Xposition + Width - 1] = new Wall(Wall.Type.BotRight);
            
            for (int i = Yposition + 1; i < Yposition + Height - 1; ++i)
            {
                _map[i, Xposition] = new Wall(Wall.Type.Vertical);
                _map[i, Xposition + Width - 1] = new Wall(Wall.Type.Vertical);
            }
            for (int j = Xposition + 1; j < Xposition + Width - 1; ++j)
            {
                _map[Yposition, j] = new Wall(Wall.Type.Horizontal);
                _map[Yposition + Height - 1, j] = new Wall(Wall.Type.Horizontal);
            }
        }

        private void GenerateHorizontalHallway(int Xorigin, int Yorigin, int Length, bool HasDoors)
        {
            for (int x = Xorigin + 1; x < Xorigin + Length; ++x)
            {
                _map[Yorigin + 1, x] = new Wall(Wall.Type.Horizontal);
                _map[Yorigin - 1, x] = new Wall(Wall.Type.Horizontal);
            }
            if (HasDoors)
            {
                _map[Yorigin + 1, Xorigin] = new Wall(Wall.Type.InterRight);
                _map[Yorigin - 1, Xorigin] = new Wall(Wall.Type.InterRight);
                _map[Yorigin, Xorigin] = new Door(Door.Type.Vertical, false);
                _map[Yorigin + 1, Xorigin + Length - 1] = new Wall(Wall.Type.InterLeft);
                _map[Yorigin - 1, Xorigin + Length - 1] = new Wall(Wall.Type.InterLeft);
                _map[Yorigin, Xorigin + Length - 1] = new Door(Door.Type.Vertical, false);
            }
            else
            {
                _map[Yorigin + 1, Xorigin] = new Wall(Wall.Type.TopLeft);
                _map[Yorigin - 1, Xorigin] = new Wall(Wall.Type.BotLeft);
                _map[Yorigin, Xorigin] = Tile.Empty();
                _map[Yorigin + 1, Xorigin + Length - 1] = new Wall(Wall.Type.TopRight);
                _map[Yorigin - 1, Xorigin + Length - 1] = new Wall(Wall.Type.BotRight);
                _map[Yorigin, Xorigin + Length - 1] = Tile.Empty();
            }
        }

        private void GenerateVerticalHallway(int Xorigin, int Yorigin, int Length, bool HasDoors)
        {
            for (int y = Yorigin + 1; y < Yorigin + Length; ++y)
            {
               _map[y, Xorigin + 1] = new Wall(Wall.Type.Vertical);
               _map[y, Xorigin - 1] = new Wall(Wall.Type.Vertical);
            }
            if (HasDoors)
            {
               _map[Yorigin, Xorigin + 1] = new Wall(Wall.Type.InterBot);
               _map[Yorigin, Xorigin - 1] = new Wall(Wall.Type.InterBot);
               _map[Yorigin, Xorigin] = new Door(Door.Type.Horizontal, false);
               _map[Yorigin + Length - 1, Xorigin + 1] = new Wall(Wall.Type.InterTop);
               _map[Yorigin + Length - 1, Xorigin - 1] = new Wall(Wall.Type.InterTop);
               _map[Yorigin + Length - 1, Xorigin] = new Door(Door.Type.Horizontal, false);
            }
            else
            {
               _map[Yorigin, Xorigin + 1] = new Wall(Wall.Type.TopLeft);
               _map[Yorigin, Xorigin - 1] = new Wall(Wall.Type.TopRight);
               _map[Yorigin, Xorigin] = Tile.Empty();
               _map[Yorigin + Length - 1, Xorigin + 1] = new Wall(Wall.Type.BotLeft);
               _map[Yorigin + Length - 1, Xorigin - 1] = new Wall(Wall.Type.BotRight);
               _map[Yorigin + Length - 1, Xorigin] = Tile.Empty();
            }
        }

        #endregion

        #region Fields

        private int _width, _height;
        private Tile[,] _map;
        private List<Character> _characters;

        #endregion
    }
}