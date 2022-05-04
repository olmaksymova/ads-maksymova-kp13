using System;
using System.Drawing;
using System.Windows.Forms;
using static System.Convert;
using static System.Math;
namespace _6
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        /*Виконання сортування за умовою задачі*/
        private void Run_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();
            try
            {
                int M, N, min, max, MAX = -1;
                M = ToInt32(row.Text);
                N = ToInt32(col.Text);

                min = ToInt32(MinBox.Text);
                max = ToInt32(MaxBox.Text);

                int sortcount = (int)Ceiling(M / 2.0) * (N / 2);
                int[,] Array = new int[M, N];

                for (int i = 0; i < M; i++)
                    for (int j = 0; j < N; j++)
                    {
                        Array[i, j] = rnd.Next(min, max + 1);

                        if (Array[i, j] > MAX)
                            MAX = Array[i, j];
                    }
                DrawMatrix(50, 210, Array, "Вихідний масив:");

                int[,] Sorted = (int[,])Array.Clone();
                int[] Counter = new int[MAX + 1];

                for (int i = 0; i <= MAX; i++)
                    Counter[i] = 0;

                for (int i = 0; i < M; i += 2)
                    for (int j = 1; j < N; j += 2)
                        Counter[Array[i, j]]++;

                for (int i = 1; i <= MAX; i++)
                    Counter[i] += Counter[i - 1];

                for (int i = M % 2 == 0 ? M - 2 : M - 1; i >= 0; i -= 2)
                    for (int j = N % 2 == 0 ? N - 1 : N - 2; j >= 0; j -= 2)
                    {
                        /*змінні х, Index1,Index2 - задля того, щоб не створювати додаткові одновимірні масиви*/
                        int x = sortcount - Counter[Array[i, j]];                   
                        int Index1 = x / (N / 2) * 2, Index2 = x % (N / 2) * 2 + 1;
                        Sorted[Index1, Index2] = Array[i, j];
                        Counter[Array[i, j]]--;
                    }
                DrawMatrix(N * 60 + 140, 210, Sorted, "Результуючий масив:");
            }
            catch
            {
                MessageBox.Show("Помилка введення даних!!!", "❌Error❌");
            }
        }

        /*Побудова заданої та результуючої матриць на формі*/
        private void DrawMatrix(int leftmargin, int topmargin, int[,] Array, string ArrayName)
        {
            int M = Array.GetLength(0), N = Array.GetLength(1);
            int x = leftmargin, y = topmargin;

            PictureBox[,] pic = new PictureBox[M, N];
            Label[,] Results = new Label[M, N];

            Image backgr = Image.FromFile("Kvadrat.png");
            Label ArrName = new Label
            {
                AutoSize = true,
                TextAlign = ContentAlignment.MiddleCenter,
                Location = new Point(x, y),
                Font = new Font(Run.Font, FontStyle.Bold),
                Text = ArrayName
            };
            Controls.Add(ArrName);
            /*Побудова квадратиків для оформлення матриці*/
            y += 30;
            for (int i = 0; i < M; i++)
            {
                x = leftmargin;
                for (int j = 0; j < N; j++)
                {
                    pic[i, j] = new PictureBox
                    {
                        Size = new Size(60, 60),
                        SizeMode = PictureBoxSizeMode.Zoom,
                        Location = new Point(x, y),
                        Image = backgr
                    };
                    Controls.Add(pic[i, j]);
                    x += 60;
                }
                y += 60;
            }

            /*Побудова значень матриці*/
            y = topmargin - 30;
            for (int i = 0; i < M; i++)
            {
                x = leftmargin;

                for (int j = 0; j < N; j++)
                {
                    Results[i, j] = new Label
                    {
                        AutoSize = true,
                        TextAlign = ContentAlignment.MiddleCenter,
                        Location = new Point(15 + x, y + 80),
                        Font = Run.Font,
                        BackColor = Color.White
                    };
                    Results[i, j].Text = Array[i, j].ToString();

                    if (i % 2 == 0 && j % 2 == 1)
                        Results[i, j].ForeColor = Color.Red;

                    Controls.Add(Results[i, j]);
                    Results[i, j].BringToFront();

                    x += 60;
                }
                y += 60;
            }
        }
        /*Перезапуск програми*/
        private void Replay_Click(object sender, EventArgs e)
        {
            Form1 NewForm = new();
            NewForm.Show();
            Dispose(false);
        }
        /*Вихід з програми*/
        private void Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}