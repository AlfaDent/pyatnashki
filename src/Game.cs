using System;

namespace TagGame.src
{
    public class Game
    {
        int[,] map;
        int size;
        int void_x, void_y;
        static Random rand = new Random();

        //конструктор, устанавливает размер матрицы
        public Game(int size) {
            map = new int[size, size];
            this.size = size;
        }

        //метод выполняет начальное наполнение матрицы по порядку
        //определяет нулевую ячейку (пустую)
        public void start() {

            for (int x = 0; x < size; x++)
            {
                for (int y = 0; y < size; y++) {                   
                    map[x, y] = position(x, y) + 1;
                    void_x = size - 1;
                    void_y = size - 1;
                    map[void_x, void_y] = 0;
                }
            }
        }

        //метод выполняет сдвиг на пустую соседнюю ячейку
        public void move (int pos) {
            int x, y;
            pos_coordinate(pos, out x, out y);

            if (Math.Abs(void_x - x) + Math.Abs(void_y - y) == 1)
            {
                map[void_x, void_y] = map[x, y];
                map[x, y] = 0;
                void_x = x;
                void_y = y;
            }
        }

        //перемешивает поле
        public void random() {

            for (int i = 0; i < 200; i++) {
                move(rand.Next(0, 16));
            }

        }

        //
        private int position(int x, int y) {
            return x * size + y;
        }
    
        //метод возвращает координаты ячейки в матрице
        public int getNumber(int pos)
        {
            int x, y;
            pos_coordinate(pos, out x, out y);
            return map[x, y];
        }

        //вычисляет заначение по оси х и оси у в матрице
        private void pos_coordinate(int pos, out int x, out int y) {
            y = pos % size;
            x = pos / size;
        }



    }
}
