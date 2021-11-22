using System;

namespace GameFramework.Utilities
{
	public static class GameUtilities {
		private static readonly Random _random = new Random();
		public static int RandomNumber(int start, int end) {
			return _random.Next(start, end);
		}
	}
}
