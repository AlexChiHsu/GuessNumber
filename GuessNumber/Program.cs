using System;

namespace GuessNumber
{
    
    internal class Program
    {
		enum MODE_TYPE
		{
			SET_UP = 0,
			GAMESTART,
			ENDGAME
		}
		static int[] answer = new int[4];
		static string guess = "";
		static int countA = 0;
		static int countB = 0;
		static int[] guspwd = new int[4];
		static MODE_TYPE mode = MODE_TYPE.SET_UP;
		static int count = 0;
		static char[] arr;
		static Random r = new Random();

		public static void setUp()
		{
			Console.WriteLine("SetUP");
			randomNum();
			mode = MODE_TYPE.GAMESTART;
		}
		public static void randomNum()
		{
			count = 0;
			check(answer);
			Console.WriteLine("Answer: " + answer[0] + "" + answer[1] + "" + answer[2] + "" + answer[3] + "");
		}
		public static void GameStart()
		{
			Console.WriteLine("Game Start");
			Console.WriteLine("Please input your numbers : ");
			round();
		}
		public static void Guess()
		{
			guess = Console.ReadLine();
			arr = guess.ToCharArray();
			if (arr.Length != 4)
			{
				Console.WriteLine("Error, please reentry");
				Guess();
			}
			count = 1;
			check(guspwd);
		}
		public static void check(int[] input)
		{
			for (int i = 0; i < 4; i++)
			{
				if (count == 0)
				{
					answer[i] = r.Next(0, 10);
				}
				else
				{
					guspwd[i] = arr[i] - '0';
				}
			}
			for (int i = 0; i < 4; i++)
			{
				for (int j = 3; j > i; j--)
				{
					if (input[j] == input[i])
					{
						if (count == 0)
						{
							input[j] += 1;
							input[j] %= 10;
						}
						else
						{
							Console.WriteLine("The numbers repeated, please reentry");
							Guess();
						}
					}
				}
			}
		}
		public static void round()
		{
			while (mode == MODE_TYPE.GAMESTART)
			{
				Guess();
				compare();
			}
		}

		public static void compare()
		{
			countA = 0;
			countB = 0;
			for (int i = 0; i < 4; i++)
			{
				for (int j = 0; j < 4; j++)
				{
					if (guspwd[i] == answer[j])
					{
						if (i == j)
						{
							countA++;
						}
						else
						{
							countB++;
						}
					}
				}
			}
			isCorrect();
		}
		public static void isCorrect()
		{
			if (countA == 4)
			{
				Console.WriteLine(countA + "A" + countB + "B");
				mode = MODE_TYPE.ENDGAME;
			}
			else
			{
				Console.WriteLine(countA + "A" + countB + "B");
			}
		}

		public static void endGame()
		{
			Console.WriteLine("End");
			Console.WriteLine();
			Console.WriteLine("Start a new Game");
			guess = "";
			countA = 0;
			countB = 0;
			mode = MODE_TYPE.SET_UP;
		}
		static void Main(string[] args)
		{
			while (true)
			{
				switch (mode)
				{
					case MODE_TYPE.SET_UP:
						setUp();
						mode = MODE_TYPE.GAMESTART;
						break;
					case MODE_TYPE.GAMESTART:
						GameStart();
						mode = MODE_TYPE.ENDGAME;
						break;
					case MODE_TYPE.ENDGAME:
						endGame();
						mode = MODE_TYPE.SET_UP;
						break;
					default:
						Console.WriteLine("error");
						break;
				}
			}	

		}
	}
}
