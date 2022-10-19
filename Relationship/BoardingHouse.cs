using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Relationship
{
	internal class BoardingHouse
	{
		public List<Room> RoomList = new List<Room>();
		public void ShowRoomList()
		{
			Console.WriteLine("List of room:");
			foreach (var room in RoomList)
				Console.WriteLine(room.RoomNumber);
		}
	}
}
